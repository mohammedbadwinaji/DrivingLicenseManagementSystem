using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.BusinessLogic.Models;

namespace DrivingLicense.Presentation.tests
{
    public partial class frmAddEditTestAppointment : Form
    {
       private enum enMode
        {
            AddNew,
            Edit
        }
        private enMode _Mode;

        private int _TestAppointmentID;
        private int _LocalDrivingLicenseApplicationID;
        private enTestType _TestType;

        private clsTestAppointment _TestAppointmentInfo;
        private clsLocalDrivingLicenseApplication _LDLAppInfo;
        private clsRetakeTestApplication _RetakeTestApplicationInfo;

        public frmAddEditTestAppointment
            (
            int testAppointmentID,int localDrivingLicenseApplicationId ,enTestType testType
            )
        {
            InitializeComponent();
            _TestAppointmentID = testAppointmentID;
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationId;
            _TestType = testType;
            _RetakeTestApplicationInfo = null;
        }

        private void _ConfigureMode()
        {
            _Mode = _TestAppointmentID == -1 ? enMode.AddNew : enMode.Edit;
        }
        private void _ConfigureImage()
        {
            switch (_TestType)
            {
                case enTestType.Vision:
                    pbImage.ImageLocation = clsImage.VisionTestImagePath;
                    break;
                case enTestType.Written:
                    pbImage.ImageLocation = clsImage.WrittenTestImagePath;
                    break;
                case enTestType.Street:
                    pbImage.ImageLocation = clsImage.StreetTestImagePath;
                    break;
            }
        }
        
        private void _ConfigureFormData()
        {
            if (_Mode == enMode.AddNew) {
                _TestAppointmentInfo = new clsTestAppointment();
                 _LDLAppInfo = clsLocalDrivingLicenseApplication.FindByID(_LocalDrivingLicenseApplicationID);
                lblLDLAppID.Text = _LDLAppInfo.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = _LDLAppInfo.LicenseClass.ToString();
                lblName.Text = _LDLAppInfo.GetApplicantFullName;
                dtpAppointmentDate.Value = DateTime.Today;
                decimal testTypeFees = clsTestType.FindByID((int)_TestType).TestTypeFees;
                lblFees.Text = testTypeFees.ToString();
                int trails = clsTestAppointment.GetTrails(_LocalDrivingLicenseApplicationID, _TestType);
                lblTrail.Text =trails.ToString();  

                if(trails <= 0)
                {
                    gbRetakeTest.Enabled = false;
                    lblRetakeTestID.Text = "N/A";
                    lblRetakTestFees.Text = "0";
                    lblTotalFees.Text = lblFees.Text;
                }
                else
                {
                    gbRetakeTest.Enabled = true;
                    _RetakeTestApplicationInfo = new clsRetakeTestApplication();
                    lblRetakeTestID.Text = "N/A";
                    decimal retakeTestFees = clsApplicationType.GetFees(enApplicationType.RetakeTest);
                    lblRetakTestFees.Text = retakeTestFees.ToString();
                    lblTotalFees.Text = (testTypeFees + retakeTestFees).ToString();
                }
                
            }

            else
            {
                
                _TestAppointmentInfo = clsTestAppointment.FindByID(_TestAppointmentID);
                _RetakeTestApplicationInfo = clsRetakeTestApplication.FindByID(_TestAppointmentInfo.RetakeTestApplicationID);
                _LDLAppInfo = clsLocalDrivingLicenseApplication.FindByID(_TestAppointmentInfo.LocalDrivingLicenseApplicationID);

                lblLDLAppID.Text = _LDLAppInfo.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = _LDLAppInfo.LicenseClass.ToString();
                lblName.Text = _LDLAppInfo.GetApplicantFullName;
                dtpAppointmentDate.Value = DateTime.Today;
                decimal testTypeFees = clsTestType.FindByID((int)_TestType).TestTypeFees;
                lblFees.Text = testTypeFees.ToString();
                int trails = clsTestAppointment.GetTrails(_LocalDrivingLicenseApplicationID, _TestType);
                lblTrail.Text = trails.ToString();

                if(_TestAppointmentInfo.RetakeTestApplicationID == -1)
                {

                    gbRetakeTest.Enabled = false;
                    lblRetakeTestID.Text = "N/A";
                    lblRetakTestFees.Text = "0";
                    lblTotalFees.Text = lblFees.Text;
                }
                else
                {
                    gbRetakeTest.Enabled = true;
                    lblRetakeTestID.Text = _TestAppointmentInfo.RetakeTestApplicationInfo.ApplicationID.ToString();
                    decimal retakeTestFees = clsApplicationType.GetFees(enApplicationType.RetakeTest);
                    lblRetakTestFees.Text = retakeTestFees.ToString();
                    lblTotalFees.Text = (testTypeFees + retakeTestFees).ToString();
                }

                if (_TestAppointmentInfo.IsLocked)
                {
                    dtpAppointmentDate.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
        }
        
        private void frmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            if (_LocalDrivingLicenseApplicationID == -1)
            {
                MessageBox.Show("You Must Choose Local App");
                this.Close();
                return;
            }
            _ConfigureMode();
            _ConfigureImage();
            _ConfigureFormData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadTestAppointmentInfo()
        {
            _TestAppointmentInfo.TestType = _TestType;
            _TestAppointmentInfo.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            _TestAppointmentInfo.AppointmentDate = dtpAppointmentDate.Value;
            _TestAppointmentInfo.PaidFees = Convert.ToDecimal(lblFees.Text);
            _TestAppointmentInfo.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
        }
        private void _LoadRetakeTestAppointmentInfo()
        {
            _RetakeTestApplicationInfo.ApplicantPersonID = _LDLAppInfo.ApplicantPersonID;
            _RetakeTestApplicationInfo.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
            _RetakeTestApplicationInfo.PaidFees = Convert.ToDecimal(lblRetakTestFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadTestAppointmentInfo();

            string errorMessage;
            if(_RetakeTestApplicationInfo != null)
            {
                _LoadRetakeTestAppointmentInfo();
                _RetakeTestApplicationInfo.Save(out errorMessage);
                _TestAppointmentInfo.RetakeTestApplicationID = _RetakeTestApplicationInfo.ApplicationID;
            }
            if (_TestAppointmentInfo.Save(out errorMessage))
            {
                MessageBox.Show("Appointment Saved Successfully");
                this.Close();
                return;
            } else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
