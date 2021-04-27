using System;
using System.IO;
using System.Windows.Forms;

namespace EmployeeManagement.Classes
{
    /// <summary>
    /// Class that contains functions for Logging.
    /// </summary>
    public static class LogFunctions
    {
        /// <summary>
        /// Gets the full path of this application's log file.
        /// A file with same path\filename as the .EXE but with the .LOG extension.
        /// </summary>
        /// <returns>Full path of this application's log file</returns>
        public static string GetLogFileName()
        {
            return Path.ChangeExtension(Application.ExecutablePath, "log");
        }
        /// <summary>
        /// Adds a log entry to this application's log file
        /// </summary>
        /// <param name="LogEntry">String to append to log file.</param>
        public static void AddLogEntry(string logEntry)
        {
            try
            {
                File.AppendAllLines(GetLogFileName(),
                                    new string[] { $"{DateTime.Now}: {logEntry}" });
            }
            catch (Exception ex)
            {
                // just in case there is an issue, show a message box with log entry and exception
                _ = MessageBox.Show($"Could Not Add Log Entry: '{logEntry}'\n{GetExceptionDetails(ex)}",
                                    "Could Not Add Log Entry",
                                    MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Adds a log entry with the details of an exception.
        /// </summary>
        /// <param name="ex">Exception to log details about.</param>
        public static void LogException(Exception ex)
        {
            AddLogEntry(GetExceptionDetails(ex));
        }

        /// <summary>
        /// Returns Exception Details.
        /// </summary>
        /// <param name="ex">Exception to get Details about</param>
        /// <returns>Exception Details including Message, Type and Stack Trace</returns>
        public static string GetExceptionDetails(Exception ex)
        {
            try
            {
                return $"Exception Occurred:\n{ex.Message}\n{ex.GetType()}\nStack Trace:{ex.StackTrace}";
            }
            catch (Exception)
            {
                //just in case
                return "Exception Occurred";
            }

        }
    }
}
