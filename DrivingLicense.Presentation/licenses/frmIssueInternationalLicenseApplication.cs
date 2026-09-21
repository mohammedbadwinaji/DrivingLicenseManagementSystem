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

namespace DrivingLicense.Presentation.licenses
{
    public partial class frmIssueInternationalLicenseApplication : Form
    {
        public event Action<int> OnLicenseIssued;

        private clsInternationalLicenseApplication _Application;
        private clsInternationalLicense _InternationalLicense;
        public frmIssueInternationalLicenseApplication()
        {
            InitializeComponent();
            _Application = new clsInternationalLicenseApplication();
            _InternationalLicense = new clsInternationalLicense();
        }

        
        private void frmIssueInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            llShowInternationalLicenseInfo.Enabled = false;
            llShowLicenseHistory.Enabled = false;
            btnIssue.Enabled = false;

            lblFees.Text = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.NewInternationalLicense).ToString();
            lblCreaedByUsername.Text = clsSettings.CurrentLoggedInUser.UserName;

            usrLicenseFilter1.OnSearch += _HandleLocalLicenseSearch;
        }

        private void _LoadInfo()
        {
            lblInternationalApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblInternatinoalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _InternationalLicense.ExpirationDate.ToShortDateString();
            lblCreaedByUsername.Text = _Application.GetCreatedByUserName;
        }
        
        private void _HandleLocalLicenseSearch(int localLicenseId)
        {
            llShowInternationalLicenseInfo.Enabled = false;

            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if(license == null)
            {
                return;
            }
            else
            {
                llShowLicenseHistory.Enabled = true;
            }

            if(license.LicenseClass != BusinessLogic.Models.enLicenseClass.Class3)
            {
                MessageBox.Show("You Only Can Issued License With Class 3");
                return;
            }
            if (!license.IsActive)
            {
                MessageBox.Show("Your Local License Is Not Active");
                return;
            }
            if(license.ExpirationDate < DateTime.Today)
            {
                MessageBox.Show("Your Local License Has Been Expired");
                return;
            }

            clsInternationalLicense internationalLicense = clsInternationalLicense.FindByLocalLicenseID(license.LicenseID);
            if(internationalLicense != null)
            {
                if (internationalLicense.IsActive)
                {

                    MessageBox.Show($"Person Already Has An Active Internatinoal License With ID {internationalLicense.InternationalLicenseID}");
                    _Application = clsInternationalLicenseApplication.FindByID(internationalLicense.ApplicationID);
                    _InternationalLicense = internationalLicense;
                    llShowLicenseHistory.Enabled= true; 
                    llShowInternationalLicenseInfo.Enabled = true;
                    btnIssue.Enabled = false;
                    _LoadInfo();
                    return;
                }
            } 
            
            _Application = new clsInternationalLicenseApplication();
            _InternationalLicense = new clsInternationalLicense() ;
            lblLocalLicenseID.Text = license.LicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            btnIssue.Enabled = true;
            

           
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if(license == null)
            {
                return;
            }

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(license.PersonID);
            frm.ShowDialog();
        }

        private void llShowInternationalLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_InternationalLicense.InternationalLicenseID == -1)
            {
                MessageBox.Show("No International License Exists To Show");
                return;
            }

            frmShowInternationalLicenseDetails frm = new frmShowInternationalLicenseDetails(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();


        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsLicense license = usrLicenseFilter1.GetLicenseInfo();
            if (license == null)
            {
                MessageBox.Show("Choose Local License First");
                return;
            }
            if (license.LicenseClass != BusinessLogic.Models.enLicenseClass.Class3)
            {
                MessageBox.Show("You Only Can Issued License With Class 3");
                return;
            }
            if (!license.IsActive)
            {
                MessageBox.Show("Your Local License Is Not Active");
                return;
            }
            if (license.ExpirationDate < DateTime.Today)
            {
                MessageBox.Show("Your Local License Has Been Expired");
                return;
            }
            lblLocalLicenseID.Text = license.LicenseID.ToString();

            _Application.ApplicantPersonID = license.PersonID;
            _Application.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
            _Application.PaidFees = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.NewInternationalLicense);
            string errorMessage;
            if (_Application.Add(out errorMessage))
            {
                _InternationalLicense.ApplicationID = _Application.ApplicationID;
                _InternationalLicense.DriverID = clsDriver.FindByPersonID(_Application.ApplicantPersonID).DriverID;
                _InternationalLicense.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
                _InternationalLicense.IssuedUsingLocalLicenseID = usrLicenseFilter1.GetLicenseID();
                if (_InternationalLicense.Issue(out errorMessage))
                {
                    MessageBox.Show("License Issued Successfully");
                    _LoadInfo();
                    llShowInternationalLicenseInfo.Enabled = true;
                    usrLicenseFilter1.DisableFilter();
                    btnIssue.Enabled = false;
                    OnLicenseIssued?.Invoke(_InternationalLicense.InternationalLicenseID);
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
