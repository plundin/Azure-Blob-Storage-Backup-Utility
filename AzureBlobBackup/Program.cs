/*
 * File: Program.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Main program entry point for the AzureBlobBackup utility.
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Configuration;
using CommandLine;
using CommandLine.Text;

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
            ICommandLineParser parser = new CommandLineParser();

            if (parser.ParseArguments(args, options))
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
