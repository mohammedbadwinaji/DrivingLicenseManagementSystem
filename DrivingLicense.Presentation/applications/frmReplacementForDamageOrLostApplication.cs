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
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.BusinessLogic.Licenses;
using DrivingLicense.Presentation.licenses;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmReplacementForDamageOrLostApplication : Form
    {
        private clsLicense _NewLicense;
        public frmReplacementForDamageOrLostApplication()
        {
            InitializeComponent();
        }

        private void frmReplacementForDamageOrLostApplication_Load(object sender, EventArgs e)
        {
            _ResetForm();
        }
        private void _HandleLicenseSearch(int licenseId)
        {
            llShowLicenseHistory.Enabled = false;
            llShowNewLicenseInfo.Enabled = false;
            btnReplacement.Enabled = false;
            clsLicense license = clsLicense.FindByID(licenseId);
            if(license == null)
            {
                return;
            }
            llShowLicenseHistory.Enabled = true;
            if (!license.IsActive)
            {
                llShowLicenseHistory.Enabled = true;
                MessageBox.Show("Selected License Is DisActive , Choose An Active License");
                return;
            }

            btnReplacement.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _SetDefault()
        {
            rbDamageLicense.Checked = true;
            lblTitle.Text = "Replacement For Damaged License";

            llShowLicenseHistory.Enabled = false;
            llShowNewLicenseInfo.Enabled = false;
            btnReplacement.Enabled = false;

            if (rbDamageLicense.Checked)
            {
                lblApplicationFees.Text = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.ReplacementForADamagedDrivingLicense).ToString();
            }
            else
            {
                lblApplicationFees.Text = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.ReplacementForALostDrivingLicense).ToString();
            }
            lblCreaedByUsername.Text = clsSettings.CurrentLoggedInUser.UserName;
            usrLicenseFilter1.OnSearch += _HandleLicenseSearch;

        }
        private void _ResetForm()
        {
            _SetDefault();

            clsLicense oldLicense = usrLicenseFilter1.GetLicenseInfo();

            if (oldLicense == null) return;

            lblOldLicenseID.Text = oldLicense.LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;

            if (_NewLicense == null) return;
            llShowNewLicenseInfo.Enabled = true;

            if(_NewLicense.IssueReason == BusinessLogic.Models.enLicenseIssueReason.ReplacementForDamage)
            {
                rbDamageLicense.Checked = true;
            }
            else
            {
                rbLostLicense.Checked = true;
            }
            
            lblReplacementLicenseApplicationID.Text = _NewLicense.ApplicationID.ToString();
            lblRenewedLicenseID.Text = _NewLicense.LicenseID.ToString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
           


        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            clsLicense oldLicense = usrLicenseFilter1.GetLicenseInfo();

            _NewLicense = new clsLicense();
            _NewLicense.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;

            string errorMessage;
            if (rbDamageLicense.Checked) {
                if(_NewLicense.ReplacementForDamage(oldLicense.LicenseID, out errorMessage))
                {
                    MessageBox.Show($"License Replaced Successfully With ID{_NewLicense.LicenseID}");
                    _ResetForm();
                    usrLicenseFilter1.DisableFilter();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            } else
            {
                if (_NewLicense.ReplacementForLost(oldLicense.LicenseID, out errorMessage))
                {
                    MessageBox.Show($"License Replaced Successfully With ID{_NewLicense.LicenseID}");
                    _ResetForm();
                    usrLicenseFilter1.DisableFilter();
                } else
                {
                    MessageBox.Show(errorMessage);
                }
            }

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if(license == null)
            {
                MessageBox.Show("No Person Selected To View History");
                return;
            }
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(license.PersonID);
            frm.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (_NewLicense == null)
            {
                MessageBox.Show("No New License Exists To Show Details");
                return;
            }
            frmShowLicenseDetails frm = new frmShowLicenseDetails(_NewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void rbDamageLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Damage License";
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Lost License";
        }
    }
}
