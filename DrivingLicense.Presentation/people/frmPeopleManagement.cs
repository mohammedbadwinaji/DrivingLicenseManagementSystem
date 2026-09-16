using System;
using System.Data;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;

namespace DrivingLicense.Presentation.people
{
    public partial class frmPeopleManagement : Form
    {
        private enum enGendorValule
        {
            All,
            Male,
            Female
        }
        private enum enFilterOption
        {
            None,
            Person_ID,
            First_Name,
            Second_Name,
            Third_Name,
            Last_Name,
            NationalNo,
            Nationality,
            Gendor,
            Phone,
            Email
        }

        private enFilterOption _CurrentSelectedFilterOption;

        private DataTable _dtAllPeople;
        private string _GetFilterOptionString(enFilterOption filterOption)
        {
            return filterOption.ToString().Replace("_", " ");
        }
        public frmPeopleManagement()
        {
            InitializeComponent();
            
        }

        private void _RefreshPeopleDataGridView()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            dgvPeople.DataSource = _dtAllPeople;
 
            dgvPeople.Columns["PersonId"].HeaderText = "Person ID";
            dgvPeople.Columns["NationalNo"].HeaderText = "National No";
            dgvPeople.Columns["FirstName"].HeaderText = "First Name";
            dgvPeople.Columns["SecondName"].HeaderText = "Second Name";
            dgvPeople.Columns["ThirdName"].HeaderText = "Third Name";
            dgvPeople.Columns["LastName"].HeaderText = "Last Name";
            dgvPeople.Columns["Gendor"].HeaderText = "Gendor";
            dgvPeople.Columns["DateOfBirth"].HeaderText = "Date of Birth";
            dgvPeople.Columns["Nationality"].HeaderText = "Nationality";
            dgvPeople.Columns["Phone"].HeaderText = "Phone";
            dgvPeople.Columns["Email"].HeaderText = "Email";

            lblRecords.Text = dgvPeople.Rows.Count.ToString();
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
        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            _RefreshPeopleDataGridView();
            _ConfigureFilterOptinosComboBox();
        }

        private void dgvPeople_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPeople.Columns[e.ColumnIndex].Name == "Gendor" && e.Value != null)
            {
                if(Convert.ToByte(e.Value) == 0)
                {
                    e.Value = "Male";
                }else
                {
                    e.Value = "Female";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAddEditPerson_Click(object sender, EventArgs e)
        {
            _OpenAddEditPersonForm(-1);
        }
        private void _OpenAddEditPersonForm(int personId)
        {
            frmAddEditPerson frm = new frmAddEditPerson(personId);
            frm.OnSave += _HandlePersonSave;
            frm.ShowDialog();
        }
       

        private void cmiAddNewPerson_Click(object sender, EventArgs e)
        {
            _OpenAddEditPersonForm(-1);
        }

        private void cmiEditPerson_Click(object sender, EventArgs e)
        {
            _OpenAddEditPersonForm(_GetSelectedPersonId());
        }
        private int _GetSelectedPersonId()
        {
            if(dgvPeople.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvPeople.SelectedRows[0];
                if (selectedRow.Cells["PersonID"].Value != null)
                {
                    return Convert.ToInt32(selectedRow.Cells["PersonID"].Value);
                }
            }
            return -1;
        }

        private void cmiShowPesonDetails_Click(object sender, EventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_GetSelectedPersonId());
            frm.OnSave += _HandlePersonSave;
            frm.ShowDialog();
        }
        private void _HandlePersonSave(int personId)
        {
            _RefreshPeopleDataGridView();
        }

        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterOptions.SelectedValue == null)
                return;

            _ClearAllFilterInputs();
            _DisableAllFilterInputs();

            _CurrentSelectedFilterOption = (enFilterOption)cmbFilterOptions.SelectedValue;

            switch (_CurrentSelectedFilterOption) {
                case enFilterOption.None:
                    _ApplyFilter();
                    lblRecords.Text = dgvPeople.Rows.Count.ToString();
                    break;
                case enFilterOption.Person_ID:
                case enFilterOption.First_Name:
                case enFilterOption.Second_Name:
                case enFilterOption.Third_Name:
                case enFilterOption.Last_Name:
                case enFilterOption.NationalNo:
                case enFilterOption.Nationality:
                case enFilterOption.Phone:
                case enFilterOption.Email:
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
                case enFilterOption.Gendor:
                    _ConfigureGendorFilerInputComboBox();
                    cmbFilterValue.Visible = true;
                    break;
            }
        }
        private void _ConfigureGendorFilerInputComboBox()
        {
            cmbFilterValue.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(enGendorValule));   
            dt.Columns.Add("Name", typeof(string));

            foreach (enGendorValule gendorValue in Enum.GetValues(typeof(enGendorValule)))
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
            
            DataView dv = _dtAllPeople.DefaultView;
            if(
                    _CurrentSelectedFilterOption == enFilterOption.None
                )
            {
                dv.RowFilter = "";
                return;
            }

            if(
                _CurrentSelectedFilterOption == enFilterOption.Gendor
                )
            {
                if (cmbFilterValue.SelectedValue == null) return;

                enGendorValule selectedGender = (enGendorValule)cmbFilterValue.SelectedValue;
                
                if(selectedGender == enGendorValule.All)
                {
                    dv.RowFilter = "";
                } else
                {
                    byte genderByte = (byte)(selectedGender == enGendorValule.Male ? 0 : 1);
                    dv.RowFilter = $"Gendor = {genderByte}";
                }
                return;
            }

            string filterValue = txtFilterValue.Text.Trim(); 
            string columnName = _GetFilterOptionString(_CurrentSelectedFilterOption).Replace(" ","");

            
            if(string.IsNullOrEmpty(filterValue))
            {
                dv.RowFilter = "";
            }
            else if (_CurrentSelectedFilterOption == enFilterOption.Person_ID)
            {
                dv.RowFilter = $"[{columnName}] = {filterValue}";
            }
            else
            {
                dv.RowFilter = $"[{columnName}] LIKE '{filterValue}%'";
            }
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvPeople.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentSelectedFilterOption == enFilterOption.Person_ID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
