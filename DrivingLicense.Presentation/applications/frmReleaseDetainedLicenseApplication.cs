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
using DrivingLicense.BusinessLogic.Licenses;
using DrivingLicense.Presentation.licenses;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private clsDetainedLicense _DetainedLicense;
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        private void _ResetForm()
        {
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            btnRelease.Enabled = false;

            lblDetainID.Text = "???";
            lblLicenseID.Text = "???";
            lblDetainDate.Text = DateTime.Today.ToShortDateString();
            lblCreaedByUsername.Text = clsSettings.CurrentLoggedInUser.UserName;
            lblApplicationFees.Text = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.ReleaseDetainedDrivingLicsense).ToString();
            lblFineFees.Text = "???";
            lblTotalFees.Text = "???";
            lblReleaseApplicationID.Text = "???";


            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if (license == null) return;

            llShowLicenseHistory.Enabled = true;
            llShowLicenseInfo.Enabled = true;


            decimal applicationFees = 0;
            decimal fineFees = 0;
            if (_DetainedLicense != null)
            {

                usrLicenseFilter1.DisableFilter();
                lblDetainID.Text = _DetainedLicense.DetainID.ToString();
                lblLicenseID.Text = _DetainedLicense.LicenseID.ToString();
                lblDetainDate.Text = _DetainedLicense.DetainDate.ToShortDateString();
                lblCreaedByUsername.Text = _DetainedLicense.GetCreatedByUsername;
                 applicationFees = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.ReleaseDetainedDrivingLicsense);
                lblApplicationFees.Text = applicationFees.ToString();
                 fineFees = _DetainedLicense.FineFees;
                lblFineFees.Text = fineFees.ToString();
                lblTotalFees.Text =(applicationFees + fineFees).ToString();
                lblReleaseApplicationID.Text = _DetainedLicense.ReleaseApplicationID?.ToString();
                btnRelease.Enabled = false;
                    return;
            }


            clsDetainedLicense detainedLicense = clsDetainedLicense.GetLastDetainedPerLicenseID(license.LicenseID);

            if (detainedLicense == null) return;
            lblDetainID.Text = detainedLicense.DetainID.ToString();
            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();
            lblCreaedByUsername.Text = detainedLicense.GetCreatedByUsername;
             applicationFees = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.ReleaseDetainedDrivingLicsense);
            lblApplicationFees.Text = applicationFees.ToString();
             fineFees = detainedLicense.FineFees;
            lblFineFees.Text = fineFees.ToString();
            lblTotalFees.Text = (applicationFees + fineFees).ToString();
            lblReleaseApplicationID.Text = detainedLicense.ReleaseApplicationID?.ToString() ?? "???";

            if (detainedLicense.IsReleased)
            {
            btnRelease.Enabled = false;

            } else
            {
                btnRelease.Enabled = true;
            }
            

        }
        private void frmRelaseDetainedLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetForm();
            usrLicenseFilter1.OnSearch += _HandleLicenseSearch;
        }
        private void _HandleLicenseSearch(int licenseId)
        {
            _ResetForm();

            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if(license == null)
            {
                return;
            }
            clsDetainedLicense detainLicense = clsDetainedLicense.GetLastDetainedPerLicenseID(license.LicenseID);

            if (
                detainLicense == null ||
                (detainLicense != null &&
                detainLicense.IsReleased)
                )
            {
                MessageBox.Show("Selected License Is Not Detained , Choose Another License");
                return;
            }
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if (license == null)
            {
                MessageBox.Show("No License Selected To Release");
                return;
            }
            clsDetainedLicense detainLicense = clsDetainedLicense.GetLastDetainedPerLicenseID(license.LicenseID);

            if (
               detainLicense == null ||
               (detainLicense != null &&
               detainLicense.IsReleased)
               )
            {
                MessageBox.Show("Selected License Is Not Detained , Choose Another License");
                return;
            }


            string errorMessage;
            if(license.Release(clsSettings.CurrentLoggedInUser.UserId,out errorMessage))
            {
                MessageBox.Show("License Release Successfully");
                _DetainedLicense = clsDetainedLicense.GetLastDetainedPerLicenseID(license.LicenseID);
                _ResetForm();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if(license == null)
            {
                MessageBox.Show("There Is No Person To Show License History For Him");
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
                MessageBox.Show("No License Selected To Show");
                return;
            }
            frmShowLicenseDetails frm = new frmShowLicenseDetails(license.LicenseID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
