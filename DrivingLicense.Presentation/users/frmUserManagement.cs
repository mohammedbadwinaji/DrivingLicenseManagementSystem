using System;
using System.Data;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;

namespace DrivingLicense.Presentation.users
{
    public partial class frmUserManagement : Form
    {

        private DataTable _dtAllUsers;

        enum enIsActiveValue
        {
            All,
            Active,
            Not_Active
        }
        enum enFilterOption
        {
            None,
            User_ID,
            Person_ID,
            Username,
            FullName,
            Is_Active
        }
        private enFilterOption _CurrentFilterOption;
        private string _GetFilterOptionString(enFilterOption filterOption)
        {
            return filterOption.ToString().Replace("_", " ");
        }
        public frmUserManagement()
        {
            InitializeComponent();
        }
        
        private void _LoadUsersInfo()
        {
            _dtAllUsers = clsUser.GetAllUsers();

            dgvUsers.DataSource = _dtAllUsers;
            dgvUsers.Columns["UserID"].HeaderText = "User ID";
            dgvUsers.Columns["PersonID"].HeaderText = "Person ID";
            dgvUsers.Columns["FullName"].HeaderText = "Full Name";
            dgvUsers.Columns["Username"].HeaderText = "User Name";
            dgvUsers.Columns["IsActive"].HeaderText = "Is Active";

            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }
        private void _ConfigureFilterOptionComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FilterOptionView", typeof(string));
            dt.Columns.Add("FilterOptionValue", typeof(enFilterOption));

            foreach( enFilterOption filterOption in Enum.GetValues(typeof(enFilterOption)))
            {
                dt.Rows.Add(_GetFilterOptionString(filterOption), filterOption);
            }

            cmbFilterOptions.DisplayMember = "FilterOptionView";
            cmbFilterOptions.ValueMember = "FilterOptionValue";

            cmbFilterOptions.DataSource = dt;
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            _ConfigureFilterOptionComboBox();
            _LoadUsersInfo();
        }

        private int _GetSelectedUserID()
        {
            int userId = -1;
            if (dgvUsers.SelectedRows.Count > 0)
            {
                userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            }
            return userId;
        }
        private void cmiShowUserDetails_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails(_GetSelectedUserID());
            frm.OnPersonalInformationSave += _HandlePersonalInformationSave;
            frm.ShowDialog();   
        }

        private void _HandlePersonalInformationSave(int userId)
        {
            _LoadUsersInfo();
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void frmAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.OnSave += _HandleUserSave;
            frm.ShowDialog();
        }

        private void cmiAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(-1);
            frm.OnSave += _HandleUserSave;
            frm.ShowDialog();
        }

        private void cmiEditUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser(_GetSelectedUserID());
            frm.OnSave += _HandleUserSave;
            frm.ShowDialog();
        }

        private void _HandleUserSave(int userId)
        {
            _LoadUsersInfo();
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


        private void _ConfigureIsActiveComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IsActiveView",typeof(string));
            dt.Columns.Add("IsActiveValue", typeof(enIsActiveValue));

            foreach(enIsActiveValue activeValue in Enum.GetValues(typeof(enIsActiveValue)))
            {
                dt.Rows.Add(activeValue.ToString().Replace("_", " "), activeValue);
            }

            cmbFilterValue.DisplayMember = "IsActiveView";
            cmbFilterValue.ValueMember = "IsActiveValue";

            cmbFilterValue.DataSource = dt;

        }
        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ClearAllFilterInputs();
            _HideAllFilterInputs();
            _CurrentFilterOption = (enFilterOption) cmbFilterOptions.SelectedValue;

            switch (_CurrentFilterOption)
            {
                case enFilterOption.None:
                    break;
                case enFilterOption.User_ID:
                case enFilterOption.Person_ID:
                case enFilterOption.Username:
                case enFilterOption.FullName:
                    txtFilterValue.Visible = true;
                    txtFilterValue.Focus();
                    break;
                case enFilterOption.Is_Active:
                    _ConfigureIsActiveComboBox();
                    cmbFilterValue.Visible = true;
                    break;
            }
            
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_CurrentFilterOption == enFilterOption.Person_ID
                ||
                _CurrentFilterOption == enFilterOption.User_ID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }


        private void _ApplyFilter()
        {

            DataView dv = _dtAllUsers.DefaultView;
            if (
                    _CurrentFilterOption == enFilterOption.None
                )
            {
                dv.RowFilter = "";
                return;
            }

            if (
                _CurrentFilterOption == enFilterOption.Is_Active
                )
            {
                if (cmbFilterValue.SelectedValue == null) return;

                enIsActiveValue selectedActiveValue = (enIsActiveValue)cmbFilterValue.SelectedValue;

                if (selectedActiveValue == enIsActiveValue.All)
                {
                    dv.RowFilter = "";
                }
                else
                {
                    bool activeBoolean = (bool)(selectedActiveValue == enIsActiveValue.Active ? true : false);
                    dv.RowFilter = $"IsActive = {activeBoolean}";
                }
                return;
            }

            string filterValue = txtFilterValue.Text.Trim();
            string columnName = _GetFilterOptionString(_CurrentFilterOption).Replace(" ", "");


            if (string.IsNullOrEmpty(filterValue))
            {
                dv.RowFilter = "";
            }
            else if (_CurrentFilterOption == enFilterOption.Person_ID
                ||
                _CurrentFilterOption == enFilterOption.User_ID
                )
            {
                dv.RowFilter = $"[{columnName}] = {filterValue}";
            }
            else
            {
                dv.RowFilter = $"[{columnName}] LIKE '{filterValue}%'";
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
            lblRecords.Text = dgvUsers.Rows.Count.ToString();
        }
    }
}
