using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.Presentation.people;

namespace DrivingLicense.Presentation.controls
{
    public partial class usrLocalDrivingLicenseApplicationDetails : UserControl
    {

        public event Action<int> OnPersonalInformationSaved;
        int _CurrentLocalDrivingLicenseApplicationID;
        clsLocalDrivingLicenseApplication _ldlApp;
        public usrLocalDrivingLicenseApplicationDetails()
        {
            InitializeComponent();
            _CurrentLocalDrivingLicenseApplicationID = -1;
            _ldlApp = null;
        }
        private void _SetDefaultData()
        {
            lblLDLAID.Text = "???";
            lblLicenseClass.Text = "???";
            llShowLicenseInfo.Enabled = false;
            pbLicense.Enabled = false;
            lblPassedTests.Text = "???";

            lblApplicationID.Text = "???";
            lblStatus.Text = "???";
            lblType.Text = "???";
            lblFees.Text = "???";
            lblApplicant.Text = "???";
            lblDate.Text = "???";
            lblStatusDate.Text = "???";
            lblCreatedBy.Text = "???";
            llViewPersonInfo.Enabled = false;

            _CurrentLocalDrivingLicenseApplicationID = -1
                ;
            _ldlApp = null;
        }

        public void LoadLocalDrivingLicenseInfo(int localDrivingLicenseApplicationId)
        {

            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.FindByID(localDrivingLicenseApplicationId);

            if(ldlApp == null)
            {
                _SetDefaultData();
                MessageBox.Show($"No L D L Application With ID {localDrivingLicenseApplicationId}");
                return;
            }
            lblLDLAID.Text = ldlApp.LocalDrivingLicenseApplicationsID.ToString() ;
            lblLicenseClass.Text = ldlApp.LicenseClassName;
            
            llShowLicenseInfo.Enabled = ldlApp.LicenseID != -1;
            pbLicense.Enabled = ldlApp.LicenseID != -1;
            lblPassedTests.Text =ldlApp.PassedTests.ToString();

            lblApplicationID.Text = ldlApp.ApplicationID.ToString();
            lblStatus.Text = ldlApp.ApplicationStatusTitle;
            lblType.Text = ldlApp.ApplicationTypeTitle;
            lblFees.Text = ldlApp.PaidFees.ToString();
            lblApplicant.Text = ldlApp.ApplicantFullName;
            lblDate.Text = ldlApp.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = ldlApp.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = ldlApp.CreatedByUserName;
            llViewPersonInfo.Enabled = ldlApp.ApplicantPersonID != -1;

            _CurrentLocalDrivingLicenseApplicationID = ldlApp.LocalDrivingLicenseApplicationsID;
            _ldlApp = ldlApp;

            
        }


        private void usrLocalDrivingLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
            _SetDefaultData();
        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_ldlApp.ApplicantPersonID);
            frm.OnSave += _HandleApplicantPersonSave;
            frm.ShowDialog();
        }
        private void _HandleApplicantPersonSave(int personId)
        {
            LoadLocalDrivingLicenseInfo(_CurrentLocalDrivingLicenseApplicationID);
            OnPersonalInformationSaved?.Invoke(personId);
        }
    }
}
