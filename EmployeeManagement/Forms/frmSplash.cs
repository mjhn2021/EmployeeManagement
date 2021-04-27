using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagement
{
    /// <summary>
    /// Splash Form To display while frmMain is Loading.
    /// </summary>
    partial class frmSplash : Form
    {
        /// <summary>
        /// Constructor for frmSplash. Start Timer. Speak Intro.
        /// </summary>
        public frmSplash()
        {
            InitializeComponent();
            //create timer to change number of periods in status string for waiting effect
            Timer tmr = new Timer { Interval = 250 };
            tmr.Tick += new EventHandler(TmrWait_Tick);
            tmr.Start();
            // speak intro
            Speak($"Hello!.... Welcome and Happy {DateTime.Now.DayOfWeek} to you... " +
                   "Thank you for taking the time to review this program..." +
                   "Please wait while I retrieve the employee records from a Microsoft Azure SQL Server Database.");
        }

        /// <summary>
        /// Event Handler for tmrWait.Tick event.
        /// Calculate/set new number of periods to display in lblStatus and refresh.
        /// </summary>
        /// <param name="sender">Sender of Event</param>
        /// <param name="e">Event Parameters</param>
        private void TmrWait_Tick(object sender, EventArgs e)
        {
            //get current number of periods in status text
            int NumberOfPeriods = lblStatus.Text.Split('.').Length - 1;
            // get remainder after dividing by 10, then add 1
            // results in 1,2,3,...,10,1,2,3,...10,1,...(repeating) sequence
            NumberOfPeriods = (NumberOfPeriods % 10) + 1;

            //update status string
            lblStatus.Text = $"Employees Loading from Azure SQL Server DB{new string('.', NumberOfPeriods)}";
            lblStatus.Refresh();
        }

        /// <summary>
        /// Event Handler for frmSplash Deactivate event.
        /// Disposes this form once it loses focus.
        /// </summary>
        /// <param name="sender">Sender of Event</param>
        /// <param name="e">Event Parameters</param>
        private void FrmSplash_Deactivate(object sender, EventArgs e)
        {
            //dispose this form once main form takes focus
            this.Dispose();
        }

        /// <summary>
        /// Speaks a string asynchronously with default speech synthesizer options.
        /// </summary>
        /// <param name="TextToSpeak">A string for speech synthesizer to Speak.</param>
        public async static void Speak(string TextToSpeak)
        {
            // wait for speech to complete before exiting thread
            await Task.Run(() =>
            {
                // run asynchronously so speech occurs while other operations continue 
                (new SpeechSynthesizer()).SpeakAsync(TextToSpeak);
            });
        }
    }
}
