using EmployeeManagement.Classes;
using EmployeeManagement.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EmployeeManagement
{
    /// <summary>
    /// Main Form for Program.
    /// </summary>
    public partial class frmMain : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor for frmMain.
        /// Run Splash Screen. Load/setup dgvTable.
        /// </summary>
        public frmMain()
        {
            try
            {
                InitializeComponent();
                RunSplash();
                // get a list of employees from the db ordered by last,first names
                // and set it to the datasource of dgvTable
                dgvTable.DataSource = DbFunctions.GetListOfEmployeesFromDB().OrderBy(p => p.LastName)
                                                                             .ThenBy(p => p.FirstName).ToList();
                //don't show row headers
                dgvTable.RowHeadersVisible = false;
                //make column headers bold         
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font(dgvTable.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                //Hide These Columns
                //We still want to use them - but no need to show them
                dgvTable.Columns["ID"].Visible = false;
                dgvTable.Columns["FirstName"].Visible = false;
                dgvTable.Columns["MiddleName"].Visible = false;
                dgvTable.Columns["LastName"].Visible = false;
                //give these column headers more user friendly names
                dgvTable.Columns["FullName"].HeaderText = "Full Name";
                dgvTable.Columns["JobTitle"].HeaderText = "Job Title";
            }
            catch (Exception ex)
            {
                // I don't anticipate an error here but just in case, we'll log it
                LogFunctions.LogException(ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Runs the splash screen on a different thread for better responsiveness.
        /// </summary>
        private void RunSplash()
        {
            ////Splash Screen ran on different thread because it was not responsive (displaying dots & animation correctly)
            new Thread(new ThreadStart(() =>
            {
                Application.Run(new frmSplash());

            })).Start();
        }

        /// <summary>
        /// Ensures employee is selected in dgvTable and visible to the user.
        /// </summary>
        /// <param name="employeeIn">The employee to select and ensure visible.</param>
        public void EnsureEmployeeIsSelectedAndVisible(Employee employeeIn)
        {
            try
            {
                foreach (DataGridViewRow dgvr in dgvTable.Rows)
                {
                    if (((Employee)dgvr.DataBoundItem).ID == employeeIn.ID)
                    {
                        dgvr.Selected = true;
                        dgvTable.FirstDisplayedScrollingRowIndex = dgvr.Index;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }

        /// <summary>
        /// Search Datagridview and find the best employee match to Search text.
        /// </summary>
        private void SearchDataGridAndSelectBestMatch()
        {
            try
            {
                //initialize search results to entire list
                List<Employee> lstEmployeeSearch = (List<Employee>)dgvTable.DataSource;

                //split search string into each word and search for the presence of any/all them            
                foreach (string strSearch in txtSearch.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //if less than 4 characters and not an integer search last names that start with the characters
                    if (txtSearch.Text.Length < 4 && !int.TryParse(PrepStringForComparing(txtSearch.Text), out _))
                    {
                        lstEmployeeSearch = lstEmployeeSearch.Where(p =>
                                            PrepStringForComparing(p.LastName)
                                            .StartsWith(PrepStringForComparing(strSearch))).ToList();
                    }
                    else
                    {
                        //enables you to search by any combination of fields except photo
                        lstEmployeeSearch = lstEmployeeSearch.Where(p =>
                                            PrepStringForComparing(p.LastName + p.FirstName + p.MiddleName + p.Phone + p.Email + p.JobTitle)
                                            .Contains(PrepStringForComparing(strSearch))).ToList();
                    }

                    if (lstEmployeeSearch.Count() > 0)
                    {
                        EnsureEmployeeIsSelectedAndVisible(lstEmployeeSearch.First());
                    }
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }

        /// <summary>
        /// Prepare string for comparing to another string during the employee search. 
        /// Convert to Lower case and remove - ( ) . characters.
        /// </summary>
        /// <param name="stringIn">The string to prepare.</param>
        /// <returns>The prepared string.</returns>
        private string PrepStringForComparing(string stringIn)
        {
            return stringIn.ToLower().Replace("-", "").Replace("(", "").Replace(")", "").Replace(".", "").Trim();
        }

        /// <summary>
        /// Copy the selected employee's name, job title, phone, email to clipboard.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void CopyToClipboard(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.SelectedRows.Count > 0)
                {
                    Employee employeeToCopy = (Employee)(dgvTable.SelectedRows[0].DataBoundItem);

                    Clipboard.SetText(string.Join("\n", employeeToCopy.FullName,
                                                        employeeToCopy.JobTitle,
                                                        employeeToCopy.Phone,
                                                        employeeToCopy.Email,
                                                        ""));
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }
        /// <summary>
        /// Handles mnuEmailEmployee.Click, btnEmailEmployee.click events.
        /// If email is valid, Starts up default email client with employee email as the recipient.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void EmailSelectedEmployee(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.SelectedRows.Count > 0 &&
                    Validation.IsValidEmail(((Employee)dgvTable.SelectedRows[0].DataBoundItem).Email))
                {
                    //email with default email app
                    _ = Process.Start($"mailto:{((Employee)dgvTable.SelectedRows[0].DataBoundItem).Email}");
                }
                else
                {
                    _ = MessageBox.Show("Please select an Employee with a valid Email address first.",
                                        "Select an Employee with an Email",
                                        MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                _ = MessageBox.Show("A problem occured opening the email application.",
                                    "Email Unsuccessful",
                                    MessageBoxButtons.OK);
            }
        }

        #endregion

        #region frmMain Event Handlers

        /// <summary>
        /// Handler for frmMain.Shown event.
        /// Give focus to frmMain as soon as it is shown for the first time.
        /// This ensures it will take focus away from the frmSplash.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            //give focus to this form away from splash screen
            this.Activate();
        }

        #endregion

        #region Button and Right-Click Menu Event Handlers

        /// <summary>
        /// Handles mnuAddEmployee.Click and btnAddEmployee.click events.
        /// Adds employee to the datagridview and database.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void AddEmployee(object sender, EventArgs e)
        {
            try
            {
                using (frmAddEditEmployee frmAddEmployee = new frmAddEditEmployee(new Employee()))
                {
                    frmAddEmployee.Text = "Add Employee";
                    if (frmAddEmployee.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        // add employee to datagridview
                        ((List<Employee>)dgvTable.DataSource).Add(frmAddEmployee.EmployeeToAddOrEdit);

                        //refresh & reorder the list by lastname, firstname
                        dgvTable.DataSource = ((List<Employee>)dgvTable.DataSource).OrderBy(p => p.LastName)
                                                                                    .ThenBy(p => p.FirstName).ToList();

                        EnsureEmployeeIsSelectedAndVisible(frmAddEmployee.EmployeeToAddOrEdit);
                        DbFunctions.AddEmployeeToDB(frmAddEmployee.EmployeeToAddOrEdit);

                        _ = MessageBox.Show(
                               $"'{frmAddEmployee.EmployeeToAddOrEdit.FullName}' was successfully added to the Employee database :)",
                               "Success!",
                               MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles mnuEditEmployee.Click, btnEditEmployee.click, dgvTable.MouseDoubleClick events.
        /// Edits employee in the datagridview and database.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void EditEmployee(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.SelectedRows.Count > 0)
                {
                    Employee employeeToEdit = (Employee)dgvTable.SelectedRows[0].DataBoundItem;

                    using (frmAddEditEmployee frmEditEmployee = new frmAddEditEmployee(employeeToEdit))
                    {
                        frmEditEmployee.Text = "Edit Employee";
                        if (frmEditEmployee.ShowDialog() == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            //refresh & reorder the list by lastname, firstname
                            dgvTable.DataSource = ((List<Employee>)dgvTable.DataSource).OrderBy(p => p.LastName)
                                                                                        .ThenBy(p => p.FirstName).ToList();
                            EnsureEmployeeIsSelectedAndVisible(employeeToEdit);
                            DbFunctions.SaveEmployeeEditsToDB(employeeToEdit);

                            _ = MessageBox.Show(
                                    $"'{employeeToEdit.FullName}' was successfully Edited in the Employee database :)",
                                    "Success!",
                                    MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    _ = MessageBox.Show("Please select an Employee to Edit first.",
                                        "Select an Employee to edit",
                                        MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles mnuDeleteEmployee.Click, btnDeleteEmployee.click events.
        /// Deletes employee from the datagridview and database.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        public void DeleteEmployee(object sender, EventArgs e)
        {
            try
            {
                if (dgvTable.SelectedRows.Count > 0)
                {
                    Employee selectedEmployee = (Employee)dgvTable.SelectedRows[0].DataBoundItem;
                    string employeeName = selectedEmployee.FullName;
                    if (MessageBox.Show($"Are you sure you want to delete '{employeeName}' ?",
                                         "Confirm Delete",
                                         MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        //remove the employee from the datagridview
                        ((List<Employee>)dgvTable.DataSource).Remove(selectedEmployee);

                        //refresh & reorder the list by lastname, firstname
                        dgvTable.DataSource = ((List<Employee>)dgvTable.DataSource).OrderBy(p => p.LastName)
                                                                                    .ThenBy(p => p.FirstName).ToList();
                        //delete the employee from the Azure DB
                        DbFunctions.DeleteEmployeeFromDB(selectedEmployee);

                        _ = MessageBox.Show($"'{employeeName}' was successfully Deleted :)",
                                            "Success!",
                                            MessageBoxButtons.OK);
                    }
                }
                else
                {
                    _ = MessageBox.Show("Please select an Employee to delete first.",
                                        "Select an Employee To Delete",
                                        MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Handler for mnuRightClick event. mnuEmailEmployee is enabled if selected employee has a valid email.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void MnuRightClick_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (dgvTable.SelectedRows.Count > 0)
                {
                    mnuEmailEmployee.Enabled = Validation.IsValidEmail(((Employee)(dgvTable.SelectedRows[0].DataBoundItem)).Email);
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }

        #endregion

        #region DataGridView Event Handlers

        /// <summary>
        /// Event Handler for dgvTable.MouseClick event.
        /// Select employee under right-click. Then show right-click menu.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void DgvTable_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    // make sure the row under a right-click is selected
                    dgvTable.Rows[dgvTable.HitTest(e.X, e.Y).RowIndex].Selected = true;
                    //show the right-click menu
                    mnuRightClick.Show(dgvTable, e.Location, ToolStripDropDownDirection.BelowRight);
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }

        /// <summary>
        /// Handles dgvTable.KeyDown event.
        /// Runs Code depending on what Key is Pressed Down.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void DgvTable_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // edit employee if Enter key is pressed
                    e.Handled = true;
                    EditEmployee(sender, e);
                    break;

                case Keys.Delete:
                    // delete employee if Delete key is pressed
                    e.Handled = true;
                    DeleteEmployee(sender, e);
                    break;

                case Keys.C:
                    if (e.Control == true)
                    {
                        // if CTRL-C pressed, copy employee info to clipboard
                        e.Handled = true;
                        CopyToClipboard(sender, e);
                    }
                    break;

                case Keys.Tab:
                    // if TAB pressed , pass focus to btnAddEmployee
                    // instead of focusing on other cells within the datagridview
                    e.Handled = true;
                    btnAddEmployee.Focus();
                    break;
            }
        }

        #endregion

        #region chkHidePhotos and txtSearch Event Handlers

        /// <summary>
        /// Handles chkHidePhotos.CheckedChanged event.  Hides Photo column.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void ChkHidePhotos_CheckedChanged(object sender, EventArgs e)
        {
            dgvTable.Columns["Photo"].Visible = !chkHidePhotos.Checked;
        }

        /// <summary>
        /// Handles txtSearch.TextChanged event.
        /// Begins new search if txtSearch.Text not null or whitespace.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                if (dgvTable.Rows.Count > 0)
                {
                    dgvTable.Rows[0].Selected = true;
                    dgvTable.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            else
            {
                SearchDataGridAndSelectBestMatch();
            }
        }

        #endregion
    }
}
