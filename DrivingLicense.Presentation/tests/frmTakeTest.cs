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

namespace DrivingLicense.Presentation.tests
{
    public partial class frmTakeTest : Form
    {
        public event Action<int> OnTestSave;

        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointmentInfo;

        private clsTest _Test;
        public frmTakeTest(int testAppointmentId)
        {
            InitializeComponent();
            _TestAppointmentID = testAppointmentId;
            _TestAppointmentInfo = null;
            _Test = null;   
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            if(_TestAppointmentID == -1)
            {
                MessageBox.Show("You Must Hasve Appointment To Take Test");
                this.Close();
                return;
            }
            _TestAppointmentInfo = clsTestAppointment.FindByID(_TestAppointmentID);
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.FindByID(_TestAppointmentInfo.LocalDrivingLicenseApplicationID);
            lblLDLAppID.Text = ldlApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = ldlApp.LicenseClass.ToString();
            lblName.Text = ldlApp.GetApplicantFullName;
            lblTrail.Text = clsTestAppointment.GetTrails(ldlApp.LocalDrivingLicenseApplicationID, _TestAppointmentInfo.TestType).ToString();
            lblTestDate.Text = _TestAppointmentInfo.AppointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointmentInfo.PaidFees.ToString();
            lblTestID.Text = _TestAppointmentInfo.TestID == -1 ? "Not Taked Yet" : _TestAppointmentInfo.TestID.ToString();
            rbPass.Checked = true;

        }

        private void _LoadTestInfo()
        {
            _Test = new clsTest();
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text;
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.CreatedByUserID = clsSettings.CurrentLoggedInUser.UserId;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadTestInfo();
            
            string errorMessage;
            if (_Test.Save(out errorMessage))
            {
                MessageBox.Show("Result Saved Successfully");
                OnTestSave?.Invoke(_Test.TestID);
                this.Close();
                return;
            } else
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
