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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        public event Action<int> OnLicenseIssued;

        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LDLAppInfo;

        private clsLicense _LicenseInfo;
        public frmIssueDrivingLicenseFirstTime(int localDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLAppInfo = clsLocalDrivingLicenseApplication.FindByID(_LocalDrivingLicenseApplicationID);
            if(_LDLAppInfo == null)
            {
                MessageBox.Show($"No Application With ID {_LocalDrivingLicenseApplicationID}");
                this.Close();
                return;
            }

            usrLocalDrivingLicenseApplicationDetails1.LoadLocalDrivingLicenseInfo(_LocalDrivingLicenseApplicationID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadLicenseInfo()
        {
            _LicenseInfo = new clsLicense();
            _LicenseInfo.ApplicationID = _LDLAppInfo.ApplicationID;
            _LicenseInfo.Notes = txtNotes.Text;
            _LicenseInfo.LicenseClass = _LDLAppInfo.LicenseClass;
            _LicenseInfo.PersonID = _LDLAppInfo.ApplicantPersonID;
            _LicenseInfo.PaidFees = clsApplicationType.GetFees(BusinessLogic.Models.enApplicationType.NewLocalDrivingLicenseService);
            _LicenseInfo.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_LDLAppInfo.LicenseID != -1)
            {
                MessageBox.Show("You Aleady Issued The License");
                this.Close();
                return;
            }
            _LoadLicenseInfo();

            string errorMessage;
            if (_LicenseInfo.IssueFirstTime(out errorMessage))
            {
                MessageBox.Show($"License Issued Successfully With License ID {_LicenseInfo.LicenseID}");
                this.Close();
                OnLicenseIssued?.Invoke(_LicenseInfo.LicenseID);
                return;
            } else
            {
                MessageBox.Show(errorMessage);
            }

        }
    }
}
