namespace DrivingLicense.Presentation
{
    partial class frmTest
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
            this.btnGetAllPeople = new System.Windows.Forms.Button();
            this.btnViewPersonDetails = new System.Windows.Forms.Button();
            this.btnInsertNewPerson = new System.Windows.Forms.Button();
            this.btnUpdatePerson = new System.Windows.Forms.Button();
            this.btnViewAllCountries = new System.Windows.Forms.Button();
            this.btnGetCountryByID = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetAllPeople
            // 
            this.btnGetAllPeople.Location = new System.Drawing.Point(7, 12);
            this.btnGetAllPeople.Name = "btnGetAllPeople";
            this.btnGetAllPeople.Size = new System.Drawing.Size(195, 75);
            this.btnGetAllPeople.TabIndex = 0;
            this.btnGetAllPeople.Text = "View People";
            this.btnGetAllPeople.UseVisualStyleBackColor = true;
            // 
            // btnViewPersonDetails
            // 
            this.btnViewPersonDetails.Location = new System.Drawing.Point(256, 12);
            this.btnViewPersonDetails.Name = "btnViewPersonDetails";
            this.btnViewPersonDetails.Size = new System.Drawing.Size(195, 75);
            this.btnViewPersonDetails.TabIndex = 1;
            this.btnViewPersonDetails.Text = "View Person details";
            this.btnViewPersonDetails.UseVisualStyleBackColor = true;
            this.btnViewPersonDetails.Click += new System.EventHandler(this.btnViewPersonDetails_Click);
            // 
            // btnInsertNewPerson
            // 
            this.btnInsertNewPerson.Location = new System.Drawing.Point(7, 93);
            this.btnInsertNewPerson.Name = "btnInsertNewPerson";
            this.btnInsertNewPerson.Size = new System.Drawing.Size(195, 75);
            this.btnInsertNewPerson.TabIndex = 2;
            this.btnInsertNewPerson.Text = "Insert New Person";
            this.btnInsertNewPerson.UseVisualStyleBackColor = true;
            this.btnInsertNewPerson.Click += new System.EventHandler(this.btnInsertNewPerson_Click);
            // 
            // btnUpdatePerson
            // 
            this.btnUpdatePerson.Location = new System.Drawing.Point(256, 93);
            this.btnUpdatePerson.Name = "btnUpdatePerson";
            this.btnUpdatePerson.Size = new System.Drawing.Size(195, 75);
            this.btnUpdatePerson.TabIndex = 3;
            this.btnUpdatePerson.Text = "Update Person";
            this.btnUpdatePerson.UseVisualStyleBackColor = true;
            this.btnUpdatePerson.Click += new System.EventHandler(this.btnUpdatePerson_Click);
            // 
            // btnViewAllCountries
            // 
            this.btnViewAllCountries.Location = new System.Drawing.Point(7, 174);
            this.btnViewAllCountries.Name = "btnViewAllCountries";
            this.btnViewAllCountries.Size = new System.Drawing.Size(195, 75);
            this.btnViewAllCountries.TabIndex = 4;
            this.btnViewAllCountries.Text = "view all countries";
            this.btnViewAllCountries.UseVisualStyleBackColor = true;
            // 
            // btnGetCountryByID
            // 
            this.btnGetCountryByID.Location = new System.Drawing.Point(256, 174);
            this.btnGetCountryByID.Name = "btnGetCountryByID";
            this.btnGetCountryByID.Size = new System.Drawing.Size(195, 75);
            this.btnGetCountryByID.TabIndex = 5;
            this.btnGetCountryByID.Text = "View Country Details";
            this.btnGetCountryByID.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(466, 174);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(195, 75);
            this.btnTest.TabIndex = 6;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnGetCountryByID);
            this.Controls.Add(this.btnViewAllCountries);
            this.Controls.Add(this.btnUpdatePerson);
            this.Controls.Add(this.btnInsertNewPerson);
            this.Controls.Add(this.btnViewPersonDetails);
            this.Controls.Add(this.btnGetAllPeople);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllPeople;
        private System.Windows.Forms.Button btnViewPersonDetails;
        private System.Windows.Forms.Button btnInsertNewPerson;
        private System.Windows.Forms.Button btnUpdatePerson;
        private System.Windows.Forms.Button btnViewAllCountries;
        private System.Windows.Forms.Button btnGetCountryByID;
        private System.Windows.Forms.Button btnTest;
    }
}