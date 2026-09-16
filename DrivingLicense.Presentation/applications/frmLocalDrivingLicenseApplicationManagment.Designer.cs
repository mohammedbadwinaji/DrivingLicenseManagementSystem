namespace DrivingLicense.Presentation.applications
{
    partial class frmLocalDrivingLicenseApplicationManagment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.cmLocalDrivingLicenseApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmiShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiEditLocalDrivingLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiIssureDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiShowApplicationLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiShowPersonLicensesHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmLocalDrivingLicenseApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(102, 573);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(31, 16);
            this.lblRecords.TabIndex = 23;
            this.lblRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 573);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "# Records :";
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(288, 221);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(191, 21);
            this.cmbFilterValue.TabIndex = 21;
            this.cmbFilterValue.SelectedIndexChanged += new System.EventHandler(this.cmbFilterValue_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(261, 222);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(191, 20);
            this.txtFilterValue.TabIndex = 20;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(4, 221);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(218, 21);
            this.cmbFilterOptions.TabIndex = 19;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // cmLocalDrivingLicenseApplications
            // 
            this.cmLocalDrivingLicenseApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiShowApplicationDetails,
            this.cmiEditLocalDrivingLicenseApplication,
            this.cmiDeleteApplication,
            this.cmiCancelApplication,
            this.cmiScheduleTests,
            this.cmiIssureDrivingLicenseFirstTime,
            this.cmiShowApplicationLicense,
            this.cmiShowPersonLicensesHistory});
            this.cmLocalDrivingLicenseApplications.Name = "cmiPeople";
            this.cmLocalDrivingLicenseApplications.Size = new System.Drawing.Size(259, 330);
            this.cmLocalDrivingLicenseApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmLocalDrivingLicenseApplications_Opening);
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalDrivingLicenseApplications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmLocalDrivingLicenseApplications;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalDrivingLicenseApplications.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(4, 255);
            this.dgvLocalDrivingLicenseApplications.MultiSelect = false;
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1098, 305);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(319, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 34);
            this.label1.TabIndex = 15;
            this.label1.Text = "Local Driving License Applications";
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewLocalDrivingLicenseApplication.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddNewLocalDrivingLicenseApplication.FlatAppearance.BorderSize = 2;
            this.btnAddNewLocalDrivingLicenseApplication.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddNewLocalDrivingLicenseApplication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnAddNewLocalDrivingLicenseApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLocalDrivingLicenseApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewLocalDrivingLicenseApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.Add_Person_40;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1043, 209);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(59, 40);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 18;
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(980, 564);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingLicense.Presentation.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(442, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // cmiShowApplicationDetails
            // 
            this.cmiShowApplicationDetails.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonDetails_32;
            this.cmiShowApplicationDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowApplicationDetails.Name = "cmiShowApplicationDetails";
            this.cmiShowApplicationDetails.Size = new System.Drawing.Size(258, 38);
            this.cmiShowApplicationDetails.Text = "Show Application Details";
            this.cmiShowApplicationDetails.Click += new System.EventHandler(this.cmiShowApplicationDetails_Click);
            // 
            // cmiEditLocalDrivingLicenseApplication
            // 
            this.cmiEditLocalDrivingLicenseApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.edit_32;
            this.cmiEditLocalDrivingLicenseApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiEditLocalDrivingLicenseApplication.Name = "cmiEditLocalDrivingLicenseApplication";
            this.cmiEditLocalDrivingLicenseApplication.Size = new System.Drawing.Size(258, 38);
            this.cmiEditLocalDrivingLicenseApplication.Text = "Edit Application";
            this.cmiEditLocalDrivingLicenseApplication.Click += new System.EventHandler(this.cmiEditLocalDrivingLicenseApplication_Click);
            // 
            // cmiDeleteApplication
            // 
            this.cmiDeleteApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.Delete_32_2;
            this.cmiDeleteApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiDeleteApplication.Name = "cmiDeleteApplication";
            this.cmiDeleteApplication.Size = new System.Drawing.Size(258, 38);
            this.cmiDeleteApplication.Text = "Delete Application";
            // 
            // cmiCancelApplication
            // 
            this.cmiCancelApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.Delete_32;
            this.cmiCancelApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiCancelApplication.Name = "cmiCancelApplication";
            this.cmiCancelApplication.Size = new System.Drawing.Size(258, 38);
            this.cmiCancelApplication.Text = "Cancel Application";
            this.cmiCancelApplication.Click += new System.EventHandler(this.cmiCancelApplication_Click);
            // 
            // cmiScheduleTests
            // 
            this.cmiScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiScheduleVisionTest,
            this.cmiScheduleWrittenTest,
            this.cmiScheduleStreetTest});
            this.cmiScheduleTests.Image = global::DrivingLicense.Presentation.Properties.Resources.Schedule_Test_32;
            this.cmiScheduleTests.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiScheduleTests.Name = "cmiScheduleTests";
            this.cmiScheduleTests.Size = new System.Drawing.Size(258, 38);
            this.cmiScheduleTests.Text = "Schedule Tests";
            // 
            // cmiScheduleVisionTest
            // 
            this.cmiScheduleVisionTest.Image = global::DrivingLicense.Presentation.Properties.Resources.Vision_Test_32;
            this.cmiScheduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiScheduleVisionTest.Name = "cmiScheduleVisionTest";
            this.cmiScheduleVisionTest.Size = new System.Drawing.Size(204, 38);
            this.cmiScheduleVisionTest.Text = "Schedule Vision Test";
            this.cmiScheduleVisionTest.Click += new System.EventHandler(this.cmiScheduleVisionTest_Click);
            // 
            // cmiScheduleWrittenTest
            // 
            this.cmiScheduleWrittenTest.Image = global::DrivingLicense.Presentation.Properties.Resources.Written_Test_32;
            this.cmiScheduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiScheduleWrittenTest.Name = "cmiScheduleWrittenTest";
            this.cmiScheduleWrittenTest.Size = new System.Drawing.Size(204, 38);
            this.cmiScheduleWrittenTest.Text = "Schedule Written Test";
            this.cmiScheduleWrittenTest.Click += new System.EventHandler(this.cmiScheduleWrittenTest_Click);
            // 
            // cmiScheduleStreetTest
            // 
            this.cmiScheduleStreetTest.Image = global::DrivingLicense.Presentation.Properties.Resources.Street_Test_32;
            this.cmiScheduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiScheduleStreetTest.Name = "cmiScheduleStreetTest";
            this.cmiScheduleStreetTest.Size = new System.Drawing.Size(204, 38);
            this.cmiScheduleStreetTest.Text = "Schedule Street Test";
            this.cmiScheduleStreetTest.Click += new System.EventHandler(this.cmiScheduleStreetTest_Click);
            // 
            // cmiIssureDrivingLicenseFirstTime
            // 
            this.cmiIssureDrivingLicenseFirstTime.Image = global::DrivingLicense.Presentation.Properties.Resources.IssueDrivingLicense_32;
            this.cmiIssureDrivingLicenseFirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiIssureDrivingLicenseFirstTime.Name = "cmiIssureDrivingLicenseFirstTime";
            this.cmiIssureDrivingLicenseFirstTime.Size = new System.Drawing.Size(258, 38);
            this.cmiIssureDrivingLicenseFirstTime.Text = "Issure Driving License First Time";
            // 
            // cmiShowApplicationLicense
            // 
            this.cmiShowApplicationLicense.Image = global::DrivingLicense.Presentation.Properties.Resources.License_View_32;
            this.cmiShowApplicationLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowApplicationLicense.Name = "cmiShowApplicationLicense";
            this.cmiShowApplicationLicense.Size = new System.Drawing.Size(258, 38);
            this.cmiShowApplicationLicense.Text = "Show License";
            this.cmiShowApplicationLicense.Click += new System.EventHandler(this.cmiShowApplicationLicense_Click);
            // 
            // cmiShowPersonLicensesHistory
            // 
            this.cmiShowPersonLicensesHistory.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonLicenseHistory_32;
            this.cmiShowPersonLicensesHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowPersonLicensesHistory.Name = "cmiShowPersonLicensesHistory";
            this.cmiShowPersonLicensesHistory.Size = new System.Drawing.Size(258, 38);
            this.cmiShowPersonLicensesHistory.Text = "Show Person Licenses History";
            // 
            // frmLocalDrivingLicenseApplicationManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 601);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.label1);
            this.Name = "frmLocalDrivingLicenseApplicationManagment";
            this.Text = "frmLocalDrivingLicenseApplicationManagment";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationManagment_Load);
            this.cmLocalDrivingLicenseApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem cmiDeleteApplication;
        private System.Windows.Forms.ToolStripMenuItem cmiEditLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem cmiCancelApplication;
        private System.Windows.Forms.ToolStripMenuItem cmiShowApplicationDetails;
        private System.Windows.Forms.ContextMenuStrip cmLocalDrivingLicenseApplications;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem cmiShowApplicationLicense;
        private System.Windows.Forms.ToolStripMenuItem cmiShowPersonLicensesHistory;
        private System.Windows.Forms.ToolStripMenuItem cmiScheduleTests;
        private System.Windows.Forms.ToolStripMenuItem cmiScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem cmiScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem cmiScheduleStreetTest;
        private System.Windows.Forms.ToolStripMenuItem cmiIssureDrivingLicenseFirstTime;
    }
}