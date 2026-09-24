using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;
using DrivingLicense.Presentation.applications;
using DrivingLicense.Presentation.people;

namespace DrivingLicense.Presentation.licenses
{
    public partial class frmDetainedLicensesManagement : Form
    {
        private enum enFilterOption
        {
            None,
            Detain_ID,
            Is_Released,
            Full_Name,
            Release_Application_ID
        }

        private enFilterOption _CurrentFilterOption;


        private enum enIsReleaseValue
        {
            All,
            Released,
            Not_Released
        }
        private string _GetFilterOptionString(enFilterOption filterOption)
        {
            return filterOption.ToString().Replace("_", " ");
        }


        private DataTable  _dtAllDetainedLicenses;

        
        public frmDetainedLicensesManagement()
        {
            InitializeComponent();
        }

        private void _LoadDetainedLicenses()
        {
            _dtAllDetainedLicenses = clsDetainedLicense.GetAllDetainedLicense();

            dgvDetainedLicenses.DataSource = _dtAllDetainedLicenses;

            dgvDetainedLicenses.Columns["DetainID"].HeaderText = "D.ID";
            dgvDetainedLicenses.Columns["LicenseID"].HeaderText = "L.ID";
            dgvDetainedLicenses.Columns["DetainDate"].HeaderText = "D.Date";
            dgvDetainedLicenses.Columns["IsReleased"].HeaderText = "Is Released";
            dgvDetainedLicenses.Columns["FineFees"].HeaderText = "Fine Fees";
            dgvDetainedLicenses.Columns["ReleaseDate"].HeaderText = "Release Date";
            dgvDetainedLicenses.Columns["NationalNo"].HeaderText = "N.No";
            dgvDetainedLicenses.Columns["FullName"].HeaderText = "Full Name";
            dgvDetainedLicenses.Columns["ReleaseApplicationID"].HeaderText = "Release.App.ID";

            lblRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
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
        private void frmDetainedLicensesManagement_Load(object sender, EventArgs e)
        {
            _ConfigureFilterOptionComboBox();
            _LoadDetainedLicenses();
            
        }

        private int _GetSelectedDetainedLicenseID()
        {
            int detainLicenseId = -1;
            if (dgvDetainedLicenses.SelectedRows.Count > 0)
            {
                detainLicenseId = Convert.ToInt32(dgvDetainedLicenses.SelectedRows[0].Cells["DetainID"].Value);
            }
            return detainLicenseId;
        }
        private string _GetSelectedPersonNationalNo()
        {
            string nationalNo = null;
            if (dgvDetainedLicenses.SelectedRows.Count > 0)
            {
                nationalNo = Convert.ToString(dgvDetainedLicenses.SelectedRows[0].Cells["NationalNo"].Value);
            }
            return nationalNo;
        }
        private int _GetSelectedLicenseID()
        {
            int licenseId = -1;
            if (dgvDetainedLicenses.SelectedRows.Count > 0)
            {
                licenseId = Convert.ToInt32(dgvDetainedLicenses.SelectedRows[0].Cells["LicenseID"].Value);
            }
            return licenseId;
        }
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLecense frm = new frmDetainLecense();
            frm.ShowDialog();
            _LoadDetainedLicenses();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            _LoadDetainedLicenses();
        }

        private void cmiDetainedLiceneses_Opening(object sender, CancelEventArgs e)
        {
            clsDetainedLicense detainedLicense = clsDetainedLicense.FindByID(_GetSelectedDetainedLicenseID());
            
            if (detainedLicense.IsReleased)
            {
                cmiReleaseDetainedLicense.Enabled = false;
            } else
            {
                cmiReleaseDetainedLicense.Enabled = true;
            }
        }

        private void cmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.FindByNationalNo(_GetSelectedPersonNationalNo());

            if (person != null) {
                frmPersonDetails frm = new frmPersonDetails(person.PersonId);
                frm.ShowDialog();
            }
        }

        private void cmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            int licenseId = _GetSelectedLicenseID();
            frmShowLicenseDetails frm = new frmShowLicenseDetails(licenseId);
            frm.ShowDialog();
        }

        private void cmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.FindByNationalNo(_GetSelectedPersonNationalNo());

            if (person != null)
            {
                frmPersonLicenseHistory frm = new frmPersonLicenseHistory(person.PersonId);
                frm.ShowDialog();   
            }
        }

        private void cmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {

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

        private void _ConfigureIsReleasedComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IsReleaseView", typeof(string));
            dt.Columns.Add("IsReleaseValue", typeof(enIsReleaseValue));

            foreach (enIsReleaseValue activeValue in Enum.GetValues(typeof(enIsReleaseValue)))
            {
                dt.Rows.Add(activeValue.ToString().Replace("_", " "), activeValue);
            }

            cmbFilterValue.DisplayMember = "IsReleaseView";
            cmbFilterValue.ValueMember = "IsReleaseValue";

            cmbFilterValue.DataSource = dt;
        }
        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ClearAllFilterInputs();
            _HideAllFilterInputs();
            _CurrentFilterOption = (enFilterOption)cmbFilterOptions.SelectedValue;

            switch (_CurrentFilterOption)
            {
                case enFilterOption.None:
                    break;
                case enFilterOption.Is_Released:
                    _ConfigureIsReleasedComboBox();
                    cmbFilterValue.Visible = true;
                    break;
                default:
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
            }
        }
        private void _ApplyFilter()
        {

            DataView dv = _dtAllDetainedLicenses.DefaultView;
            
            if (
                    _CurrentFilterOption == enFilterOption.None
                )
            {
                dv.RowFilter = "";
                return;
            }

            if (_CurrentFilterOption == enFilterOption.Is_Released)
            {
                if (cmbFilterValue.SelectedValue == null) return;
                enIsReleaseValue selectedIsReleaseValue = (enIsReleaseValue)cmbFilterValue.SelectedValue;
                switch (selectedIsReleaseValue)
                {
                    case enIsReleaseValue.All:
                        dv.RowFilter = "";
                        break;
                    case enIsReleaseValue.Released:
                    case enIsReleaseValue.Not_Released:
                        bool releaseBoolean = (bool)(selectedIsReleaseValue == enIsReleaseValue.Released ? true : false);
                        dv.RowFilter = $"IsReleased = {releaseBoolean}";
                        break;
                }
                return;
            }
            string filterValue = txtFilterValue.Text.Trim();
            string columnName = _GetFilterOptionString(_CurrentFilterOption).Replace(" ", "");

            if (_CurrentFilterOption == enFilterOption.Detain_ID
                ||
                _CurrentFilterOption == enFilterOption.Release_Application_ID)
            {
                if (string.IsNullOrEmpty(filterValue)) {
                    dv.RowFilter = "";
                }else
                {
                    dv.RowFilter = $"[{columnName}] = {filterValue}";
                }
                return;
            }

            dv.RowFilter = $"[{columnName}] LIKE '{filterValue}%'";


           
            
            
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilterOption == enFilterOption.Detain_ID ||
                _CurrentFilterOption == enFilterOption.Release_Application_ID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

       
    }
}
