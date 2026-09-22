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
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.BusinessLogic.Licenses;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.Presentation.licenses;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmRenewLicenseApplication : Form
    {
        private clsLicense _OldLicenseID;


        private clsLicense _NewLicense;
        public frmRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmRenewLicenseApplication_Load(object sender, EventArgs e)
        {
            llShowLicenseHistory.Enabled = false;
            llShowNewLicenseInfo.Enabled = false;
            btnRenew.Enabled = false;

            lblApplicationFees.Text = clsApplicationType.FindByID((int)enApplicationType.RenewDrivingLicenseService).ApplicationTypeFees.ToString();
            lblCreaedByUsername.Text = clsSettings.CurrentLoggedInUser.UserName;
            
            usrLicenseFilter1.OnSearch += _HandleLicenseSearch;
        }

        private void _LoadInfo()
        {
            clsLicense oldLicense = usrLicenseFilter1.GetLicenseInfo();

            if (oldLicense == null) return;

            lblOldLicenseID.Text = oldLicense.LicenseID.ToString();
            lblLicenseFees.Text = clsLicenseClass.FindByID((int)oldLicense.LicenseClass).ClassFess.ToString();
            lblTotalFees.Text = (Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblLicenseFees.Text)).ToString();

            if (_NewLicense == null) return;
            clsRenewLocalLicenseApplication renewApplication = clsRenewLocalLicenseApplication.FindByID(_NewLicense.ApplicationID);

            lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();
            lblRenewLicenseApplicationID.Text = _NewLicense.ApplicationID.ToString();
            lblApplicationDate.Text = renewApplication.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = _NewLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _NewLicense.ExpirationDate.ToShortDateString();
        }
        private void _HandleLicenseSearch(int licenseId)
        {
            clsLicense oldLicense = usrLicenseFilter1.GetLicenseInfo();

            if(oldLicense == null)
            {
                llShowLicenseHistory.Enabled = false;
                llShowNewLicenseInfo.Enabled = false;
                btnClose.Enabled = false;
                return;
            }

            llShowLicenseHistory.Enabled = true;

            if(oldLicense.ExpirationDate < DateTime.Today)
            {
                
                MessageBox.Show($"Selected License Is Not Expired Yet , It Will Expire On {oldLicense.ExpirationDate.ToShortTimeString()}");
                return;
            }

            if (!oldLicense.IsActive)
            {
                MessageBox.Show($"Selected License Is Not Active, Choose Another One");
                return;
            }

            btnRenew.Enabled = true;
            _LoadInfo();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            _NewLicense = new clsLicense();
            _NewLicense.PaidFees = Convert.ToDecimal(lblTotalFees.Text);
            _NewLicense.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
            _NewLicense.Notes = txtNotes.Text;

            string errorMessage;
            if (_NewLicense.Renew(usrLicenseFilter1.GetLicenseID(), out errorMessage))
            {
                MessageBox.Show("License Renew Successfully");
                usrLicenseFilter1.DisableFilter();
                llShowLicenseHistory.Enabled = true;
                llShowNewLicenseInfo.Enabled = true;
                btnRenew.Enabled = false;
                _LoadInfo();
            } else
            {
                MessageBox.Show(errorMessage);
            }
            
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_NewLicense == null)
            {
                MessageBox.Show("No New License Added");
                return;
            }

            frmShowLicenseDetails frm = new frmShowLicenseDetails(_NewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if (license == null)
            {
                MessageBox.Show("No Person To Show License History");
                return;
            }
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(license.PersonID);
            frm.ShowDialog();
            
        }
    }
}
