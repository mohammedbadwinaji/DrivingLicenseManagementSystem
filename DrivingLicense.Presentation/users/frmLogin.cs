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
using DrivingLicense.BusinessLogic.Models;

namespace DrivingLicense.Presentation.users
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void _LoadRememberMeData()
        {
            stCredentials credentials = clsRemeberMe.getStoredData();

            if (string.IsNullOrEmpty(credentials.UserName))
            {
                return;
            }
            txtUsername.Text = credentials.UserName;
            txtPassword.Text = credentials.Password;
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _LoadRememberMeData();
            chkRemeberMe.Checked = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string errorMessage;
            clsSettings.CurrentLoggedInUser = clsUser.Login(txtUsername.Text, txtPassword.Text, chkRemeberMe.Checked,out  errorMessage);

            if(clsSettings.CurrentLoggedInUser == null)
            {
                MessageBox.Show(errorMessage);
                return;
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
