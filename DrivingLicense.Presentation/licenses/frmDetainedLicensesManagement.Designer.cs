namespace DrivingLicense.Presentation.licenses
{
    partial class frmDetainedLicensesManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.cmiDetainedLiceneses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReleaseDetainedLicense = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.cmiDetainedLiceneses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(374, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 34);
            this.label1.TabIndex = 17;
            this.label1.Text = "List Detained Licenses";
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(282, 215);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(191, 21);
            this.cmbFilterValue.TabIndex = 25;
            this.cmbFilterValue.SelectedIndexChanged += new System.EventHandler(this.cmbFilterValue_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(282, 215);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(191, 20);
            this.txtFilterValue.TabIndex = 24;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(29, 215);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(218, 21);
            this.cmbFilterOptions.TabIndex = 23;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgvDetainedLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetainedLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.ContextMenuStrip = this.cmiDetainedLiceneses;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(29, 265);
            this.dgvDetainedLicenses.MultiSelect = false;
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(978, 255);
            this.dgvDetainedLicenses.TabIndex = 26;
            // 
            // cmiDetainedLiceneses
            // 
            this.cmiDetainedLiceneses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiShowPersonDetails,
            this.cmiShowLicenseDetails,
            this.cmiShowPersonLicenseHistory,
            this.cmiReleaseDetainedLicense});
            this.cmiDetainedLiceneses.Name = "cmiPeople";
            this.cmiDetainedLiceneses.Size = new System.Drawing.Size(242, 156);
            this.cmiDetainedLiceneses.Opening += new System.ComponentModel.CancelEventHandler(this.cmiDetainedLiceneses_Opening);
            // 
            // cmiShowPersonDetails
            // 
            this.cmiShowPersonDetails.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonDetails_32;
            this.cmiShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowPersonDetails.Name = "cmiShowPersonDetails";
            this.cmiShowPersonDetails.Size = new System.Drawing.Size(241, 38);
            this.cmiShowPersonDetails.Text = "Show Person Details";
            this.cmiShowPersonDetails.Click += new System.EventHandler(this.cmiShowPersonDetails_Click);
            // 
            // cmiShowLicenseDetails
            // 
            this.cmiShowLicenseDetails.Image = global::DrivingLicense.Presentation.Properties.Resources.License_View_32;
            this.cmiShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowLicenseDetails.Name = "cmiShowLicenseDetails";
            this.cmiShowLicenseDetails.Size = new System.Drawing.Size(241, 38);
            this.cmiShowLicenseDetails.Text = "Show License Details";
            this.cmiShowLicenseDetails.Click += new System.EventHandler(this.cmiShowLicenseDetails_Click);
            // 
            // cmiShowPersonLicenseHistory
            // 
            this.cmiShowPersonLicenseHistory.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonLicenseHistory_32;
            this.cmiShowPersonLicenseHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmiShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowPersonLicenseHistory.Name = "cmiShowPersonLicenseHistory";
            this.cmiShowPersonLicenseHistory.Size = new System.Drawing.Size(241, 38);
            this.cmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.cmiShowPersonLicenseHistory.Click += new System.EventHandler(this.cmiShowPersonLicenseHistory_Click);
            // 
            // cmiReleaseDetainedLicense
            // 
            this.cmiReleaseDetainedLicense.Image = global::DrivingLicense.Presentation.Properties.Resources.Release_Detained_License_32;
            this.cmiReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiReleaseDetainedLicense.Name = "cmiReleaseDetainedLicense";
            this.cmiReleaseDetainedLicense.Size = new System.Drawing.Size(241, 38);
            this.cmiReleaseDetainedLicense.Text = "Release Detained Licenses";
            this.cmiReleaseDetainedLicense.Click += new System.EventHandler(this.cmiReleaseDetainedLicense_Click);
            // 
            // btnReleaseDetainedLicense
            // 
            this.btnReleaseDetainedLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReleaseDetainedLicense.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReleaseDetainedLicense.FlatAppearance.BorderSize = 2;
            this.btnReleaseDetainedLicense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReleaseDetainedLicense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnReleaseDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReleaseDetainedLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReleaseDetainedLicense.Image = global::DrivingLicense.Presentation.Properties.Resources.Release_Detained_License_64;
            this.btnReleaseDetainedLicense.Location = new System.Drawing.Point(848, 191);
            this.btnReleaseDetainedLicense.Name = "btnReleaseDetainedLicense";
            this.btnReleaseDetainedLicense.Size = new System.Drawing.Size(70, 64);
            this.btnReleaseDetainedLicense.TabIndex = 27;
            this.btnReleaseDetainedLicense.UseVisualStyleBackColor = true;
            this.btnReleaseDetainedLicense.Click += new System.EventHandler(this.btnReleaseDetainedLicense_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetainLicense.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDetainLicense.FlatAppearance.BorderSize = 2;
            this.btnDetainLicense.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDetainLicense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDetainLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetainLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetainLicense.Image = global::DrivingLicense.Presentation.Properties.Resources.Detain_641;
            this.btnDetainLicense.Location = new System.Drawing.Point(924, 191);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(70, 64);
            this.btnDetainLicense.TabIndex = 22;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingLicense.Presentation.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(421, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(123, 542);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(31, 16);
            this.lblRecords.TabIndex = 30;
            this.lblRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "# Records :";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(885, 525);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmDetainedLicensesManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 565);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReleaseDetainedLicense);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmDetainedLicensesManagement";
            this.Text = "frmDetainedLicensesManagement";
            this.Load += new System.EventHandler(this.frmDetainedLicensesManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.cmiDetainedLiceneses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Button btnReleaseDetainedLicense;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmiDetainedLiceneses;
        private System.Windows.Forms.ToolStripMenuItem cmiShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem cmiShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem cmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem cmiReleaseDetainedLicense;
    }
}