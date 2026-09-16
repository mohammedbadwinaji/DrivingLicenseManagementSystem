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
using DrivingLicense.BusinessLogic.Models;

namespace DrivingLicense.Presentation.tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicnenseApplicationID;
        private enTestType _TestType;
        public frmScheduleTest
            (
            int localDrivingLicnenseApplicationID,
            enTestType testType
            )
        {
            InitializeComponent();
            _LocalDrivingLicnenseApplicationID = localDrivingLicnenseApplicationID;
            _TestType = testType;
        }

        private void _LoadApplicationAppointments()
        {
            DataTable appointments = clsTestAppointment.GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(_LocalDrivingLicnenseApplicationID,(int)_TestType);

            appointments.Columns["TestAppointmentID"].ColumnName = "Appointment ID";
            appointments.Columns["AppointmentDate"].ColumnName = "Appointment Date";
            appointments.Columns["PaidFees"].ColumnName = "Paid Fees";
            appointments.Columns["IsLocked"].ColumnName = "Is Locked";

            dgvAppointments.DataSource = appointments;
            lblRecords.Text = dgvAppointments.Rows.Count.ToString();
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
        private void _ConfigureTitle()
        {
            switch (_TestType)
            {
                case enTestType.Vision:
                    lblTitle.Text = "Vision";
                    break;
                case enTestType.Written:
                    lblTitle.Text = "Written";
                    break;
                case enTestType.Street:
                    lblTitle.Text = "Street";
                    break;
            }
            lblTitle.Text += " Test Appointment";

        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            if(_LocalDrivingLicnenseApplicationID== -1)
            {
                MessageBox.Show("There Is Not Local Application To Schedule Test");
                this.Close();
                return;
            }
            _ConfigureImage();
            _ConfigureTitle();
            usrLocalDrivingLicenseApplicationDetails1.LoadLocalDrivingLicenseInfo(_LocalDrivingLicnenseApplicationID);
            _LoadApplicationAppointments();

        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
           if(clsTestAppointment.IsLocalApplicationAlreadyHasActiveAppointment(_LocalDrivingLicnenseApplicationID,(int)_TestType))
            {
                MessageBox.Show("person already has an active appointment for this test , you cannot add new appointment","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (clsTestAppointment.IsAlreadyPassedTest(_LocalDrivingLicnenseApplicationID, (int)_TestType))
            {
                MessageBox.Show("person already passed Test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmAddEditTestAppointment frm = new frmAddEditTestAppointment(-1,_TestType);
            frm.ShowDialog();

        }
    }
}
