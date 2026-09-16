namespace DrivingLicense.Presentation.people
{
    partial class frmPeopleManagement
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
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmiPeople = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.frmAddEditPerson = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmiShowPesonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmiPeople.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(455, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmiPeople;
            this.dgvPeople.Location = new System.Drawing.Point(12, 276);
            this.dgvPeople.MultiSelect = false;
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(1098, 214);
            this.dgvPeople.TabIndex = 2;
            this.dgvPeople.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPeople_CellFormatting);
            // 
            // cmiPeople
            // 
            this.cmiPeople.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiShowPesonDetails,
            this.cmiAddNewPerson,
            this.cmiEditPerson,
            this.cmiDeletePerson,
            this.cmiSendEmail,
            this.cmiPhoneCall});
            this.cmiPeople.Name = "cmiPeople";
            this.cmiPeople.Size = new System.Drawing.Size(179, 232);
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(12, 242);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(218, 21);
            this.cmbFilterOptions.TabIndex = 5;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(269, 243);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(191, 20);
            this.txtFilterValue.TabIndex = 6;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(269, 243);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(191, 21);
            this.cmbFilterValue.TabIndex = 7;
            this.cmbFilterValue.SelectedIndexChanged += new System.EventHandler(this.cmbFilterValue_SelectedIndexChanged);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(110, 505);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(31, 16);
            this.lblRecords.TabIndex = 13;
            this.lblRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 505);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "# Records :";
            // 
            // frmAddEditPerson
            // 
            this.frmAddEditPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frmAddEditPerson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.frmAddEditPerson.FlatAppearance.BorderSize = 2;
            this.frmAddEditPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.frmAddEditPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.frmAddEditPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frmAddEditPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmAddEditPerson.Image = global::DrivingLicense.Presentation.Properties.Resources.Add_Person_40;
            this.frmAddEditPerson.Location = new System.Drawing.Point(1051, 230);
            this.frmAddEditPerson.Name = "frmAddEditPerson";
            this.frmAddEditPerson.Size = new System.Drawing.Size(59, 40);
            this.frmAddEditPerson.TabIndex = 4;
            this.frmAddEditPerson.UseVisualStyleBackColor = true;
            this.frmAddEditPerson.Click += new System.EventHandler(this.frmAddEditPerson_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(988, 496);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmiShowPesonDetails
            // 
            this.cmiShowPesonDetails.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonDetails_32;
            this.cmiShowPesonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowPesonDetails.Name = "cmiShowPesonDetails";
            this.cmiShowPesonDetails.Size = new System.Drawing.Size(178, 38);
            this.cmiShowPesonDetails.Text = "Show Details";
            this.cmiShowPesonDetails.Click += new System.EventHandler(this.cmiShowPesonDetails_Click);
            // 
            // cmiAddNewPerson
            // 
            this.cmiAddNewPerson.Image = global::DrivingLicense.Presentation.Properties.Resources.AddPerson_32;
            this.cmiAddNewPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiAddNewPerson.Name = "cmiAddNewPerson";
            this.cmiAddNewPerson.Size = new System.Drawing.Size(178, 38);
            this.cmiAddNewPerson.Text = "Add New Person";
            this.cmiAddNewPerson.Click += new System.EventHandler(this.cmiAddNewPerson_Click);
            // 
            // cmiEditPerson
            // 
            this.cmiEditPerson.Image = global::DrivingLicense.Presentation.Properties.Resources.edit_32;
            this.cmiEditPerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiEditPerson.Name = "cmiEditPerson";
            this.cmiEditPerson.Size = new System.Drawing.Size(178, 38);
            this.cmiEditPerson.Text = "Edit";
            this.cmiEditPerson.Click += new System.EventHandler(this.cmiEditPerson_Click);
            // 
            // cmiDeletePerson
            // 
            this.cmiDeletePerson.Image = global::DrivingLicense.Presentation.Properties.Resources.Delete_32;
            this.cmiDeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiDeletePerson.Name = "cmiDeletePerson";
            this.cmiDeletePerson.Size = new System.Drawing.Size(178, 38);
            this.cmiDeletePerson.Text = "Delete";
            // 
            // cmiSendEmail
            // 
            this.cmiSendEmail.Image = global::DrivingLicense.Presentation.Properties.Resources.send_email_32;
            this.cmiSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiSendEmail.Name = "cmiSendEmail";
            this.cmiSendEmail.Size = new System.Drawing.Size(178, 38);
            this.cmiSendEmail.Text = "Send Email";
            // 
            // cmiPhoneCall
            // 
            this.cmiPhoneCall.Image = global::DrivingLicense.Presentation.Properties.Resources.call_32;
            this.cmiPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiPhoneCall.Name = "cmiPhoneCall";
            this.cmiPhoneCall.Size = new System.Drawing.Size(178, 38);
            this.cmiPhoneCall.Text = "Phone Call";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingLicense.Presentation.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(450, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmPeopleManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 538);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.frmAddEditPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPeopleManagement";
            this.Text = "frmPeopleManagement";
            this.Load += new System.EventHandler(this.frmPeopleManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmiPeople.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button frmAddEditPerson;
        private System.Windows.Forms.ContextMenuStrip cmiPeople;
        private System.Windows.Forms.ToolStripMenuItem cmiShowPesonDetails;
        private System.Windows.Forms.ToolStripMenuItem cmiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem cmiEditPerson;
        private System.Windows.Forms.ToolStripMenuItem cmiDeletePerson;
        private System.Windows.Forms.ToolStripMenuItem cmiSendEmail;
        private System.Windows.Forms.ToolStripMenuItem cmiPhoneCall;
        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label label2;
    }
}