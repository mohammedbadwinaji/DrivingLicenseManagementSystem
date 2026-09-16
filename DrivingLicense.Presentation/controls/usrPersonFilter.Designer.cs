namespace DrivingLicense.Presentation.controls
{
    partial class usrPersonFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbPersonFilter = new System.Windows.Forms.GroupBox();
            this.btnSearchPerson = new System.Windows.Forms.Button();
            this.frmAddPerson = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cmbFilterOptions = new System.Windows.Forms.ComboBox();
            this.usrPersonDetails1 = new DrivingLicense.Presentation.controls.usrPersonDetails();
            this.gbPersonFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPersonFilter
            // 
            this.gbPersonFilter.Controls.Add(this.btnSearchPerson);
            this.gbPersonFilter.Controls.Add(this.frmAddPerson);
            this.gbPersonFilter.Controls.Add(this.txtFilterValue);
            this.gbPersonFilter.Controls.Add(this.cmbFilterOptions);
            this.gbPersonFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPersonFilter.Location = new System.Drawing.Point(0, 0);
            this.gbPersonFilter.Name = "gbPersonFilter";
            this.gbPersonFilter.Size = new System.Drawing.Size(802, 97);
            this.gbPersonFilter.TabIndex = 0;
            this.gbPersonFilter.TabStop = false;
            this.gbPersonFilter.Text = "Filter";
            // 
            // btnSearchPerson
            // 
            this.btnSearchPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPerson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchPerson.FlatAppearance.BorderSize = 2;
            this.btnSearchPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSearchPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearchPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPerson.Image = global::DrivingLicense.Presentation.Properties.Resources.SearchPerson;
            this.btnSearchPerson.Location = new System.Drawing.Point(536, 28);
            this.btnSearchPerson.Name = "btnSearchPerson";
            this.btnSearchPerson.Size = new System.Drawing.Size(59, 40);
            this.btnSearchPerson.TabIndex = 11;
            this.btnSearchPerson.UseVisualStyleBackColor = true;
            this.btnSearchPerson.Click += new System.EventHandler(this.btnSearchPerson_Click);
            // 
            // frmAddPerson
            // 
            this.frmAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.frmAddPerson.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.frmAddPerson.FlatAppearance.BorderSize = 2;
            this.frmAddPerson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.frmAddPerson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.frmAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frmAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmAddPerson.Image = global::DrivingLicense.Presentation.Properties.Resources.AddPerson_321;
            this.frmAddPerson.Location = new System.Drawing.Point(616, 28);
            this.frmAddPerson.Name = "frmAddPerson";
            this.frmAddPerson.Size = new System.Drawing.Size(59, 40);
            this.frmAddPerson.TabIndex = 10;
            this.frmAddPerson.UseVisualStyleBackColor = true;
            this.frmAddPerson.Click += new System.EventHandler(this.frmAddPerson_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(277, 48);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(191, 20);
            this.txtFilterValue.TabIndex = 9;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cmbFilterOptions
            // 
            this.cmbFilterOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterOptions.FormattingEnabled = true;
            this.cmbFilterOptions.Location = new System.Drawing.Point(20, 47);
            this.cmbFilterOptions.Name = "cmbFilterOptions";
            this.cmbFilterOptions.Size = new System.Drawing.Size(218, 21);
            this.cmbFilterOptions.TabIndex = 8;
            this.cmbFilterOptions.SelectedIndexChanged += new System.EventHandler(this.cmbFilterOptions_SelectedIndexChanged);
            // 
            // usrPersonDetails1
            // 
            this.usrPersonDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrPersonDetails1.Location = new System.Drawing.Point(0, 97);
            this.usrPersonDetails1.Name = "usrPersonDetails1";
            this.usrPersonDetails1.Size = new System.Drawing.Size(802, 322);
            this.usrPersonDetails1.TabIndex = 1;
            // 
            // usrPersonFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usrPersonDetails1);
            this.Controls.Add(this.gbPersonFilter);
            this.Name = "usrPersonFilter";
            this.Size = new System.Drawing.Size(802, 419);
            this.Load += new System.EventHandler(this.usrPersonFilter_Load);
            this.gbPersonFilter.ResumeLayout(false);
            this.gbPersonFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPersonFilter;
        private usrPersonDetails usrPersonDetails1;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cmbFilterOptions;
        private System.Windows.Forms.Button btnSearchPerson;
        private System.Windows.Forms.Button frmAddPerson;
    }
}
