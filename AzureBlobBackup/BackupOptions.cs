/*
 * File: BackupOptions.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Represents the command line options for the AzureBlobBackup utility.
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommandLine;
using CommandLine.Text;

namespace AzureBlobBackup
{
    /// <summary>
    /// Class representing the commandline options. 
    /// To be used with the CommandLine Parser library from http://commandline.codeplex.com/
    /// </summary>
    public class BackupOptions : CommandLineOptionsBase
    {
          [Option("s", "source", DefaultValue = "", HelpText = "Local source directory path")]
          public string SourcePath { get; set; }

          [Option("d", "destination", DefaultValue = "", HelpText = "Destination container on Azure Blob Storage. For example -d backup")]
          public string DestinationContainer { get; set; }

          [OptionList("i", "include",Separator=';',HelpText = "List of file extensions to include separated by semicolon. For example -i .jpg;.css;.html")]
          public List<string> Include { get; set; }

          [OptionList("e", "exclude", Separator = ';', HelpText = "List of file extensions to exclude separated by semicolon. For example -e .log;.db;.ini")]
          public List<string> Exclude { get; set; }

          [Option("b", "backup", MutuallyExclusiveSet = "bclr",HelpText = "Start a backup of files from local source to destination container")]
          public bool Backup { get; set; }

          [Option("c", "clean", MutuallyExclusiveSet = "bclr", HelpText = "Clean destination container if file is not in local source folder")]
          public bool Clean { get; set; }

          [Option("l", "list", MutuallyExclusiveSet = "bclr", HelpText = "List the destination container")]
          public bool List { get; set; }

          [Option("r", "restore", MutuallyExclusiveSet = "bclr", HelpText = "Restores files from destination container to local source directory")]
          public bool Restore { get; set; }

          [Option("v", "verbose", HelpText = "Print details during execution.")]
          public bool Verbose { get; set; }

          [Option("t", "threads", DefaultValue = 5, HelpText = "Limit number of worker threads, default set to the number of cores on the system")]
          public int Threads { get; set; }

          [Option("a", "account", DefaultValue = "", HelpText = "Account connection string to use, overrides default in config file.")]
          public string Account { get; set; }

          [Option("o", "overwrite", HelpText = "Overwrites the backup without checking last modified date.")]
          public bool Overwrite { get; set; }

          [Option(null, "delete", MutuallyExclusiveSet = "bclr", HelpText = "Deletes destination container (including blobs in it). Requires confirmation.")]
          public bool Delete { get; set; }

          [HelpOption]
          public string GetUsage()
          {
              var help = new HelpText
              {
                  Heading = new HeadingInfo("AzureBackup.exe", "Azure Blob Backup Utility"),
                  AdditionalNewLineAfterOption = true,
                  AddDashesToOption = true
              };

              help.AddPreOptionsLine("");
              help.AddPreOptionsLine("Usage: AzureBackup.exe -b -s <source path> -d <container>");
              help.AddOptions(this);
              return help;
          }
    }
}
