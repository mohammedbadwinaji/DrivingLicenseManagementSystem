using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.Presentation.applications;
using DrivingLicense.Presentation.people;
using DrivingLicense.Presentation.tests;
using DrivingLicense.Presentation.users;

namespace DrivingLicense.Presentation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void _CloseAllChildrenForms()
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
            }
        }
        private void _CenterFormHorizontally(Form frm)
        {
            frm.StartPosition = FormStartPosition.Manual;
            int xAxis = (this.Width / 2) - (frm.Width / 2);
            frm.Location = new Point(xAxis, 30);
        }
       
        private void OpenForm(Form frm)
        {
            _CloseAllChildrenForms();

            frm.MdiParent = this;
            _CenterFormHorizontally(frm);
            frm.Show();
        }
        
        private void miPeople_Click(object sender, EventArgs e)
        {
            OpenForm(new frmPeopleManagement());
        }

        private void miSignOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void miCurrentUserInfo_Click(object sender, EventArgs e)
        {
            if(clsSettings.CurrentLoggedInUser == null)
            {
                MessageBox.Show("No Logged In User");
                return;
            }

            OpenForm(new frmUserDetails(clsSettings.CurrentLoggedInUser.UserId, "Current User Information"));
            
        }

        private void miUsers_Click(object sender, EventArgs e)
        {
            OpenForm(new frmUserManagement());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miChangePassword_Click(object sender, EventArgs e)
        {
            OpenForm(new frmChangePassword(clsSettings.CurrentLoggedInUser.UserId));
        }

        private void miManageApplicationTypes_Click(object sender, EventArgs e)
        {
            OpenForm(new frmApplicationTypesManagement());
        }

        private void miManageTestTypes_Click(object sender, EventArgs e)
        {
            OpenForm(new frmTestTypesManagement());
        }

        private void miAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            OpenForm(new frmAddEditLocalDrivingLicenseApplication(-1));
        }

        private void miLocalDrivingLicenseApplicationManagment_Click(object sender, EventArgs e)
        {
            OpenForm(new frmLocalDrivingLicenseApplicationManagment());
        }
    }
}
