namespace DrivingLicense.Presentation.licenses
{
    partial class frmPersonLicenseHistory
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
            this.usrPersonLicenses1 = new DrivingLicense.Presentation.controls.usrPersonLicenses();
            this.usrPersonFilter1 = new DrivingLicense.Presentation.controls.usrPersonFilter();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(401, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(221, 34);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "License History";
            // 
            // pbImage
            // 
            this.pbImage.Image = global::DrivingLicense.Presentation.Properties.Resources.PersonLicenseHistory_512;
            this.pbImage.Location = new System.Drawing.Point(33, 231);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(188, 163);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 21;
            this.pbImage.TabStop = false;
            // 
            // usrPersonLicenses1
            // 
            this.usrPersonLicenses1.Location = new System.Drawing.Point(103, 480);
            this.usrPersonLicenses1.Name = "usrPersonLicenses1";
            this.usrPersonLicenses1.Size = new System.Drawing.Size(904, 212);
            this.usrPersonLicenses1.TabIndex = 23;
            // 
            // usrPersonFilter1
            // 
            this.usrPersonFilter1.Location = new System.Drawing.Point(227, 55);
            this.usrPersonFilter1.Name = "usrPersonFilter1";
            this.usrPersonFilter1.Size = new System.Drawing.Size(802, 419);
            this.usrPersonFilter1.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(885, 698);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 736);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.usrPersonLicenses1);
            this.Controls.Add(this.usrPersonFilter1);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmPersonLicenseHistory";
            this.Text = "frmPersonLicenseHistory";
            this.Load += new System.EventHandler(this.frmPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbImage;
        private controls.usrPersonFilter usrPersonFilter1;
        private controls.usrPersonLicenses usrPersonLicenses1;
        private System.Windows.Forms.Button btnClose;
    }
}