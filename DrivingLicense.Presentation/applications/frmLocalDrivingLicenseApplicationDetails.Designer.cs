namespace DrivingLicense.Presentation.applications
{
    partial class frmLocalDrivingLicenseApplicationDetails
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
            this.usrLocalDrivingLicenseApplicationDetails1 = new DrivingLicense.Presentation.controls.usrLocalDrivingLicenseApplicationDetails();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usrLocalDrivingLicenseApplicationDetails1
            // 
            this.usrLocalDrivingLicenseApplicationDetails1.Location = new System.Drawing.Point(39, 3);
            this.usrLocalDrivingLicenseApplicationDetails1.Name = "usrLocalDrivingLicenseApplicationDetails1";
            this.usrLocalDrivingLicenseApplicationDetails1.Size = new System.Drawing.Size(736, 406);
            this.usrLocalDrivingLicenseApplicationDetails1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(653, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLocalDrivingLicenseApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.usrLocalDrivingLicenseApplicationDetails1);
            this.Name = "frmLocalDrivingLicenseApplicationDetails";
            this.Text = "frmLocalDrivingLicenseApplicationDetails";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.usrLocalDrivingLicenseApplicationDetails usrLocalDrivingLicenseApplicationDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}