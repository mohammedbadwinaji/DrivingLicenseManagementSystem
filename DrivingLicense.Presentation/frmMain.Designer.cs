namespace DrivingLicense.Presentation
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
            this.ms = new System.Windows.Forms.MenuStrip();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddNewInternationalLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.miRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.miReplacementForDamageOrLostApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.miLocalDrivingLicenseApplicationManagment = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageInternationalLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.miManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.miPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.miDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.miUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.miCurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.miSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.ms.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms
            // 
            this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.miPeople,
            this.miDrivers,
            this.miUsers,
            this.miAccountSettings});
            this.ms.Location = new System.Drawing.Point(0, 0);
            this.ms.Name = "ms";
            this.ms.Size = new System.Drawing.Size(1286, 72);
            this.ms.TabIndex = 0;
            this.ms.Text = "menuStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(1218, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 33);
            this.btnClose.TabIndex = 47;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem7,
            this.miManageApplicationTypes,
            this.miManageTestTypes});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = global::DrivingLicense.Presentation.Properties.Resources.Applications_64;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 68);
            this.toolStripMenuItem1.Text = "Applications";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.miRenewDrivingLicense,
            this.miReplacementForDamageOrLostApplication,
            this.toolStripMenuItem5,
            this.newDrivingLicenseToolStripMenuItem});
            this.toolStripMenuItem2.Image = global::DrivingLicense.Presentation.Properties.Resources.Driver_License_48;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(366, 70);
            this.toolStripMenuItem2.Text = "Driving License Services";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddNewLocalDrivingLicenseApplication,
            this.miAddNewInternationalLicenseApplication});
            this.toolStripMenuItem3.Image = global::DrivingLicense.Presentation.Properties.Resources.New_Driving_License_32;
            this.toolStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(467, 38);
            this.toolStripMenuItem3.Text = "New Driving License";
            // 
            // miAddNewLocalDrivingLicenseApplication
            // 
            this.miAddNewLocalDrivingLicenseApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.Local_32;
            this.miAddNewLocalDrivingLicenseApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miAddNewLocalDrivingLicenseApplication.Name = "miAddNewLocalDrivingLicenseApplication";
            this.miAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(285, 38);
            this.miAddNewLocalDrivingLicenseApplication.Text = "Local License";
            this.miAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.miAddNewLocalDrivingLicenseApplication_Click);
            // 
            // miAddNewInternationalLicenseApplication
            // 
            this.miAddNewInternationalLicenseApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.International_32;
            this.miAddNewInternationalLicenseApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miAddNewInternationalLicenseApplication.Name = "miAddNewInternationalLicenseApplication";
            this.miAddNewInternationalLicenseApplication.Size = new System.Drawing.Size(285, 38);
            this.miAddNewInternationalLicenseApplication.Text = "International License";
            this.miAddNewInternationalLicenseApplication.Click += new System.EventHandler(this.miAddNewInternationalLicenseApplication_Click);
            // 
            // miRenewDrivingLicense
            // 
            this.miRenewDrivingLicense.Image = global::DrivingLicense.Presentation.Properties.Resources.Renew_Driving_License_32;
            this.miRenewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miRenewDrivingLicense.Name = "miRenewDrivingLicense";
            this.miRenewDrivingLicense.Size = new System.Drawing.Size(467, 38);
            this.miRenewDrivingLicense.Text = "Renew Driving License";
            this.miRenewDrivingLicense.Click += new System.EventHandler(this.miRenewDrivingLicense_Click);
            // 
            // miReplacementForDamageOrLostApplication
            // 
            this.miReplacementForDamageOrLostApplication.Image = global::DrivingLicense.Presentation.Properties.Resources.Lost_Driving_License_32;
            this.miReplacementForDamageOrLostApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miReplacementForDamageOrLostApplication.Name = "miReplacementForDamageOrLostApplication";
            this.miReplacementForDamageOrLostApplication.Size = new System.Drawing.Size(467, 38);
            this.miReplacementForDamageOrLostApplication.Text = "Replacment For Lost Or Damaged License";
            this.miReplacementForDamageOrLostApplication.Click += new System.EventHandler(this.miReplacementForDamageOrLostApplication_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::DrivingLicense.Presentation.Properties.Resources.Detained_Driving_License_32;
            this.toolStripMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(467, 38);
            this.toolStripMenuItem5.Text = "Release Detained Driving Licnese";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.Image = global::DrivingLicense.Presentation.Properties.Resources.Retake_Test_32;
            this.newDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(467, 38);
            this.newDrivingLicenseToolStripMenuItem.Text = "Retake Test";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLocalDrivingLicenseApplicationManagment,
            this.miManageInternationalLicenseApplications});
            this.toolStripMenuItem7.Image = global::DrivingLicense.Presentation.Properties.Resources.Manage_Applications_64;
            this.toolStripMenuItem7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(366, 70);
            this.toolStripMenuItem7.Text = "Manage Applications";
            // 
            // miLocalDrivingLicenseApplicationManagment
            // 
            this.miLocalDrivingLicenseApplicationManagment.Image = global::DrivingLicense.Presentation.Properties.Resources.LocalDriving_License;
            this.miLocalDrivingLicenseApplicationManagment.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miLocalDrivingLicenseApplicationManagment.Name = "miLocalDrivingLicenseApplicationManagment";
            this.miLocalDrivingLicenseApplicationManagment.Size = new System.Drawing.Size(471, 38);
            this.miLocalDrivingLicenseApplicationManagment.Text = "Local Driving License Applications";
            this.miLocalDrivingLicenseApplicationManagment.Click += new System.EventHandler(this.miLocalDrivingLicenseApplicationManagment_Click);
            // 
            // miManageInternationalLicenseApplications
            // 
            this.miManageInternationalLicenseApplications.Image = global::DrivingLicense.Presentation.Properties.Resources.International_32;
            this.miManageInternationalLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miManageInternationalLicenseApplications.Name = "miManageInternationalLicenseApplications";
            this.miManageInternationalLicenseApplications.Size = new System.Drawing.Size(471, 38);
            this.miManageInternationalLicenseApplications.Text = "International Driving License Applications";
            this.miManageInternationalLicenseApplications.Click += new System.EventHandler(this.miManageInternationalLicenseApplications_Click);
            // 
            // miManageApplicationTypes
            // 
            this.miManageApplicationTypes.Image = global::DrivingLicense.Presentation.Properties.Resources.Application_Types_64;
            this.miManageApplicationTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miManageApplicationTypes.Name = "miManageApplicationTypes";
            this.miManageApplicationTypes.Size = new System.Drawing.Size(366, 70);
            this.miManageApplicationTypes.Text = "Manage Application Types";
            this.miManageApplicationTypes.Click += new System.EventHandler(this.miManageApplicationTypes_Click);
            // 
            // miManageTestTypes
            // 
            this.miManageTestTypes.Image = global::DrivingLicense.Presentation.Properties.Resources.Test_Type_64;
            this.miManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miManageTestTypes.Name = "miManageTestTypes";
            this.miManageTestTypes.Size = new System.Drawing.Size(366, 70);
            this.miManageTestTypes.Text = "Manage Test Types";
            this.miManageTestTypes.Click += new System.EventHandler(this.miManageTestTypes_Click);
            // 
            // miPeople
            // 
            this.miPeople.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miPeople.Image = global::DrivingLicense.Presentation.Properties.Resources.People_64;
            this.miPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miPeople.Name = "miPeople";
            this.miPeople.Size = new System.Drawing.Size(148, 68);
            this.miPeople.Text = "People";
            this.miPeople.Click += new System.EventHandler(this.miPeople_Click);
            // 
            // miDrivers
            // 
            this.miDrivers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miDrivers.Image = global::DrivingLicense.Presentation.Properties.Resources.Drivers_64;
            this.miDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miDrivers.Name = "miDrivers";
            this.miDrivers.Size = new System.Drawing.Size(151, 68);
            this.miDrivers.Text = "Drivers";
            this.miDrivers.Click += new System.EventHandler(this.miDrivers_Click);
            // 
            // miUsers
            // 
            this.miUsers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miUsers.Image = global::DrivingLicense.Presentation.Properties.Resources.Users_2_64;
            this.miUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miUsers.Name = "miUsers";
            this.miUsers.Size = new System.Drawing.Size(136, 68);
            this.miUsers.Text = "Users";
            this.miUsers.Click += new System.EventHandler(this.miUsers_Click);
            // 
            // miAccountSettings
            // 
            this.miAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCurrentUserInfo,
            this.miChangePassword,
            this.miSignOut});
            this.miAccountSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miAccountSettings.Image = global::DrivingLicense.Presentation.Properties.Resources.account_settings_64;
            this.miAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miAccountSettings.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.miAccountSettings.Name = "miAccountSettings";
            this.miAccountSettings.Size = new System.Drawing.Size(239, 68);
            this.miAccountSettings.Text = "Account Settings";
            // 
            // miCurrentUserInfo
            // 
            this.miCurrentUserInfo.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonDetails_32;
            this.miCurrentUserInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miCurrentUserInfo.Name = "miCurrentUserInfo";
            this.miCurrentUserInfo.Size = new System.Drawing.Size(257, 38);
            this.miCurrentUserInfo.Text = "Current User Info";
            this.miCurrentUserInfo.Click += new System.EventHandler(this.miCurrentUserInfo_Click);
            // 
            // miChangePassword
            // 
            this.miChangePassword.Image = global::DrivingLicense.Presentation.Properties.Resources.Password_32;
            this.miChangePassword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miChangePassword.Name = "miChangePassword";
            this.miChangePassword.Size = new System.Drawing.Size(257, 38);
            this.miChangePassword.Text = "Change Password";
            this.miChangePassword.Click += new System.EventHandler(this.miChangePassword_Click);
            // 
            // miSignOut
            // 
            this.miSignOut.Image = global::DrivingLicense.Presentation.Properties.Resources.sign_out_32__2;
            this.miSignOut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miSignOut.Name = "miSignOut";
            this.miSignOut.Size = new System.Drawing.Size(257, 38);
            this.miSignOut.Text = "Sign Out";
            this.miSignOut.Click += new System.EventHandler(this.miSignOut_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 575);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.ms;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ms.ResumeLayout(false);
            this.ms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms;
        private System.Windows.Forms.ToolStripMenuItem miPeople;
        private System.Windows.Forms.ToolStripMenuItem miUsers;
        private System.Windows.Forms.ToolStripMenuItem miAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem miCurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem miChangePassword;
        private System.Windows.Forms.ToolStripMenuItem miSignOut;
        private System.Windows.Forms.ToolStripMenuItem miDrivers;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem miManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miRenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem miReplacementForDamageOrLostApplication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem miAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem miAddNewInternationalLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem miLocalDrivingLicenseApplicationManagment;
        private System.Windows.Forms.ToolStripMenuItem miManageInternationalLicenseApplications;
    }
}

