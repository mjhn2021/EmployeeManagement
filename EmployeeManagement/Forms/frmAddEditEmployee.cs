using EmployeeManagement.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeManagement.Forms
{
    /// <summary>
    /// A form for Adding or Editing employees.
    /// </summary>
    public partial class frmAddEditEmployee : Form
    {
        #region Properties

        /// <summary>
        /// The employee to Add or Edit.
        /// </summary>
        public Employee EmployeeToAddOrEdit { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for frmAddEditEmployee.
        /// Set EmployeeToAddOrEdit and all fields.
        /// </summary>
        /// <param name="employeeIn">The employee to Add or Edit.</param>
        public frmAddEditEmployee(Employee employeeIn)
        {
            try
            {
                InitializeComponent();
                // set EmployeeToAddOrEdit property
                this.EmployeeToAddOrEdit = employeeIn;
                // set all text fields
                txtFirstName.Text = this.EmployeeToAddOrEdit.FirstName;
                txtMiddleName.Text = this.EmployeeToAddOrEdit.MiddleName;
                txtLastName.Text = this.EmployeeToAddOrEdit.LastName;
                txtJobTitle.Text = this.EmployeeToAddOrEdit.JobTitle;
                txtPhone.Text = this.EmployeeToAddOrEdit.Phone;
                txtEmail.Text = this.EmployeeToAddOrEdit.Email;
                pictureBoxPhoto.Image = ImageFunctions.GetImageFromByteArray(this.EmployeeToAddOrEdit.Photo);
                // store the byte array of the photo in the tag of pictureBoxPhoto
                pictureBoxPhoto.Tag = this.EmployeeToAddOrEdit.Photo;
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Checks to see if FirstName, LastName, JobTitle, Email fields are valid.
        /// </summary>
        /// <returns>True if all fields are valid. False if any field is invalid.</returns>
        private bool ValuesAreValid()
        {
            List<string> lstIssues = new List<string>();
            // if not valid,
            // make textboxes background red in case user skipped textbox before trying to save
            // and add to list of issues
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.PaleVioletRed;
                lstIssues.Add("Please assign a First Name to this employee.");
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                txtLastName.BackColor = Color.PaleVioletRed;
                lstIssues.Add("Please assign a Last Name to this employee.");
            }
            if (string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                txtJobTitle.BackColor = Color.PaleVioletRed;
                lstIssues.Add("Please assign a Job Title to this employee.");
            }
            if (!(string.IsNullOrWhiteSpace(txtEmail.Text) || Validation.IsValidEmail(txtEmail.Text)))
            {
                txtEmail.BackColor = Color.PaleVioletRed;
                lstIssues.Add("Please assign a valid Email to this employee or leave the email field blank.");
            }
            if (lstIssues.Count > 0)
                _ = MessageBox.Show(string.Join("\n", lstIssues),
                                    "Issues Found",
                                    MessageBoxButtons.OK);

            return (lstIssues.Count == 0);
        }

        #endregion

        #region Button Click Events

        /// <summary>
        /// Event Handler for btnSave.Click event.
        /// Checks to see if values are valid before saving and returning control back to the calling form.
        /// </summary>
        /// <param name="sender">Sender of Event</param>
        /// <param name="e">Event Arguments</param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValuesAreValid())
                {
                    this.EmployeeToAddOrEdit.FirstName = txtFirstName.Text;
                    this.EmployeeToAddOrEdit.MiddleName = txtMiddleName.Text;
                    this.EmployeeToAddOrEdit.LastName = txtLastName.Text;
                    this.EmployeeToAddOrEdit.FullName = $"{txtLastName.Text}, {txtFirstName.Text} {txtMiddleName.Text}".Trim();
                    this.EmployeeToAddOrEdit.JobTitle = txtJobTitle.Text;
                    this.EmployeeToAddOrEdit.Phone = txtPhone.Text;
                    this.EmployeeToAddOrEdit.Email = txtEmail.Text;
                    this.EmployeeToAddOrEdit.Photo = (byte[])pictureBoxPhoto.Tag;

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                LogFunctions.LogException(ex);
            }
        }

        /// <summary>
        /// Event Handler for the btnCancel.Click event.
        /// Returns Cancel DialogResult and control back to calling form.
        /// No employee edits are saved.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Event Handler for btnDeletePhoto.Click event.
        /// Sets pictureBoxPhoto Image and Tag(byte array) properties to null.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void BtnDeletePhoto_Click(object sender, EventArgs e)
        {
            pictureBoxPhoto.Image = null;
            pictureBoxPhoto.Tag = null;
        }

        /// <summary>
        /// Event Handler for btnTakePhotoWithCamera.Click event.
        /// Get Webcam Image. Set pictureBoxPhoto Image and Tag to bytearray of Image.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void BtnTakePhotoWithCamera_Click(object sender, EventArgs e)
        {
            Bitmap webcamBitmap = ImageFunctions.GetBitmapFromWebcam();
            // if null, there was a problem getting webcamBitmap
            // if not null, set pictureBoxPhoto Image and Tag
            if (webcamBitmap != null)
            {
                pictureBoxPhoto.Image = webcamBitmap;
                pictureBoxPhoto.Tag = ImageFunctions.GetByteArrayFromBitMapImage(webcamBitmap);
            }
        }

        /// <summary>
        /// Event Handler for BtnBrowseForPictureFile.Click event.
        /// Browse for Picture file and set pictureBoxPhoto Image and Tag(byte array). 
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void BtnBrowseForPictureFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Title = "Browse for a Picture File";
                // browse for the file
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // get image from file
                        Image img = Image.FromFile(ofd.FileName);
                        // resize image so that height=100
                        pictureBoxPhoto.Image = ImageFunctions.ResizeImage(img, (int)(100.0m * img.Width / img.Height), 100);
                        // set tag to byte array of image in bitmap format
                        pictureBoxPhoto.Tag = ImageFunctions.GetByteArrayFromBitMapImage(pictureBoxPhoto.Image);
                    }
                    catch (Exception ex)
                    {
                        LogFunctions.LogException(ex);
                        _ = MessageBox.Show("A problem occurred while loading the photo from the file.",
                                            "Invalid Photo File",
                                            MessageBoxButtons.OK);
                    }
                }
            }
        }

        #endregion

        #region TextBox Validating Events

        /// <summary> 
        /// Handles txtEmail.Validating event. Validates Email field.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void TxtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // trim off any extra spaces
            txtEmail.Text = txtEmail.Text.Trim();
            // email field must be blank or contain a valid email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || Validation.IsValidEmail(txtEmail.Text))
            {
                txtEmail.BackColor = SystemColors.Window;
            }
            else
            {
                //color background PaleVioletRed if not valid
                txtEmail.BackColor = Color.PaleVioletRed;
            }
        }

        /// <summary>
        /// Handles txtFirstName.Validating event. Validates FirstName field if not blank.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void TxtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //trim off extra spaces
            txtFirstName.Text = txtFirstName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                //color background PaleVioletRed if not valid
                txtFirstName.BackColor = Color.PaleVioletRed;
            }
            else
            {
                txtFirstName.BackColor = SystemColors.Window;
            }
        }

        /// <summary>
        /// Handles txtLastName.Validating event. Validates LastName field if not blank.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void TxtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //trim off extra spaces
            txtLastName.Text = txtLastName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                //color background PaleVioletRed if not valid
                txtLastName.BackColor = Color.PaleVioletRed;
            }
            else
            {
                txtLastName.BackColor = SystemColors.Window;
            }
        }

        /// <summary>
        /// Handles txtJobTitle.Validating event. Validates JobTitle field if not blank.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Event arguments</param>
        private void TxtJobTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //trim off extra spaces
            txtJobTitle.Text = txtJobTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                //color background PaleVioletRed if not valid
                txtJobTitle.BackColor = Color.PaleVioletRed;
            }
            else
            {
                txtJobTitle.BackColor = SystemColors.Window;
            }
        }
        #endregion
    }
}
