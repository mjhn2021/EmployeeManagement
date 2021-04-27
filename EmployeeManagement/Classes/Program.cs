using EmployeeManagement.Classes;
using System;
using System.Net;
using System.Windows.Forms;
using System.Threading;

namespace EmployeeManagement
{
    /// <summary>
    /// Auto-generated Program class for Windows Forms project with Main sub.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// Checks for any running instances before running frmMain.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                // using a mutex, we can force this to be a single-instance app
                Mutex objMutex = new Mutex(false, "EmployeeManagement");
                //if already running,
                if (objMutex.WaitOne(0, false) == false)
                {
                    //close mutex
                    objMutex.Close();
                    // and terminate process immediately
                    Environment.Exit(1);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }
    }
}

