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
        public event Action<int> OnTestSave;

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
            DataTable appointments = clsTestAppointment.GetAllLocalAppAppointmentsPerTestType(_LocalDrivingLicnenseApplicationID, _TestType);

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

        private int _GetSelectedAppointmentID()
        {
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                if (selectedRow.Cells["Appointment ID"].Value != null)
                {
                    return Convert.ToInt32(selectedRow.Cells["Appointment ID"].Value);
                }
            }
            return -1;
        }
        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsTestAppointment testAppointment = clsTestAppointment.GetLastLocalAppAppointmentPerTestType(_LocalDrivingLicnenseApplicationID, _TestType);
            if(testAppointment != null)
            {
                if (!testAppointment.IsLocked)
                {
                    MessageBox.Show("Person Already Has Active Appointment");
                    return;
                }
                clsTest test = clsTest.FindByID(testAppointment.TestID);
                if(test.TestResult == true)
                {
                    MessageBox.Show("Person Already Passed The Test");
                    return;
                }
            }

            frmAddEditTestAppointment frm = new frmAddEditTestAppointment(-1,_LocalDrivingLicnenseApplicationID,_TestType);
            frm.ShowDialog();
            _LoadApplicationAppointments();
        }


        private void cmiEditAppointment_Click(object sender, EventArgs e)
        {
            frmAddEditTestAppointment frm = new frmAddEditTestAppointment(_GetSelectedAppointmentID(),_LocalDrivingLicnenseApplicationID,_TestType);
            frm.ShowDialog();
            _LoadApplicationAppointments();

        }

        private void cmiTakeTest_Click(object sender, EventArgs e)
        {
            clsTestAppointment testAppointment = clsTestAppointment.FindByID(_GetSelectedAppointmentID());
            if(testAppointment.IsLocked)
            {
                MessageBox.Show("this Test Appointment Is Locked");
                return;
            }

            frmTakeTest frm = new frmTakeTest(_GetSelectedAppointmentID());
            frm.OnTestSave += OnTestSave;
            frm.ShowDialog();
            
            _LoadApplicationAppointments();
            usrLocalDrivingLicenseApplicationDetails1.LoadLocalDrivingLicenseInfo(_LocalDrivingLicnenseApplicationID);
        }
    }
}
