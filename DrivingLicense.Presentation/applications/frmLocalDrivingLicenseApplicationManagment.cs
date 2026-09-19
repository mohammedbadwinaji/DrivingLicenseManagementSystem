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
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.Presentation.tests;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmLocalDrivingLicenseApplicationManagment : Form
    {
        private enum enStatusValue
        {
            All,
            New,
            Canceled,
            Completed
        }
        private enum enFilterOption
        {
            None,
            L_D_L_App_ID,
            Driving_Class,
            National_No,
            Full_Name,
            Passed_Tests,
            Status,
        }
        private DataTable _dtAllLocalDrivingLicenseApplications = new DataTable();
        private enFilterOption _CurrentFilterOption;

        public frmLocalDrivingLicenseApplicationManagment()
        {
            InitializeComponent();
        }
        private void _LoadLocalDrivingLicenseApplications()
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalApplications();
            dgvLocalDrivingLicenseApplications.DataSource = _dtAllLocalDrivingLicenseApplications;

            dgvLocalDrivingLicenseApplications.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "L.D.L.AppID";
            dgvLocalDrivingLicenseApplications.Columns["ClassName"].HeaderText = "Driving Class";
            dgvLocalDrivingLicenseApplications.Columns["NationalNo"].HeaderText = "National No";
            dgvLocalDrivingLicenseApplications.Columns["FullName"].HeaderText = "Full Name";
            dgvLocalDrivingLicenseApplications.Columns["PassedTests"].HeaderText = "Passed Tests";
            dgvLocalDrivingLicenseApplications.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvLocalDrivingLicenseApplications.Columns["StatusName"].HeaderText = "Status";

            lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private string _GetFilterOptionString(enFilterOption filterOption)
        {
            return filterOption.ToString().Replace("_", " ");
        }
        private void _ConfigureFilterOptinosComboBox()
        {
            cmbFilterOptions.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("FilterOptionView", typeof(string));
            dt.Columns.Add("FilterOptionValue", typeof(enFilterOption));

            foreach (enFilterOption filterOptoin in Enum.GetValues(typeof(enFilterOption)))
            {
                dt.Rows.Add(_GetFilterOptionString(filterOptoin), filterOptoin);
            }

            cmbFilterOptions.DisplayMember = "FilterOptionView";
            cmbFilterOptions.ValueMember = "FilterOptionValue";
            cmbFilterOptions.DataSource = dt;
        }
        private void frmLocalDrivingLicenseApplicationManagment_Load(object sender, EventArgs e)
        {
            _LoadLocalDrivingLicenseApplications();
            _ConfigureFilterOptinosComboBox();
            _CurrentFilterOption = enFilterOption.None;
        }
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication(-1);
            frm.OnSave += _HandleLocalDrivingLicenseApplicationSave;
            frm.ShowDialog();
        }

        private void _HandleLocalDrivingLicenseApplicationSave(int localDrivingLicenseApplicationId)
        {
            _LoadLocalDrivingLicenseApplications();
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
        }

        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterOptions.SelectedValue == null)
                return;

            _ClearAllFilterInputs();
            _DisableAllFilterInputs();

            _CurrentFilterOption = (enFilterOption)cmbFilterOptions.SelectedValue;

            switch (_CurrentFilterOption)
            {
                case enFilterOption.None:
                    _ApplyFilter();
                    lblRecords.Text = dgvLocalDrivingLicenseApplications.Rows.Count.ToString();
                    break;
                case enFilterOption.L_D_L_App_ID:
                case enFilterOption.National_No:
                case enFilterOption.Full_Name:
                case enFilterOption.Driving_Class:
                case enFilterOption.Passed_Tests:
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
                case enFilterOption.Status:
                    _ConfigureStatusFilerInputComboBox();
                    cmbFilterValue.Visible = true;
                    break;
            }
        }
        private void _ConfigureStatusFilerInputComboBox()
        {
            cmbFilterValue.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(enStatusValue));
            dt.Columns.Add("Name", typeof(string));

            foreach (enStatusValue gendorValue in Enum.GetValues(typeof(enStatusValue)))
            {
                dt.Rows.Add(gendorValue, gendorValue.ToString());
            }
            cmbFilterValue.ValueMember = "Id";
            cmbFilterValue.DisplayMember = "Name";
            cmbFilterValue.DataSource = dt;

            cmbFilterValue.SelectedIndex = 0;
        }
        private void _ClearAllFilterInputs()
        {
            txtFilterValue.Clear();
            cmbFilterValue.DataSource = null;
        }
        private void _DisableAllFilterInputs()
        {
            txtFilterValue.Visible = false;
            cmbFilterValue.Visible = false;
        }
        private void _ApplyFilter()
        {

            DataView dv = _dtAllLocalDrivingLicenseApplications.DefaultView;
            if (
                    _CurrentFilterOption == enFilterOption.None
                )
            {
                dv.RowFilter = "";
                return;
            }

            if (
                _CurrentFilterOption == enFilterOption.Status
                )
            {
                if (cmbFilterValue.SelectedValue == null) return;
                if((enStatusValue)cmbFilterValue.SelectedValue == enStatusValue.All)
                {
                    dv.RowFilter = $"";
                    return;
                }
                string selectedGender = ((enStatusValue)cmbFilterValue.SelectedValue).ToString();
                
                dv.RowFilter = $"StatusName LIKE '{selectedGender}%'";
                return;
            }


            if (string.IsNullOrEmpty(txtFilterValue.Text)) {
                dv.RowFilter = "";
                return;
            }
            if(_CurrentFilterOption == enFilterOption.L_D_L_App_ID
                )
            {
                dv.RowFilter = $"LocalDrivingLicenseApplicationID = {txtFilterValue.Text}";
                return;
            }
            if(_CurrentFilterOption == enFilterOption.Passed_Tests)
            {
                dv.RowFilter = $"PassedTests = {txtFilterValue.Text}";
                return;
            }

            if (_CurrentFilterOption == enFilterOption.Driving_Class
                )
            {
                dv.RowFilter = $"ClassName LIKE '{txtFilterValue.Text}%'";
                return;
            }

            string filterValue = txtFilterValue.Text.Trim();
            string columnName = _GetFilterOptionString(_CurrentFilterOption).Replace(" ", "");


            if (string.IsNullOrEmpty(filterValue))
            {
                dv.RowFilter = "";
            }
            else
            {
                dv.RowFilter = $"[{columnName}] LIKE '{filterValue}%'";
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilterOption == enFilterOption.L_D_L_App_ID
                || 
                _CurrentFilterOption == enFilterOption.Passed_Tests)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int _GetSelectedLocalDrivingLicenseApplicationID()
        {
            if (dgvLocalDrivingLicenseApplications.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLocalDrivingLicenseApplications.SelectedRows[0];
                if (selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value != null)
                {
                    return Convert.ToInt32(selectedRow.Cells["LocalDrivingLicenseApplicationID"].Value);
                }
            }
            return -1;
        }
        private int _GetApplicationID()
        {
            return clsLocalDrivingLicenseApplication.FindByID(_GetSelectedLocalDrivingLicenseApplicationID()).ApplicationID;
        }
        private void cmiEditLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.FindByID(_GetSelectedLocalDrivingLicenseApplicationID());

            if (ldlApp.ApplicationStatus == BusinessLogic.Models.enApplicationStatus.Canceled
                ||
                ldlApp.ApplicationStatus == BusinessLogic.Models.enApplicationStatus.Completed)
            {
                MessageBox.Show("You Cannot Edit (Canceled | Completed) Application");
                return;
            }

            frmAddEditLocalDrivingLicenseApplication frm = new frmAddEditLocalDrivingLicenseApplication(_GetSelectedLocalDrivingLicenseApplicationID());
            frm.OnSave += _HandleLocalDrivingLicenseApplicationSave;
            frm.ShowDialog();
        }

        private void cmiShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationDetails frm = new frmLocalDrivingLicenseApplicationDetails(_GetSelectedLocalDrivingLicenseApplicationID());
            frm.OnPersonalInformationSaved += _HandlePeraonalInformationSaved;
            frm.ShowDialog();
        }
        private void _HandlePeraonalInformationSaved(int personId)
        {
            _LoadLocalDrivingLicenseApplications();
        }
        
        private void cmiCancelApplication_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            
            bool isApplicationCanceled = clsApplication.ChangeStatus(_GetApplicationID(), enApplicationStatus.Canceled);

            if (isApplicationCanceled)
            {
                MessageBox.Show("Application Canceled Successfully");
                _LoadLocalDrivingLicenseApplications();
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void cmiShowApplicationLicense_Click(object sender, EventArgs e)
        {
            //frmLocalDrivingLicenseApplicationDetails frm = new frmLocalDrivingLicenseApplicationDetails(_GetSelectedLocalDrivingLicenseApplicationID());
            //frm.OnPersonalInformationSaved += _HandlePeraonalInformationSaved;
            //frm.ShowDialog();
        }

        

        private void _DisableAllContextMenuItems()
        {
            foreach (ToolStripMenuItem item in cmLocalDrivingLicenseApplications.Items)
            {
                   item.Enabled = false;
            }
        }
        private void cmLocalDrivingLicenseApplications_Opening(object sender, CancelEventArgs e)
        {
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.FindByID(_GetSelectedLocalDrivingLicenseApplicationID());
            if (ldlApp == null)
            {
                cmLocalDrivingLicenseApplications.Close();
                return;
            }

            _DisableAllContextMenuItems();


            if (ldlApp.ApplicationStatus == BusinessLogic.Models.enApplicationStatus.Canceled
                ||
                ldlApp.ApplicationStatus == BusinessLogic.Models.enApplicationStatus.Completed)
            {
                cmiShowApplicationDetails.Enabled = true;
                cmiShowPersonLicensesHistory.Enabled = true;
                return;
            }

            cmiShowApplicationDetails.Enabled = true;
            cmiEditLocalDrivingLicenseApplication.Enabled = true;
            cmiDeleteApplication.Enabled = true;
            cmiCancelApplication.Enabled = true;
            cmiShowPersonLicensesHistory.Enabled = true;


            cmiScheduleTests.Enabled = true;
            foreach (ToolStripMenuItem item in cmiScheduleTests.DropDownItems)
            {
                item.Enabled = false;
            }
            if (ldlApp.PassedTests == 0)
            {
                cmiScheduleVisionTest.Enabled = true;
            }
            else if (ldlApp.PassedTests == 1)
            {
                cmiScheduleWrittenTest.Enabled = true;
            }
            else if (ldlApp.PassedTests == 2)
            {
                cmiScheduleStreetTest.Enabled = true;
            }
            else
            {
                _DisableAllContextMenuItems();
                cmiShowApplicationDetails.Enabled = true;
                cmiShowPersonLicensesHistory.Enabled = true;x`
                if (ldlApp.LicenseID == -1)
                {
                    cmiIssureDrivingLicenseFirstTime.Enabled = true;
                }
                else
                {
                    cmiShowApplicationLicense.Enabled = true;
                }
            }


        }

        private void cmiScheduleVisionTest_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_GetSelectedLocalDrivingLicenseApplicationID(),enTestType.Vision);
            frm.OnTestSave += _HandleTestSave;
            frm.ShowDialog();
        }

        private void cmiScheduleWrittenTest_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_GetSelectedLocalDrivingLicenseApplicationID(), enTestType.Written);
            frm.OnTestSave += _HandleTestSave;
            frm.ShowDialog();
        }

        private void cmiScheduleStreetTest_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_GetSelectedLocalDrivingLicenseApplicationID(), enTestType.Street);
            frm.OnTestSave += _HandleTestSave;
            frm.ShowDialog();
        }
        private void _HandleTestSave(int testId)
        {
            _LoadLocalDrivingLicenseApplications();
        }
    }
}
