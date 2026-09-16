namespace DrivingLicense.Presentation.users
{
    partial class frmAddEditUser
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
            this.tbUser = new System.Windows.Forms.TabControl();
            this.tbpPersonalInformation = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.usrPersonFilter1 = new DrivingLicense.Presentation.controls.usrPersonFilter();
            this.tbpUserInformation = new System.Windows.Forms.TabPage();
            this.btnPrev = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtPasswordConfirmation = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbUser.SuspendLayout();
            this.tbpPersonalInformation.SuspendLayout();
            this.tbpUserInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("MV Boli", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(348, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(78, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Title";
            // 
            // tbUser
            // 
            this.tbUser.Controls.Add(this.tbpPersonalInformation);
            this.tbUser.Controls.Add(this.tbpUserInformation);
            this.tbUser.Location = new System.Drawing.Point(4, 58);
            this.tbUser.Name = "tbUser";
            this.tbUser.SelectedIndex = 0;
            this.tbUser.Size = new System.Drawing.Size(818, 482);
            this.tbUser.TabIndex = 4;
            this.tbUser.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbUser_Selecting);
            // 
            // tbpPersonalInformation
            // 
            this.tbpPersonalInformation.Controls.Add(this.btnNext);
            this.tbpPersonalInformation.Controls.Add(this.usrPersonFilter1);
            this.tbpPersonalInformation.Location = new System.Drawing.Point(4, 22);
            this.tbpPersonalInformation.Name = "tbpPersonalInformation";
            this.tbpPersonalInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPersonalInformation.Size = new System.Drawing.Size(810, 456);
            this.tbpPersonalInformation.TabIndex = 0;
            this.tbpPersonalInformation.Text = "Personal Information";
            this.tbpPersonalInformation.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DrivingLicense.Presentation.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(641, 411);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(122, 33);
            this.btnNext.TabIndex = 48;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // usrPersonFilter1
            // 
            this.usrPersonFilter1.Location = new System.Drawing.Point(4, 6);
            this.usrPersonFilter1.Name = "usrPersonFilter1";
            this.usrPersonFilter1.Size = new System.Drawing.Size(802, 399);
            this.usrPersonFilter1.TabIndex = 6;
            // 
            // tbpUserInformation
            // 
            this.tbpUserInformation.Controls.Add(this.btnPrev);
            this.tbpUserInformation.Controls.Add(this.chkIsActive);
            this.tbpUserInformation.Controls.Add(this.txtPasswordConfirmation);
            this.tbpUserInformation.Controls.Add(this.pictureBox4);
            this.tbpUserInformation.Controls.Add(this.label4);
            this.tbpUserInformation.Controls.Add(this.txtPassword);
            this.tbpUserInformation.Controls.Add(this.pictureBox2);
            this.tbpUserInformation.Controls.Add(this.label2);
            this.tbpUserInformation.Controls.Add(this.txtUsername);
            this.tbpUserInformation.Controls.Add(this.pictureBox3);
            this.tbpUserInformation.Controls.Add(this.label3);
            this.tbpUserInformation.Controls.Add(this.pictureBox1);
            this.tbpUserInformation.Controls.Add(this.lblUserID);
            this.tbpUserInformation.Controls.Add(this.label1);
            this.tbpUserInformation.Location = new System.Drawing.Point(4, 22);
            this.tbpUserInformation.Name = "tbpUserInformation";
            this.tbpUserInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUserInformation.Size = new System.Drawing.Size(810, 461);
            this.tbpUserInformation.TabIndex = 1;
            this.tbpUserInformation.Text = "User Info";
            this.tbpUserInformation.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Image = global::DrivingLicense.Presentation.Properties.Resources.Prev_32;
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(641, 411);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(122, 33);
            this.btnPrev.TabIndex = 49;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(180, 269);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(81, 22);
            this.chkIsActive.TabIndex = 34;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtPasswordConfirmation
            // 
            this.txtPasswordConfirmation.Location = new System.Drawing.Point(232, 211);
            this.txtPasswordConfirmation.Name = "txtPasswordConfirmation";
            this.txtPasswordConfirmation.Size = new System.Drawing.Size(194, 20);
            this.txtPasswordConfirmation.TabIndex = 33;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DrivingLicense.Presentation.Properties.Resources.Password_32;
            this.pictureBox4.Location = new System.Drawing.Point(180, 203);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(34, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "Confirm Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(232, 156);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(194, 20);
            this.txtPassword.TabIndex = 30;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DrivingLicense.Presentation.Properties.Resources.Password_32;
            this.pictureBox2.Location = new System.Drawing.Point(180, 148);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Password :";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(232, 101);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(194, 20);
            this.txtUsername.TabIndex = 27;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DrivingLicense.Presentation.Properties.Resources.Person_32;
            this.pictureBox3.Location = new System.Drawing.Point(180, 93);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 26;
            this.pictureBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Username :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DrivingLicense.Presentation.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(180, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(229, 50);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(31, 16);
            this.lblUserID.TabIndex = 13;
            this.lblUserID.Text = "???";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "User ID :";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DrivingLicense.Presentation.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(698, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 33);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DrivingLicense.Presentation.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(554, 550);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 33);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 592);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmAddEditUser";
            this.Text = "frmAddEditUser";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tbUser.ResumeLayout(false);
            this.tbpPersonalInformation.ResumeLayout(false);
            this.tbpUserInformation.ResumeLayout(false);
            this.tbpUserInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tbUser;
        private System.Windows.Forms.TabPage tbpPersonalInformation;
        private controls.usrPersonFilter usrPersonFilter1;
        private System.Windows.Forms.TabPage tbpUserInformation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPasswordConfirmation;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnPrev;
    }
}