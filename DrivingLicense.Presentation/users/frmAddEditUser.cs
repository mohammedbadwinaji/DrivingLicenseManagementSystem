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
using DrivingLicense.Presentation.people;

namespace DrivingLicense.Presentation.users
{
    public partial class frmAddEditUser : Form
    {
        public event Action<int> OnSave;
        enum enMode
        {
            AddNew,
            Edit
        }
        private int _UserID;
        private clsUser _User;
        private enMode _Mode;

        private bool _AllowGoNext = false;
        public frmAddEditUser(int userId)
        {
            InitializeComponent();
            _UserID = userId;
            _User = new clsUser();
        }
        private void _ConfigureMode()
        {
            _Mode = _UserID == -1 ? enMode.AddNew : enMode.Edit;
        }
        private void _ConfigureTitle()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
            } else
            {
                lblTitle.Text = $"Edit User {_UserID}";
            }
        }
        private void _ConfigureSaveButton()
        {
            btnSave.Enabled = _UserID != -1 || usrPersonFilter1.GetPersonID() != -1;
        }
        private void _HandlePersonSearch(int personId)
        {
            _ConfigureSaveButton();
        }

        private void _ConfigureUserData()
        {
            if(_Mode == enMode.AddNew)
            {
                lblUserID.Text = "???";
                txtUsername.Clear();
                txtPassword.Clear();
                txtPasswordConfirmation.Clear();
                return;
            }

            _User = clsUser.FindByID(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"User With ID {_UserID} Not Found");
                return;
            }

            usrPersonFilter1.LoadPersonInfo(_User.PersonId);
            usrPersonFilter1.DisableFilter();
            lblUserID.Text = _User.UserId.ToString();
            txtUsername.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtPasswordConfirmation.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
        }
        private void _ResetForm()
        {
            _ConfigureMode();
            _ConfigureTitle();
            _ConfigureSaveButton();
            usrPersonFilter1.OnSearch += _HandlePersonSearch;
            _ConfigureUserData();
            _AllowGoNext = _Mode == enMode.AddNew ? false : true;
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetForm();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(usrPersonFilter1.GetPersonID() == -1)
            {
                MessageBox.Show("Choose Person First ");
                return;
            }
            switch (_Mode)
            {
                case enMode.AddNew:

                    bool isUser = clsPerson.CheckIsUser(usrPersonFilter1.GetPersonID());
                    if (isUser)
                    {
                        MessageBox.Show($"Person With ID {usrPersonFilter1.GetPersonID()} Is Already User, Choose Another One");
                        _AllowGoNext = false;
                        btnSave.Enabled = false;
                        return;
                    }
                    else
                    {
                        _GoToNextPage();
                        btnSave.Enabled = true;
                    }
                    break;
                case enMode.Edit:
                    _GoToNextPage();
                    btnSave.Enabled = true;
                    break;
            }
        }
        private void _GoToNextPage()
        {
            if (tbUser.TabCount <= tbUser.SelectedIndex + 1)
            {
                return;
            }
            _AllowGoNext = true;

            tbUser.SelectedIndex = tbUser.SelectedIndex + 1;
        }
        private void _GoToPrevPage()
        {
            if(tbUser.SelectedIndex == 0)
            {
                return;
            }
            _AllowGoNext = true;
            tbUser.SelectedIndex = tbUser.SelectedIndex - 1;
        }
        private void tbUser_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_AllowGoNext)
            {
                e.Cancel = true;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _GoToPrevPage();
        }


        private void _LoadUserInfo()
        {
            _User.PersonId = usrPersonFilter1.GetPersonID();
            _User.UserName = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string validationErrors = string.Empty;
            if(string.IsNullOrEmpty(txtUsername.Text))
            {
                validationErrors += "User Name Is Required\n";
            }
            if(string.IsNullOrEmpty(txtPassword.Text))
            {
                validationErrors += "Password Is Required\n";
            } else
            {
                if(txtPassword.Text != txtPasswordConfirmation.Text)
                {
                    validationErrors += "Password Does Not Match With Password Confirmation\n";
                }
            }

            if(validationErrors != string.Empty)
            {
                MessageBox.Show(validationErrors, "Validation Error !");
                return;
            }

            
            _LoadUserInfo();

            string errorMessage;
            if (_User.Save(out errorMessage))
            {
                MessageBox.Show("User Saved Successfully");
                _UserID = _User.UserId;
                _ResetForm();
                OnSave?.Invoke(_UserID);
                return;
            }

            MessageBox.Show(errorMessage);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
