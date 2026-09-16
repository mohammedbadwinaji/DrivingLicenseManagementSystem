using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;

namespace DrivingLicense.Presentation.users
{
    public partial class frmChangePassword : Form
    {
        private int _UserId;
        public frmChangePassword(int userId)
        {
            InitializeComponent();
            _UserId = userId;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (!clsUser.IsUserExists(_UserId))
            {
                MessageBox.Show("User does not exist.");
                this.Close();
            }

            usrUserDetails1.LoadUserInfo(_UserId);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string validationErrors = string.Empty;
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                validationErrors += "Current Password is required.\n";  
            } else
            {
                if (!clsUser.IsPasswordEqual(_UserId, txtCurrentPassword.Text))
                {
                    validationErrors += "Current Password Is Not Correct \n";
                }
            }
            
            if(string.IsNullOrEmpty(txtNewPassword.Text))
            {
                validationErrors += "New Password is required.\n";
            } else
            {
                if(txtPasswordConfirmation.Text != txtNewPassword.Text)
                {
                    validationErrors += "Password Confirmation does not match New Password.\n";
                }
            }

            if(validationErrors != string.Empty)
            {
                MessageBox.Show(validationErrors, "Validation Error");
                return;
            }

            if (clsUser.ChangePassword(_UserId, txtCurrentPassword.Text,txtNewPassword.Text))
            {
                MessageBox.Show("Password Changed Successfully");
                return;
            }
            MessageBox.Show("Server Error");

        }
    }
}
