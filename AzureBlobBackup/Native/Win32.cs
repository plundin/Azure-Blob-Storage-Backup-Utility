/*
 * File: Win32Native.cs
 * Author: Patrik Lundin, patrik@lundin.info
 * 
 * Provides methods for flagging to Windows that the program needs to run interrupted,
 * see http://msdn.microsoft.com/en-us/library/aa373208%28v=vs.85%29.aspx
 * 
 * Released under the Microsoft Public License (Ms-PL) http://www.microsoft.com/en-us/openness/licenses.aspx
*/
using System;
using System.Runtime.InteropServices;

namespace AzureBlobBackup.Native
{
    /// <summary>
    /// Provides access to native win32 methods
    /// </summary>
    public static class Win32
    {
        /// <summary>
        /// Enables an application to inform the system that it is in use, thereby preventing the system from entering sleep or turning off the display while the application is running.
        /// see http://msdn.microsoft.com/en-us/library/aa373208%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="esFlags">One or more flags</param>
        /// <returns>Previous execution state or 0 if failed</returns>
        [DllImport("kernel32.dll")]
        public static extern uint SetThreadExecutionState(uint esFlags);

        /// <summary>
        /// Informs the system that the state being set should remain in effect until the next call that uses ES_CONTINUOUS and one of the other state flags is cleared.
        /// </summary>
        public const uint ES_CONTINUOUS = 0x80000000;

        /// <summary>
        /// Forces the system to be in the working state by resetting the system idle timer.
        /// </summary>
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
    }
}
