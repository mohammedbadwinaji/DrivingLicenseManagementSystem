using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;
using DrivingLicense.BusinessLogic.Licenses;

namespace DrivingLicense.Presentation.licenses
{
    public partial class frmDetainLecense : Form
    {
        private clsDetainedLicense _DetainLicenseInfo;
        public frmDetainLecense()
        {
            InitializeComponent();
        }

        private void _ResetForm()
        {
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            btnDetain.Enabled = false;

            lblDetainID.Text = "???";
            lblLicenseID.Text = "???";
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsSettings.CurrentLoggedInUser.UserName;
            txtFineFees.Clear();
            txtFineFees.Enabled = true;



            int licenseId = usrLicenseFilter1.GetLicenseID();

            if (licenseId == -1)
            {
                return;
            }

            else
            {
                llShowLicenseHistory.Enabled = true;
                llShowLicenseInfo.Enabled = true;
            }

            if(_DetainLicenseInfo != null && _DetainLicenseInfo.DetainID != -1)
            {
                usrLicenseFilter1.DisableFilter();
                lblDetainID.Text = _DetainLicenseInfo.DetainID.ToString();
                lblLicenseID.Text = _DetainLicenseInfo.LicenseID.ToString();
                lblDetainDate.Text = _DetainLicenseInfo.DetainDate.ToShortDateString();
                lblCreatedBy.Text = _DetainLicenseInfo.GetCreatedByUsername;
                txtFineFees.Text = _DetainLicenseInfo.FineFees.ToString();
                txtFineFees.Enabled = false;
                llShowLicenseInfo.Enabled = true;
                return;
            }
            clsDetainedLicense lastLicenseDetain = clsDetainedLicense.GetLastDetainedPerLicenseID(licenseId);

            if (lastLicenseDetain == null)
            {
                btnDetain.Enabled = true;
                return;
            }

            if( lastLicenseDetain.IsReleased)
            {
                btnDetain.Enabled = true;
            }
            else
            {
                lblDetainID.Text = lastLicenseDetain.DetainID.ToString();
                lblLicenseID.Text = lastLicenseDetain.LicenseID.ToString();
                lblDetainDate.Text = lastLicenseDetain.DetainDate.ToShortDateString();
                lblCreatedBy.Text = lastLicenseDetain.GetCreatedByUsername;
                txtFineFees.Text = lastLicenseDetain.FineFees.ToString();
                txtFineFees.Enabled = false;
            }

            
            
        }
        private void frmDetainLecense_Load(object sender, EventArgs e)
        {
            _ResetForm();
            usrLicenseFilter1.OnSearch += _HandleLicenseSearch;
        }
        private void _HandleLicenseSearch(int licenseId)
        {
            clsDetainedLicense lastLicenseDetain = clsDetainedLicense.GetLastDetainedPerLicenseID(licenseId);

            if(lastLicenseDetain != null)
            {
                if(lastLicenseDetain.IsReleased == false)
                {
                    MessageBox.Show("Selected License Already Detained Choose Another One");
                    _ResetForm();
                    return;
                }
            }
            _ResetForm();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();

            if(license == null)
            {
                MessageBox.Show("No Person To show licenses hisotory for him");
                return;
            }

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(license.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();

            if (license == null)
            {
                MessageBox.Show("No License Selected To Show Info");
                return;
            }

            frmShowLicenseDetails frm = new frmShowLicenseDetails(license.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Enter Fine Fees");
                return;
            }
            int licenseId = usrLicenseFilter1.GetLicenseID();

            _DetainLicenseInfo = new clsDetainedLicense();
            _DetainLicenseInfo.LicenseID = licenseId;
            _DetainLicenseInfo.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
            _DetainLicenseInfo.DetainDate = DateTime.Now;
            _DetainLicenseInfo.FineFees = Convert.ToDecimal(txtFineFees.Text);
            string errorMessage;

            if (_DetainLicenseInfo.Save(out errorMessage))
            {
                MessageBox.Show($"License {_DetainLicenseInfo.LicenseID} Detained Successfully");
                _ResetForm();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
