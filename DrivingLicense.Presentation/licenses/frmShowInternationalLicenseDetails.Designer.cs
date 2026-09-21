namespace DrivingLicense.Presentation.licenses
{
    partial class frmShowInternationalLicenseDetails
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.usrInternationalLicenseDetails1 = new DrivingLicense.Presentation.controls.usrInternationalLicenseDetails();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(227, 116);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(457, 34);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "Driver International License Info";
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DrivingLicense.Presentation.Properties.Resources.LicenseView_400;
            this.pbImage.Location = new System.Drawing.Point(361, 23);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(188, 90);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 20;
            this.pbImage.TabStop = false;
            // 
            // usrInternationalLicenseDetails1
            // 
            this.usrInternationalLicenseDetails1.Location = new System.Drawing.Point(12, 171);
            this.usrInternationalLicenseDetails1.Name = "usrInternationalLicenseDetails1";
            this.usrInternationalLicenseDetails1.Size = new System.Drawing.Size(860, 316);
            this.usrInternationalLicenseDetails1.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(739, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowInternationalLicenseDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 531);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.usrInternationalLicenseDetails1);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmShowInternationalLicenseDetails";
            this.Text = "frmShowInternationalLicenseDetails";
            this.Load += new System.EventHandler(this.frmShowInternationalLicenseDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblTitle;
        private controls.usrInternationalLicenseDetails usrInternationalLicenseDetails1;
        private System.Windows.Forms.Button btnClose;
    }
}