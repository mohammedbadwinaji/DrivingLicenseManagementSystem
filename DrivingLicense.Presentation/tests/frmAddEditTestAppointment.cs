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
        private int _LocalDrivingLicenseApplicationID;
        private int _TestAppointmentID;
        private enTestType _TestType;
        private enMode _Mode;
        private clsTestAppointment _TestAppointment;
        public frmAddEditTestAppointment
            (
            int localDrivingLicenseApplicationId, int testAppointmentID,enTestType testType
            )
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationId;
            _TestAppointmentID = testAppointmentID;
            _TestType = testType;
            _TestAppointment = new clsTestAppointment(_LocalDrivingLicenseApplicationID,(int)_TestType);
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
                _TestAppointment = new clsTestAppointment(_LocalDrivingLicenseApplicationID,(int)_TestType);
                lblLDLAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = _TestAppointment.LicenseClassTitle;
                lblName.Text = _TestAppointment.FullName;
                lblFees.Text = "0";
                lblTrail.Text = "0";
                lblRetakeTestID.Text = "N/A";
                lblRetakTestFees.Text = "0";
                lblTotalFees.Text = "0";
            }   else
            {
                _TestAppointment = clsTestAppointment.FindByID(_TestAppointmentID);
                lblLDLAppID.Text = _TestAppointment.LocalDrivingLicenseApplicationID.ToString();
                lblLicenseClass.Text = _TestAppointment.LicenseClassTitle;
                lblName .Text = _TestAppointment.FullName;
                lblFees.Text = _TestAppointment.PaidFees.ToString();
                lblTrail.Text = _TestAppointment.Trail.ToString();

            }
        }
        private void frmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            _ConfigureMode();
            _ConfigureImage();
            _ConfigureFormData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
