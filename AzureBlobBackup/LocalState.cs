/*
 * File: LocalState.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Class for maintaining local state in parallel loops in AzureBackupClient
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.StorageClient.Protocol;

namespace AzureBlobBackup
{
    /// <summary>
    /// Class for providing local state in parallel for loop.
    /// </summary>
    public class LocalState
    {
        /// <summary>
        /// Account client reference
        /// </summary>
        public CloudBlobClient Client
        {
            get;
            set;
        }

        /// <summary>
        /// Container reference
        /// </summary>
        public CloudBlobContainer Container
        {
            get;
            set;
        }

        /// <summary>
        /// Counter, for example file counter
        /// </summary>
        public int Counter
        {
            get;
            set;
        }
    }
}
