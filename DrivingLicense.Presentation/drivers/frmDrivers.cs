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

namespace DrivingLicense.Presentation.drivers
{
    public partial class frmDrivers : Form
    {
        private DataTable _dtDrivers;

        private enum enFilterOption
        {
            None,
            Driver_ID,
            Person_ID,
            National_No,
            Full_Name,
            Active_Licenses
        }
        private enFilterOption _CurrentFilterOption;
        public frmDrivers()
        {
            InitializeComponent();
        }
        private string _GetFilterOptionString(enFilterOption filterOption)
        {
            return filterOption.ToString().Replace("_", " ");
        }
        private void _LoadDrivers()
        {
            _dtDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtDrivers;
            dgvDrivers.Columns["DriverID"].HeaderText = "Driver ID";
            dgvDrivers.Columns["PersonID"].HeaderText = "Person ID";
            dgvDrivers.Columns["NationalNo"].HeaderText = "National No";
            dgvDrivers.Columns["FullName"].HeaderText = "Full Name";
            dgvDrivers.Columns["ActiveLicenses"].HeaderText = "Active Licenses";


            lblRecords.Text = dgvDrivers.Rows.Count.ToString();
        }
        private void _ConfigureFilterOptionComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FilterOptionView", typeof(string));
            dt.Columns.Add("FilterOptionValue", typeof(enFilterOption));

            foreach (enFilterOption filterOption in Enum.GetValues(typeof(enFilterOption)))
            {
                dt.Rows.Add(_GetFilterOptionString(filterOption), filterOption);
            }

            cmbFilterOptions.DisplayMember = "FilterOptionView";
            cmbFilterOptions.ValueMember = "FilterOptionValue";

            cmbFilterOptions.DataSource = dt;
        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            _ConfigureFilterOptionComboBox();
            _LoadDrivers();
        }

        private void _ClearAllFilterValueInputs()
        {
            txtFilterValue.Clear();
        }
        private void _HideAllFilterValueInputs()
        {
            txtFilterValue.Hide();
        }
        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ClearAllFilterValueInputs();
            _HideAllFilterValueInputs();

            _CurrentFilterOption =(enFilterOption) cmbFilterOptions.SelectedValue;

            switch (_CurrentFilterOption)
            {
                case enFilterOption.None:
                    break;
                default:
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
            }
        }

        private void _ApplyFilter()
        {
            string value = txtFilterValue.Text;
            
            DataView dataView =  _dtDrivers.DefaultView;
            if (string.IsNullOrEmpty(value))
            {
                dataView.RowFilter = "";
                return;
            }
            switch (_CurrentFilterOption)
            {
                case enFilterOption.None:
                    dataView.RowFilter = "";
                    break;
                case enFilterOption.Driver_ID:
                case enFilterOption.Person_ID:
                case enFilterOption.Active_Licenses:
                    dataView.RowFilter = $"{_CurrentFilterOption.ToString().Replace("_","")} = {value}";
                    break;
                case enFilterOption.National_No:
                case enFilterOption.Full_Name:
                    dataView.RowFilter = $"{_CurrentFilterOption.ToString().Replace("_", "")} LIKE '{value}%'";
                    break;
            }

        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilterOption == enFilterOption.Person_ID
                ||
                _CurrentFilterOption == enFilterOption.Driver_ID
                ||
                _CurrentFilterOption == enFilterOption.Active_Licenses)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
