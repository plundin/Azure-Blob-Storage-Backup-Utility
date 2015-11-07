/*
 * File: Program.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Main program entry point for the AzureBlobBackup utility.
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;

namespace AzureBlobBackup
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">command line arguments</param>
        public static void Main(string[] args)
        {
            // Command line options
            BackupOptions options = new BackupOptions();

            // Command line parser library http://commandline.codeplex.com/
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                try
                {
                    // Create and start backup client with options
                    AzureBackupClient client = new AzureBackupClient();
                    client.Start(options);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else Console.WriteLine(options.GetUsage());
        }
    }
}
