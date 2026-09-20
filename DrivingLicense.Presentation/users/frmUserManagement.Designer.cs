namespace DrivingLicense.Presentation.users
{
    partial class frmUserManagement
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
            this.lblRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.cmiUsers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.frmAddUser = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmiShowUserDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(100, 500);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(31, 16);
            this.lblRecords.TabIndex = 23;
            this.lblRecords.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "# Records :";
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(261, 238);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(191, 21);
            this.cmbFilterValue.TabIndex = 21;
            this.cmbFilterValue.SelectedIndexChanged += new System.EventHandler(this.cmbFilterValue_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(261, 238);
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
            this.cmbFilterOptions.Location = new System.Drawing.Point(8, 238);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(218, 21);
            this.cmbFilterOptions.TabIndex = 19;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // cmiUsers
            // 
            this.cmiUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiShowUserDetails,
            this.cmiAddNewUser,
            this.cmiEditUser,
            this.cmiDeletePerson,
            this.cmiSendEmail,
            this.cmiPhoneCall});
            this.cmiUsers.Name = "cmiPeople";
            this.cmiUsers.Size = new System.Drawing.Size(166, 232);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ContextMenuStrip = this.cmiUsers;
            this.dgvUsers.Location = new System.Drawing.Point(12, 264);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(596, 214);
            this.dgvUsers.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(214, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 34);
            this.label1.TabIndex = 15;
            this.label1.Text = "Manage Users";
            // 
            // frmAddUser
            // 
            this.frmAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frmAddUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.frmAddUser.FlatAppearance.BorderSize = 2;
            this.frmAddUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.frmAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.frmAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frmAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmAddUser.Image = global::DrivingLicense.Presentation.Properties.Resources.Add_Person_40;
            this.frmAddUser.Location = new System.Drawing.Point(549, 218);
            this.frmAddUser.Name = "frmAddUser";
            this.frmAddUser.Size = new System.Drawing.Size(59, 40);
            this.frmAddUser.TabIndex = 18;
            this.frmAddUser.UseVisualStyleBackColor = true;
            this.frmAddUser.Click += new System.EventHandler(this.frmAddUser_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(486, 484);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingLicense.Presentation.Properties.Resources.Users_2_400;
            this.pictureBox1.Location = new System.Drawing.Point(209, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // cmiShowUserDetails
            // 
            this.cmiShowUserDetails.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonDetails_32;
            this.cmiShowUserDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiShowUserDetails.Name = "cmiShowUserDetails";
            this.cmiShowUserDetails.Size = new System.Drawing.Size(165, 38);
            this.cmiShowUserDetails.Text = "Show Details";
            this.cmiShowUserDetails.Click += new System.EventHandler(this.cmiShowUserDetails_Click);
            // 
            // cmiAddNewUser
            // 
            this.cmiAddNewUser.Image = global::DrivingLicense.Presentation.Properties.Resources.AddPerson_32;
            this.cmiAddNewUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiAddNewUser.Name = "cmiAddNewUser";
            this.cmiAddNewUser.Size = new System.Drawing.Size(165, 38);
            this.cmiAddNewUser.Text = "Add New User";
            this.cmiAddNewUser.Click += new System.EventHandler(this.cmiAddNewUser_Click);
            // 
            // cmiEditUser
            // 
            this.cmiEditUser.Image = global::DrivingLicense.Presentation.Properties.Resources.edit_32;
            this.cmiEditUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiEditUser.Name = "cmiEditUser";
            this.cmiEditUser.Size = new System.Drawing.Size(165, 38);
            this.cmiEditUser.Text = "Edit";
            this.cmiEditUser.Click += new System.EventHandler(this.cmiEditUser_Click);
            // 
            // cmiDeletePerson
            // 
            this.cmiDeletePerson.Image = global::DrivingLicense.Presentation.Properties.Resources.Delete_32;
            this.cmiDeletePerson.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiDeletePerson.Name = "cmiDeletePerson";
            this.cmiDeletePerson.Size = new System.Drawing.Size(165, 38);
            this.cmiDeletePerson.Text = "Delete";
            // 
            // cmiSendEmail
            // 
            this.cmiSendEmail.Image = global::DrivingLicense.Presentation.Properties.Resources.send_email_32;
            this.cmiSendEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiSendEmail.Name = "cmiSendEmail";
            this.cmiSendEmail.Size = new System.Drawing.Size(165, 38);
            this.cmiSendEmail.Text = "Send Email";
            // 
            // cmiPhoneCall
            // 
            this.cmiPhoneCall.Image = global::DrivingLicense.Presentation.Properties.Resources.call_32;
            this.cmiPhoneCall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmiPhoneCall.Name = "cmiPhoneCall";
            this.cmiPhoneCall.Size = new System.Drawing.Size(165, 38);
            this.cmiPhoneCall.Text = "Phone Call";
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 527);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cmbFilterOptions);
            this.Controls.Add(this.frmAddUser);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.label1);
            this.Name = "frmUserManagement";
            this.Text = "frmUserManagement";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            this.cmiUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
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
        private System.Windows.Forms.Button frmAddUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem cmiPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem cmiDeletePerson;
        private System.Windows.Forms.ToolStripMenuItem cmiEditUser;
        private System.Windows.Forms.ToolStripMenuItem cmiAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem cmiShowUserDetails;
        private System.Windows.Forms.ContextMenuStrip cmiUsers;
        private System.Windows.Forms.ToolStripMenuItem cmiSendEmail;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label label1;
    }
}