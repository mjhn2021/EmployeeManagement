
namespace EmployeeManagement
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.mnuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEmailEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.chkHidePhotos = new System.Windows.Forms.CheckBox();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.btnEmailEmployee = new System.Windows.Forms.Button();
            this.btnEditEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.mnuRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Ebrima", 9.75F);
            this.txtSearch.Location = new System.Drawing.Point(12, 85);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(417, 25);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.Black;
            this.lblSearch.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(9, 68);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(142, 17);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Search Employee List:";
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTable.Location = new System.Drawing.Point(12, 114);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTable.Size = new System.Drawing.Size(792, 449);
            this.dgvTable.TabIndex = 8;
            this.dgvTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvTable_KeyDown);
            this.dgvTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvTable_MouseClick);
            this.dgvTable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EditEmployee);
            // 
            // mnuRightClick
            // 
            this.mnuRightClick.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddEmployee,
            this.mnuEditEmployee,
            this.mnuDeleteEmployee,
            this.toolStripSeparator1,
            this.mnuEmailEmployee,
            this.mnuCopyToClipboard});
            this.mnuRightClick.Name = "mnuRightClick";
            this.mnuRightClick.Size = new System.Drawing.Size(173, 120);
            this.mnuRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.MnuRightClick_Opening);
            // 
            // mnuAddEmployee
            // 
            this.mnuAddEmployee.Image = global::EmployeeManagement.Properties.Resources.plusplus;
            this.mnuAddEmployee.Name = "mnuAddEmployee";
            this.mnuAddEmployee.Size = new System.Drawing.Size(172, 22);
            this.mnuAddEmployee.Text = "&Add Employee";
            this.mnuAddEmployee.Click += new System.EventHandler(this.AddEmployee);
            // 
            // mnuEditEmployee
            // 
            this.mnuEditEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditEmployee.Image")));
            this.mnuEditEmployee.Name = "mnuEditEmployee";
            this.mnuEditEmployee.Size = new System.Drawing.Size(172, 22);
            this.mnuEditEmployee.Text = "&Edit Employee";
            this.mnuEditEmployee.Click += new System.EventHandler(this.EditEmployee);
            // 
            // mnuDeleteEmployee
            // 
            this.mnuDeleteEmployee.Image = global::EmployeeManagement.Properties.Resources.disagree;
            this.mnuDeleteEmployee.Name = "mnuDeleteEmployee";
            this.mnuDeleteEmployee.Size = new System.Drawing.Size(172, 22);
            this.mnuDeleteEmployee.Text = "&Delete Employee";
            this.mnuDeleteEmployee.Click += new System.EventHandler(this.DeleteEmployee);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // mnuEmailEmployee
            // 
            this.mnuEmailEmployee.Image = global::EmployeeManagement.Properties.Resources.emailemail;
            this.mnuEmailEmployee.Name = "mnuEmailEmployee";
            this.mnuEmailEmployee.Size = new System.Drawing.Size(172, 22);
            this.mnuEmailEmployee.Text = "E&mail Employee";
            this.mnuEmailEmployee.Click += new System.EventHandler(this.EmailSelectedEmployee);
            // 
            // mnuCopyToClipboard
            // 
            this.mnuCopyToClipboard.Image = global::EmployeeManagement.Properties.Resources.copy;
            this.mnuCopyToClipboard.Name = "mnuCopyToClipboard";
            this.mnuCopyToClipboard.Size = new System.Drawing.Size(172, 22);
            this.mnuCopyToClipboard.Text = "&Copy To Clipboard";
            this.mnuCopyToClipboard.Click += new System.EventHandler(this.CopyToClipboard);
            // 
            // chkHidePhotos
            // 
            this.chkHidePhotos.AutoSize = true;
            this.chkHidePhotos.BackColor = System.Drawing.Color.Black;
            this.chkHidePhotos.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHidePhotos.ForeColor = System.Drawing.Color.White;
            this.chkHidePhotos.Location = new System.Drawing.Point(455, 89);
            this.chkHidePhotos.Name = "chkHidePhotos";
            this.chkHidePhotos.Size = new System.Drawing.Size(103, 21);
            this.chkHidePhotos.TabIndex = 7;
            this.chkHidePhotos.Text = "&Hide Photos";
            this.chkHidePhotos.UseVisualStyleBackColor = false;
            this.chkHidePhotos.CheckedChanged += new System.EventHandler(this.ChkHidePhotos_CheckedChanged);
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.BackColor = System.Drawing.Color.Black;
            this.btnCopyToClipboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCopyToClipboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnCopyToClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyToClipboard.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyToClipboard.ForeColor = System.Drawing.Color.White;
            this.btnCopyToClipboard.Image = global::EmployeeManagement.Properties.Resources.copy;
            this.btnCopyToClipboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyToClipboard.Location = new System.Drawing.Point(520, 13);
            this.btnCopyToClipboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(137, 44);
            this.btnCopyToClipboard.TabIndex = 4;
            this.btnCopyToClipboard.Text = "&Copy To Clipboard";
            this.btnCopyToClipboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopyToClipboard.UseVisualStyleBackColor = false;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.CopyToClipboard);
            // 
            // btnEmailEmployee
            // 
            this.btnEmailEmployee.BackColor = System.Drawing.Color.Black;
            this.btnEmailEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEmailEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEmailEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailEmployee.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEmailEmployee.Image = global::EmployeeManagement.Properties.Resources.emailemail;
            this.btnEmailEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEmailEmployee.Location = new System.Drawing.Point(393, 13);
            this.btnEmailEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEmailEmployee.Name = "btnEmailEmployee";
            this.btnEmailEmployee.Size = new System.Drawing.Size(123, 44);
            this.btnEmailEmployee.TabIndex = 3;
            this.btnEmailEmployee.Text = "e&Mail Employee";
            this.btnEmailEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEmailEmployee.UseVisualStyleBackColor = false;
            this.btnEmailEmployee.Click += new System.EventHandler(this.EmailSelectedEmployee);
            // 
            // btnEditEmployee
            // 
            this.btnEditEmployee.BackColor = System.Drawing.Color.Black;
            this.btnEditEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEditEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEditEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditEmployee.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditEmployee.ForeColor = System.Drawing.Color.White;
            this.btnEditEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnEditEmployee.Image")));
            this.btnEditEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditEmployee.Location = new System.Drawing.Point(139, 13);
            this.btnEditEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditEmployee.Name = "btnEditEmployee";
            this.btnEditEmployee.Size = new System.Drawing.Size(123, 44);
            this.btnEditEmployee.TabIndex = 1;
            this.btnEditEmployee.Text = "&Edit Employee";
            this.btnEditEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditEmployee.UseVisualStyleBackColor = false;
            this.btnEditEmployee.Click += new System.EventHandler(this.EditEmployee);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.BackColor = System.Drawing.Color.Black;
            this.btnDeleteEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDeleteEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnDeleteEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEmployee.Image = global::EmployeeManagement.Properties.Resources.disagree;
            this.btnDeleteEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteEmployee.Location = new System.Drawing.Point(266, 13);
            this.btnDeleteEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(123, 44);
            this.btnDeleteEmployee.TabIndex = 2;
            this.btnDeleteEmployee.Text = "&Delete Employee";
            this.btnDeleteEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteEmployee.UseVisualStyleBackColor = false;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.DeleteEmployee);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.Color.Black;
            this.btnAddEmployee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnAddEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEmployee.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddEmployee.Image = global::EmployeeManagement.Properties.Resources.plusplus;
            this.btnAddEmployee.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddEmployee.Location = new System.Drawing.Point(12, 13);
            this.btnAddEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(123, 44);
            this.btnAddEmployee.TabIndex = 0;
            this.btnAddEmployee.Text = "&Add Employee";
            this.btnAddEmployee.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.AddEmployee);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(816, 575);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.btnEmailEmployee);
            this.Controls.Add(this.chkHidePhotos);
            this.Controls.Add(this.dgvTable);
            this.Controls.Add(this.btnEditEmployee);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnDeleteEmployee);
            this.Controls.Add(this.btnAddEmployee);
            this.Font = new System.Drawing.Font("Ebrima", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Managment";
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.mnuRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnEditEmployee;
        internal System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.ContextMenuStrip mnuRightClick;
        private System.Windows.Forms.ToolStripMenuItem mnuAddEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuEditEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteEmployee;
        private System.Windows.Forms.CheckBox chkHidePhotos;
        private System.Windows.Forms.ToolStripMenuItem mnuEmailEmployee;
        private System.Windows.Forms.Button btnEmailEmployee;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyToClipboard;
    }
}

