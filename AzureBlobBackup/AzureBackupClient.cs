/*
 * File: AzureBackupClient.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Implements a backup utility for backing up files to and from Azure Blob Storage.
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;

namespace AzureBlobBackup
{
    /// <summary>
    /// Implements a backup client for the Azure Blob Storage service.
    /// </summary>
    public class AzureBackupClient
    {
        // Set to minimum upload and download speeds from config
        private readonly float downloadSpeed, uploadSpeed;
        // Represents upload or download direction
        private enum Direction { Up, Down };
       
        /// <summary>
        /// Constructs the AzureBackupClient using the options from the BackupOptions instance.
        /// </summary>
        /// <param name="options">Options to use such as the local path, cloud container and account info.</param>
        public AzureBackupClient()
        {
            // This is so CloudStorageAccount.FromConfigurationSetting knows where to get config from
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) => configSetter(System.Configuration.ConfigurationManager.AppSettings[configName]));

            // For approximating timeouts, better would be to calculate this during upload download and use the last speed calculated
            downloadSpeed = Single.Parse(ConfigurationManager.AppSettings["DownloadSpeed"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            uploadSpeed = Single.Parse(ConfigurationManager.AppSettings["UploadSpeed"], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            // Prevent sleep and hibernate by regularly informing Windows we are alive
            System.Timers.Timer pwr = new System.Timers.Timer() { Interval = 60000, Enabled = true };
            pwr.Elapsed += new System.Timers.ElapsedEventHandler(
                (sender, e) => Native.Win32.SetThreadExecutionState(Native.Win32.ES_CONTINUOUS | Native.Win32.ES_SYSTEM_REQUIRED)
            );
        }

        /// <summary>
        /// Starts the backup client and performs the actions specified by the settings in the options sent to the constructor.
        /// </summary>
        public void Start(BackupOptions options)
        {
            CloudStorageAccount account;
            bool bOptionsValidated = true;

            if (options == null) throw new System.ArgumentNullException("Options cannot be null");

            // Set default options, most are set in BackupOptions
            if (options.Include == null) options.Include = new List<string>();
            if (options.Exclude == null) options.Exclude = new List<string>();
            if (options.Threads <= 0) options.Threads = System.Environment.ProcessorCount;

            // Cloud account from commandline or config file
            if (!String.IsNullOrEmpty(options.Account))
            {
                account = CloudStorageAccount.Parse(options.Account);
            }
            else
            {
                account = CloudStorageAccount.FromConfigurationSetting("AccountConnectionString");
            }

            // Validate supported action
            if (!(options.Backup || options.Restore || options.Clean || options.List || options.Delete))
            {
                Console.WriteLine("No action specified.");
                Console.WriteLine("Type --help for list of options.");
                bOptionsValidated = false;
            }

            // Validate destination container option
            if ((options.Backup || options.Restore || options.Clean || options.Delete)
              && String.IsNullOrEmpty(options.DestinationContainer))
            {
                Console.WriteLine("Destination container (-d, --destination) is required for this action.");
                Console.WriteLine("Type --help for list of options.");
                bOptionsValidated = false;
            }

            // Validate local source option
            if ((options.Backup || options.Restore || options.Clean)
             && String.IsNullOrEmpty(options.SourcePath))
            {
                Console.WriteLine("Local source path (-s, --source) is required for this action");
                Console.WriteLine("Type --help for list of options.");
                bOptionsValidated = false;
            }

            // Execute action
            if (bOptionsValidated)
            {
                Console.WriteLine("Using account {0}, base URI {1}, container name {2}.", account.Credentials.AccountName, account.BlobEndpoint, options.DestinationContainer);

                if (options.Backup) Backup(account, options);
                else if (options.Restore) Restore(account, options);
                else if (options.Clean) Clean(account, options);
                else if (options.List) List(account, options);
                else if (options.Delete) Delete(account, options);
                else Console.WriteLine("Invalid commandline arguments");
            }
        }

        /// <summary>
        /// Gets a CloudBlobContainer reference to the specified container.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        private CloudBlobContainer GetContainerReference(CloudBlobClient client, string containerName)
        {
            CloudBlobContainer container = client.GetContainerReference(containerName);
            container.Metadata["Name"] = containerName;

            // Create the container if it does not exist.
            try
            {
                if (container.CreateIfNotExist())
                {
                    BlobContainerPermissions permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Off;
                    container.SetPermissions(permissions);
                }
            }
            catch {}

            return container;
        }

        /// <summary>
        /// Performs a backup from the local path in options.SourcePath to the cloud container in options.DestinationPath
        /// </summary>
        /// <param name="account">Cloud account</param>
        private void Backup(CloudStorageAccount account, BackupOptions options)
        {
            string sourcePath = options.SourcePath;
            if (!sourcePath.EndsWith("\\")) sourcePath += "\\";

            List<string> include = options.Include;
            List<string> exclude = options.Exclude;
            bool verbose = options.Verbose;
            bool overwrite = options.Overwrite;
            int sourcelen = sourcePath.Length;
            int files = 0;

            Console.WriteLine("Backup started at {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
 
            // Get files to backup
            List<string> fileNames = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories)     // List files
                .Where(                                                                                   // Exclude, include file extensions
                   filename =>
                   {
                        string ext = Path.GetExtension(filename);
                        return !exclude.Contains(ext, StringComparer.OrdinalIgnoreCase) && (include.Count == 0 || include.Contains(ext, StringComparer.OrdinalIgnoreCase));
                   }
                ).ToList<string>();

            if (options.Verbose) Console.WriteLine("Backing up a total of {0} files", fileNames.Count);

            // Backup files in parallel
            Parallel.ForEach(
               fileNames,                                                                                                           // Worker source
               new ParallelOptions() { MaxDegreeOfParallelism = options.Threads },                                                  // Limit worker threads
               () => new LocalState(){Counter = 0, Container = GetContainerReference(account.CreateCloudBlobClient(), options.DestinationContainer)}, // Local state per worker thread
               (filename, state, local) =>                                                                                          // Body to execute in parallel
               {
                   if (BackupFile(local.Container, sourcePath, filename.Substring(sourcelen), overwrite, verbose)) local.Counter++;
                   return local;
               },
               local => { Interlocked.Add(ref files, local.Counter); }
            );

            Console.WriteLine("Backup completed at {0} {1} with {2} files uploaded", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), files);
        }

        /// <summary>
        /// Backs up and individual file to the cloud container
        /// </summary>
        /// <param name="container">The cloud container</param>
        /// <param name="rootPath">The local root path (directory path)</param>
        /// <param name="relativePath">The file path relative to the root path</param>
        private bool BackupFile(CloudBlobContainer container, string rootPath, string relativePath, bool overwrite, bool verbose)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(rootPath + relativePath);
                if (verbose) Console.WriteLine("Backing up file {0} ({1:N0} kB): ", relativePath, fileInfo.Length / 1024);

                CloudBlob blob = container.GetBlobReference(relativePath);

                if (!overwrite)
                {
                    try
                    {
                        // Fetch attributes so we can get last modified date, this call actually throws exception if blob does not exist
                        blob.FetchAttributes();             
                        
                        // No backup if not modified
                        if (fileInfo.LastWriteTimeUtc <= blob.Properties.LastModifiedUtc)
                        {
                            if (verbose) Console.WriteLine("File {0} unchanged, not uploaded", relativePath);
                            return false;
                        }
                    }
                    catch(StorageClientException e) 
                    {
                        if (e.ErrorCode != StorageErrorCode.ResourceNotFound) throw e;
                    }
                }

                blob.Properties.ContentType = MimeTypes.Mapping[Path.GetExtension(relativePath)];

                BlobRequestOptions requestOptions = new BlobRequestOptions()
                { 
                    Timeout = CalcTimeout(fileInfo.Length, Direction.Up)
                };

                DateTime start = DateTime.Now;
                using (FileStream fs = File.Open(rootPath + relativePath, FileMode.Open, FileAccess.Read))
                {
                    blob.UploadFromStream(fs, requestOptions);
                }

                if (verbose) Console.WriteLine("File {0} uploaded at {1:N0} kB/s", relativePath, fileInfo.Length / 1024 / DateTime.Now.Subtract(start).TotalMilliseconds * 1000);
  
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while backing up file {0}: {1}", rootPath + relativePath, ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Restores all the blobs in the container specified by options.DestinationContainer to the local filesystem path in options.SourcePath
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        private void Restore(CloudStorageAccount account, BackupOptions options)
        {
            string restorePath = options.SourcePath;
            List<string> include = options.Include;
            List<string> exclude = options.Exclude;
            bool verbose = options.Verbose;
            Object lck = new Object();
            int restored = 0;

            Console.WriteLine("Restore started at {0} {1}",DateTime.Now.ToShortDateString(),DateTime.Now.ToLongTimeString());

            CloudBlobContainer container = GetContainerReference(account.CreateCloudBlobClient(), options.DestinationContainer);
            if (!restorePath.EndsWith("\\")) restorePath += "\\";
            
            // Get blobs and restore in parallel
            Parallel.ForEach(
               container.ListBlobs(new BlobRequestOptions() { UseFlatBlobListing = true })
                    .Where(
                        b =>
                        {
                            string ext = Path.GetExtension(((CloudBlob)b).Name);
                            return !exclude.Contains(ext, StringComparer.OrdinalIgnoreCase) && (include.Count == 0 || include.Contains(ext, StringComparer.OrdinalIgnoreCase));
                        }
                ),
               new ParallelOptions() { MaxDegreeOfParallelism = options.Threads },
               () => new LocalState(){Counter = 0, Client = account.CreateCloudBlobClient()},
               (bp, state, local) =>
               {
                   // Blob instance using our separate worker client 
                   CloudBlob blob = new CloudBlob(bp.Uri.ToString(), local.Client);

                   // Send along size to avoid having to do another request for filling properties
                   long length = ((CloudBlob)bp).Properties.Length;
                   if (RestoreFile(blob, length, restorePath, verbose)) local.Counter++;
                   return local;
               },
               local => { Interlocked.Add(ref restored, local.Counter); }
            );

            Console.WriteLine("Restore completed at {0} {1} with {2} blobs downloaded", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), restored);
        }

        /// <summary>
        /// Restores a blob to the local filesystem
        /// </summary>
        /// <param name="blob">The blob to download and write to local file</param>
        /// <param name="length">The size of the blob in bytes</param>
        /// <param name="destination">The local destination path</param>
        /// <returns>True if it successfully downloaded and saved the blob, false otherwise</returns>
        private bool RestoreFile(CloudBlob blob, long length, string destination, bool verbose)
        {
            try
            {
                if (verbose) Console.WriteLine("Restoring blob {0} ({1} kB)", blob.Name, length / 1024);
                
                if (!Directory.Exists(Path.GetDirectoryName(destination + blob.Name)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(destination + blob.Name));
                }

                BlobRequestOptions requestOptions = new BlobRequestOptions()
                {
                    Timeout = CalcTimeout(length, Direction.Down)
                };

                DateTime start = DateTime.Now;
                using (FileStream fs = File.Open(destination + blob.Name, FileMode.Create))
                {
                    blob.DownloadToStream(fs, requestOptions);
                }

                if (verbose) Console.WriteLine("Blob {0} downloaded at {1:N0} kB/s", blob.Name, length / 1024 / DateTime.Now.Subtract(start).TotalMilliseconds * 1000);

                return true;
            }
            catch (Exception ex)
            {
                if (verbose) Console.WriteLine("Error restoring blob {0} {1}", blob.Name, ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Deletes the container referenced in options.DestinationContainer
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        private void Delete(CloudStorageAccount account, BackupOptions options)
        {
            CloudBlobContainer container = GetContainerReference(account.CreateCloudBlobClient(), options.DestinationContainer);

            Console.WriteLine("This will delete the entire container ({0})", options.DestinationContainer); 
            Console.WriteLine("Do you want to continue? [yes|no|n]: ");

            if (Console.ReadLine().Trim().ToLower() == "yes")
            {
                container.Delete();
                Console.WriteLine("Container deleted !");
            }
            else Console.WriteLine("Cancelled!");
        }

        /// <summary>
        /// Lists the blobs in the container specified in options.DestinationContainer
        /// or the containers in the root if options.DestinationContainer is empty or "/"
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        private void List(CloudStorageAccount account, BackupOptions options)
        {
            if (String.IsNullOrEmpty(options.DestinationContainer) || options.DestinationContainer == "/")
            {
                ListContainers(account, options);
            }
            else
            {
                ListBlobs(account, options);
            }
        }

        /// <summary>
        /// Lists the blobs in the container specified in options.DestinationContainer
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        private void ListBlobs(CloudStorageAccount account, BackupOptions options)
        {
            List<string> include = options.Include;
            List<string> exclude = options.Exclude;

            try
            {
                Console.SetBufferSize(200, Console.BufferHeight);
            }
            catch { }

            int no = 0;

            CloudBlobContainer container = GetContainerReference(account.CreateCloudBlobClient(), options.DestinationContainer);

            // enumerate all the blobs
            foreach (
                CloudBlob bp in container.ListBlobs(new BlobRequestOptions() { UseFlatBlobListing = true })
                .Where(
                     b =>
                     {
                         string ext = Path.GetExtension(((CloudBlob)b).Name);
                         return !exclude.Contains(ext, StringComparer.OrdinalIgnoreCase) && (include.Count == 0 || include.Contains(ext, StringComparer.OrdinalIgnoreCase));
                     }
                )
            )
            {
                Console.WriteLine(
                    String.Format("{0, -60}{1, 20}", // {2, 50}{3, 40}
                        bp.Name, 
                        String.Format("{0} kB", bp.Properties.Length / 1024)
                        // ,bp.Properties.LastModifiedUtc,
                        // bp.Properties.ContentType, 
                        // (!String.IsNullOrEmpty(bp.Properties.ContentMD5) ? String.Format("MD5:{0}", bp.Properties.ContentMD5) : "")
                    )
                );
                no++;
            }

            Console.WriteLine("Total: {0} files", no);
        }

        /// <summary>
        /// Lists all containers on the account
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        private void ListContainers(CloudStorageAccount account, BackupOptions options)
        {
            List<string> include = options.Include;
            List<string> exclude = options.Exclude;

            try
            {
                Console.SetBufferSize(200, Console.BufferHeight);
            }
            catch { }

            int no = 0;

            CloudBlobClient client = account.CreateCloudBlobClient();

            // Enumerate all the containers
            foreach (CloudBlobContainer bp in client.ListContainers())
            {
                Console.WriteLine(
                    String.Format("{0, -60}{1, 50}",
                        bp.Name,
                        bp.Properties.LastModifiedUtc
                    )
                );
                no++;
            }

            Console.WriteLine("Total: {0} files", no);
        }

        /// <summary>
        /// Cleans the container specified in options.DestinationContainer. The local source is checked against the cloud folder, 
        /// if the file is not available locally in options.SourcePath it is also deleted in the cloud container options.DestinationContainer
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        private void Clean(CloudStorageAccount account, BackupOptions options)
        {
            string sourcePath = options.SourcePath;
            List<string> include = options.Include;
            List<string> exclude = options.Exclude;

            if (!sourcePath.EndsWith("\\")) sourcePath += "\\";

            int files = 0;

            CloudBlobContainer container = GetContainerReference(account.CreateCloudBlobClient(), options.DestinationContainer);

            Parallel.ForEach(
               container.ListBlobs(new BlobRequestOptions() { UseFlatBlobListing = true })
                    .Where(
                        b =>
                        {
                            string ext = Path.GetExtension(((CloudBlob)b).Name);
                            return !exclude.Contains(ext, StringComparer.OrdinalIgnoreCase) && (include.Count == 0 || include.Contains(ext, StringComparer.OrdinalIgnoreCase));
                        }
                ),
               new ParallelOptions() { MaxDegreeOfParallelism = options.Threads },
               () => 0,
               (bp, state, local) =>
               {
                   CloudBlob blob = (CloudBlob)bp;
                   if (!File.Exists(sourcePath + blob.Name)) // File does not exist locally so delete it in the backup.
                   {
                       if (options.Verbose) Console.Write(" Backup of {0} ({1} kbytes) ", blob.Name, blob.Properties.Length / 1024);

                       blob.Delete();

                       if (options.Verbose) Console.WriteLine(" deleted.");
                       local++;
                   }

                   return local;
               },
               local => { Interlocked.Add(ref files, local); }
            );

            Console.WriteLine("{0} file(s) deleted from backup.", files);
        }

        /// <summary>
        /// Calculates service timeout for a download or upload operation
        /// </summary>
        /// <param name="size">size of file in bytes</param>
        /// <param name="direction">upload or download direction</param>
        /// <returns>A timespan with the number of seconds calculated</returns>
        private TimeSpan CalcTimeout(long size, Direction direction)
        {
            float speed;
            double seconds;

            if (direction == Direction.Up) speed = uploadSpeed;
            else speed = downloadSpeed;

            // Calculate theoretical time and multiply by 5 to be on the safe side.
            seconds = Math.Round((size * 8) / (speed * 1024 * 1024) * 5);
            if (seconds <= 0) seconds = 1;

            return TimeSpan.FromSeconds(seconds);
        }
    }
}
