
using System;

namespace EmployeeManagement.Forms
{
    partial class frmAddEditEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditEmployee));
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobTitle = new System.Windows.Forms.TextBox();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBrowseForPictureFile = new System.Windows.Forms.Button();
            this.btnTakePhotoWithCamera = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeletePhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(14, 32);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(112, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Employee Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Location = new System.Drawing.Point(137, 29);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtFirstName.MaxLength = 50;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(134, 24);
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFirstName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Job Title:";
            // 
            // txtJobTitle
            // 
            this.txtJobTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobTitle.Location = new System.Drawing.Point(137, 61);
            this.txtJobTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtJobTitle.MaxLength = 100;
            this.txtJobTitle.Name = "txtJobTitle";
            this.txtJobTitle.Size = new System.Drawing.Size(274, 24);
            this.txtJobTitle.TabIndex = 8;
            this.txtJobTitle.Validating += new System.ComponentModel.CancelEventHandler(this.TxtJobTitle_Validating);
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.BackColor = System.Drawing.Color.White;
            this.pictureBoxPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxPhoto.Location = new System.Drawing.Point(137, 165);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(133, 100);
            this.pictureBoxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPhoto.TabIndex = 8;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(85, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Photo:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(440, 310);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(321, 310);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnBrowseForPictureFile
            // 
            this.btnBrowseForPictureFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBrowseForPictureFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseForPictureFile.ForeColor = System.Drawing.Color.White;
            this.btnBrowseForPictureFile.Location = new System.Drawing.Point(321, 217);
            this.btnBrowseForPictureFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBrowseForPictureFile.Name = "btnBrowseForPictureFile";
            this.btnBrowseForPictureFile.Size = new System.Drawing.Size(198, 27);
            this.btnBrowseForPictureFile.TabIndex = 16;
            this.btnBrowseForPictureFile.Text = "&Browse for Picture File";
            this.btnBrowseForPictureFile.UseVisualStyleBackColor = true;
            this.btnBrowseForPictureFile.Click += new System.EventHandler(this.BtnBrowseForPictureFile_Click);
            // 
            // btnTakePhotoWithCamera
            // 
            this.btnTakePhotoWithCamera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnTakePhotoWithCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakePhotoWithCamera.ForeColor = System.Drawing.Color.White;
            this.btnTakePhotoWithCamera.Location = new System.Drawing.Point(321, 165);
            this.btnTakePhotoWithCamera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTakePhotoWithCamera.Name = "btnTakePhotoWithCamera";
            this.btnTakePhotoWithCamera.Size = new System.Drawing.Size(198, 30);
            this.btnTakePhotoWithCamera.TabIndex = 14;
            this.btnTakePhotoWithCamera.Text = "&Take Photo With Camera";
            this.btnTakePhotoWithCamera.UseVisualStyleBackColor = true;
            this.btnTakePhotoWithCamera.Click += new System.EventHandler(this.BtnTakePhotoWithCamera_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(86, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(137, 124);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(274, 24);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TxtEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Phone Number:";
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(137, 92);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPhone.MaxLength = 100;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(274, 24);
            this.txtPhone.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(409, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "or";
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Location = new System.Drawing.Point(416, 29);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLastName.MaxLength = 50;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(134, 24);
            this.txtLastName.TabIndex = 6;
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLastName_Validating);
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddleName.Location = new System.Drawing.Point(277, 29);
            this.txtMiddleName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(134, 24);
            this.txtMiddleName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(137, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "First:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(277, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Middle:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(416, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Last:";
            // 
            // btnDeletePhoto
            // 
            this.btnDeletePhoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDeletePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePhoto.ForeColor = System.Drawing.Color.White;
            this.btnDeletePhoto.Location = new System.Drawing.Point(321, 244);
            this.btnDeletePhoto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(112, 27);
            this.btnDeletePhoto.TabIndex = 17;
            this.btnDeletePhoto.Text = "&Delete Photo";
            this.btnDeletePhoto.UseVisualStyleBackColor = true;
            this.btnDeletePhoto.Click += new System.EventHandler(this.BtnDeletePhoto_Click);
            // 
            // frmAddEditEmployee
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(566, 354);
            this.Controls.Add(this.btnDeletePhoto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnTakePhotoWithCamera);
            this.Controls.Add(this.btnBrowseForPictureFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJobTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmAddEditEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Employee";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobTitle;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBrowseForPictureFile;
        private System.Windows.Forms.Button btnTakePhotoWithCamera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeletePhoto;
    }
}