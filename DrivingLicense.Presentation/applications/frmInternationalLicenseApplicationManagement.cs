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
using DrivingLicense.Presentation.licenses;
using DrivingLicense.Presentation.people;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmInternationalLicenseApplicationManagement : Form
    {
        private enum enActiveValue
        {
            All,
            Active,
            Not_Active,
        }
        private enum enFilterOption
        {
            None,
            International_Licnese_ID,
            Application_ID,
            Driver_ID,
            Local_License_ID,
            IsActive
        }

        private enFilterOption _CurrentFilterOption;


        private DataTable _dtInternationalLicenseApplications;
        public frmInternationalLicenseApplicationManagement()
        {
            InitializeComponent();
        }

        
        private void _LoadInternationalLicenseApplications()
        {
            _dtInternationalLicenseApplications = clsInternationalLicenseApplication.GetAllApplications();

            dgvInternationalLicenseApplications.DataSource = _dtInternationalLicenseApplications;

            dgvInternationalLicenseApplications.Columns["InternationalLicenseID"].HeaderText = "int License ID";
            dgvInternationalLicenseApplications.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvInternationalLicenseApplications.Columns["DriverID"].HeaderText = "Driver ID";
            dgvInternationalLicenseApplications.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L License ID";
            dgvInternationalLicenseApplications.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvInternationalLicenseApplications.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvInternationalLicenseApplications.Columns["IsActive"].HeaderText = "Is Active";

            lblRecords.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
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
        private void _ConfigureActiveFilerInputComboBox()
        {
            cmbFilterValue.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(enActiveValue));
            dt.Columns.Add("Name", typeof(string));

            foreach (enActiveValue gendorValue in Enum.GetValues(typeof(enActiveValue)))
            {
                dt.Rows.Add(gendorValue, gendorValue.ToString().Replace("_", ""));
            }
            cmbFilterValue.ValueMember = "Id";
            cmbFilterValue.DisplayMember = "Name";
            cmbFilterValue.DataSource = dt;

            cmbFilterValue.SelectedIndex = 0;
        }
        private void frmInternationalLicenseApplicationManagement_Load(object sender, EventArgs e)
        {
            _LoadInternationalLicenseApplications();
            _ConfigureFilterOptinosComboBox();
            _CurrentFilterOption = (enFilterOption) cmbFilterOptions.SelectedValue;
        }
        private void btnAddNewLocalDrivingLicenseApplication_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicenseApplication frm = new frmIssueInternationalLicenseApplication();
            frm.OnLicenseIssued += _HandleNewInternationalLicenseIssued;
            frm.ShowDialog();
        }
        private void _HandleNewInternationalLicenseIssued(int internationalLicenseId)
        {
            _LoadInternationalLicenseApplications();
        }
        private int _GetSelectedInternationalLicenseApplicationID()
        {
            if (dgvInternationalLicenseApplications.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvInternationalLicenseApplications.SelectedRows[0];
                if (selectedRow.Cells["ApplicationID"].Value != null)
                {
                    return Convert.ToInt32(selectedRow.Cells["ApplicationID"].Value);
                }
            }
            return -1;
        }
        private int _GetSelectedInternationalLicenseID()
        {
            if (dgvInternationalLicenseApplications.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvInternationalLicenseApplications.SelectedRows[0];
                if (selectedRow.Cells["InternationalLicenseID"].Value != null)
                {
                    return Convert.ToInt32(selectedRow.Cells["InternationalLicenseID"].Value);
                }
            }
            return -1;
        }
        private void cmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            int internationalLicenseApplicationId = _GetSelectedInternationalLicenseApplicationID();

            clsInternationalLicenseApplication internationalLicenseApplicationInfo = clsInternationalLicenseApplication.FindByID(internationalLicenseApplicationId);

            if(internationalLicenseApplicationInfo == null)
            {
                MessageBox.Show($"No International License Application With ID {internationalLicenseApplicationId} To View Applicant Details");
                return;
            }

            frmPersonDetails frm = new frmPersonDetails(internationalLicenseApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void cmiShowLicenseDetails_Click(object sender, EventArgs e)
        {

            int internationalLicenseId = _GetSelectedInternationalLicenseID();
            frmShowInternationalLicenseDetails frm = new frmShowInternationalLicenseDetails(internationalLicenseId);
            frm.ShowDialog();
        }

        private void cmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int internationalLicenseApplicationId = _GetSelectedInternationalLicenseApplicationID();

            clsInternationalLicenseApplication internationalLicenseApplicationInfo = clsInternationalLicenseApplication.FindByID(internationalLicenseApplicationId);

            if (internationalLicenseApplicationInfo == null)
            {
                MessageBox.Show($"No International License Application With ID {internationalLicenseApplicationId} To View Applicant Details");
                return;
            }

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(internationalLicenseApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void _ApplyFilter()
        {

            DataView dv = _dtInternationalLicenseApplications.DefaultView;
            if (
                    _CurrentFilterOption == enFilterOption.None
                )
            {
                dv.RowFilter = "";
                return;
            }

            

            if (
                _CurrentFilterOption == enFilterOption.IsActive
                )
            {
                if (cmbFilterValue.SelectedValue == null) return;
                if ((enActiveValue)cmbFilterValue.SelectedValue == enActiveValue.All)
                {
                    dv.RowFilter = $"";
                    return;
                }
                bool selectedActiveStatus = (enActiveValue)cmbFilterValue.SelectedValue == enActiveValue.Active ? true : false;

                dv.RowFilter = $"IsActive = {selectedActiveStatus}";
                return;
            }


            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                dv.RowFilter = "";
                return;
            }
            if (_CurrentFilterOption == enFilterOption.International_Licnese_ID
                )
            {
                dv.RowFilter = $"InternationalLicenseID = {txtFilterValue.Text}";
                return;
            }
            

            if (_CurrentFilterOption == enFilterOption.Application_ID)
            {
                dv.RowFilter = $"ApplicationID = {txtFilterValue.Text}";
                return;
            }
            if (_CurrentFilterOption == enFilterOption.Driver_ID)
            {
                dv.RowFilter = $"DriverID = {txtFilterValue.Text}";
                return;
            }

            if (_CurrentFilterOption == enFilterOption.Local_License_ID)
            {
                dv.RowFilter = $"IssuedUsingLocalLicenseID = {txtFilterValue.Text}";
                return;
            }

           
        }
        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
        }

        private void _ClearAllFilterInputs()
        {
            txtFilterValue.Clear();
            cmbFilterValue.DataSource = null;
        }
        private void _HideAllFilterInputs()
        {
            txtFilterValue.Hide();
            cmbFilterValue.Hide();
        }
        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterOptions.SelectedValue == null)
                return;

            _ClearAllFilterInputs();
            _HideAllFilterInputs();

            _CurrentFilterOption = (enFilterOption)cmbFilterOptions.SelectedValue;

            switch (_CurrentFilterOption)
            {
                case enFilterOption.None:
                    _ApplyFilter();
                    lblRecords.Text = dgvInternationalLicenseApplications.Rows.Count.ToString();
                    break;
                case enFilterOption.IsActive:
                    _ConfigureActiveFilerInputComboBox();
                    cmbFilterValue.Visible = true;
                    break;
                default:
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
            }
        }


        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilterOption == enFilterOption.International_Licnese_ID
                ||
                _CurrentFilterOption == enFilterOption.Local_License_ID
                ||
                _CurrentFilterOption == enFilterOption.Application_ID
                || _CurrentFilterOption == enFilterOption.Driver_ID
                )
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
    }
}
