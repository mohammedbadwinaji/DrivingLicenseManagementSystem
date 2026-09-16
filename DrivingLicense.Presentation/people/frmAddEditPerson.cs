using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;
using DrivingLicense.Presentation.Properties;

namespace DrivingLicense.Presentation.people
{
    public partial class frmAddEditPerson : Form
    {
        public event Action<int> OnSave;
        private enum enMode
        {
            AddNew,
            Edit
        }
        private int _PersonId;
        private clsPerson _CurrentPerson;
        private enMode _CurrentMode;
        public frmAddEditPerson(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
            _CurrentPerson = new clsPerson();
        }
        private void _ConfigureDateOfBirthDateTimePicker()
        {
            DateTime eighteenYearsAgo = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.MaxDate = eighteenYearsAgo;
        }
        private void _ConfigureCountriesComboBox()
        {
            DataTable countries = clsCountry.GetAllCountries();
            cmbCountries.DataSource = countries;

            cmbCountries.DisplayMember = "CountryName";
            cmbCountries.ValueMember = "CountryID";

            cmbCountries.SelectedIndex = cmbCountries.FindString("Syria");
        }
        private void _ConfigureMode()
        {
            if (_PersonId == -1) {
                _CurrentMode = enMode.AddNew;
            }else
            {
                _CurrentMode = enMode.Edit;
            }
        }
        private void _ConfigureTitle()
        {
            switch (_CurrentMode)
            {
                case enMode.AddNew:
                    lblTitle.Text = "Add New Person";
                    break;
                case enMode.Edit:
                    lblTitle.Text = $"Edit Person {_PersonId}";
                    break;
            }
            int xAxix = (this.Width / 2) - (lblTitle.Width / 2);
            lblTitle.Location= new Point(xAxix, lblTitle.Location.Y);
        }

        private void _ResetPersonData()
        {
            _CurrentPerson = new clsPerson();
            lblPersonID.Text = "N/A";
            txtFirstName.Clear();
            txtSecondName.Clear();
            txtThirdName.Clear();
            txtLastName.Clear();
            txtNationalNo.Clear();
            DateTime eighteenYearsAgo = DateTime.Today.AddYears(-18);
            dtpDateOfBirth.Value = eighteenYearsAgo;
            rbMale.Checked = true;
            pbPersonImage.Image = null;
            pbPersonImage.ImageLocation = Path.GetFullPath(clsImage.MaleImagePath);
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            llRemoveImage.Visible = false;

        }
        private void _LoadPersonDataToUI()
        {
            _CurrentPerson = clsPerson.FindById(_PersonId);
            lblPersonID.Text = _CurrentPerson.PersonId.ToString();
            txtFirstName.Text = _CurrentPerson.FirstName;
            txtSecondName.Text = _CurrentPerson.SecondName;
            txtThirdName.Text = _CurrentPerson.ThirdName;
            txtLastName.Text = _CurrentPerson.LastName;
            txtNationalNo.Text = _CurrentPerson.NationalNo;
            dtpDateOfBirth.Value = _CurrentPerson.DateOfBirth;

            pbPersonImage.Image = null;
            if (_CurrentPerson.Gendor == 0)
            {
                rbMale.Checked = true;
                pbPersonImage.ImageLocation = Path.GetFullPath(clsImage.MaleImagePath);
            }
            else
            {
                rbFemale.Checked = true;
                pbPersonImage.ImageLocation = Path.GetFullPath(clsImage.FemaleImagePath);
            }
            
            txtPhone.Text = _CurrentPerson.Phone;
            txtEmail.Text = _CurrentPerson.Email;
            txtAddress.Text  = _CurrentPerson.Address;
            if(!string.IsNullOrEmpty(_CurrentPerson.ImagePath))
            {
                if(File.Exists(_CurrentPerson.ImagePath))
                {
                    pbPersonImage.ImageLocation = _CurrentPerson.ImagePath;
                    llRemoveImage.Visible = true;
                }
            }
            cmbCountries.SelectedValue = _CurrentPerson.NationalityCountryID;
        }
        private void _ConfigurePersonData()
        {
            switch (_CurrentMode)
            {
                case enMode.AddNew:
                    _ResetPersonData();
                    break;
                case enMode.Edit:
                    _LoadPersonDataToUI();
                    break;
            }
        }
        private void _ConfigureNationalNoTextBox()
        {
            switch (_CurrentMode)
            {
                case enMode.AddNew:
                    txtNationalNo.Enabled = true;
                    break;
                case enMode.Edit:
                    txtNationalNo.Enabled = false;
                    break;
            }
        }
        private void _ResetForm()
        {
            _ConfigureDateOfBirthDateTimePicker();
            _ConfigureCountriesComboBox();
            _ConfigureMode();
            _ConfigureTitle();
            _ConfigurePersonData();
            _ConfigureNationalNoTextBox();
        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetForm();
        }

      
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            bool isNationalAlreadyExists = clsPerson.CheckNationalNoExists(txtNationalNo.Text, _PersonId);

            if (isNationalAlreadyExists) {
                epPerson.SetError(txtNationalNo, "National Number Is Used For Another Person ");
            }else
            {
                epPerson.SetError(txtNationalNo, null);
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _HandleGendorChanging();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _HandleGendorChanging();
        }

        private bool _CheckIfDefaultImageIsUsed()
        {
            string currentPath = pbPersonImage.ImageLocation;
            string defaultMalePath = Path.GetFullPath(clsImage.MaleImagePath);
            string defaultFemalePath = Path.GetFullPath(clsImage.FemaleImagePath);

            bool isUsingDefaultImage = string.IsNullOrEmpty(currentPath) ||
                                       currentPath.Equals(defaultMalePath, StringComparison.OrdinalIgnoreCase) ||
                                       currentPath.Equals(defaultFemalePath, StringComparison.OrdinalIgnoreCase);

            return isUsingDefaultImage;
        }
        private void _HandleGendorChanging()
        {
            bool isUsingDefaultImage = _CheckIfDefaultImageIsUsed();
            if (isUsingDefaultImage)
            {
                pbPersonImage.Image = null;

                if (rbMale.Checked)
                {
                    pbPersonImage.ImageLocation = clsImage.MaleImagePath;
                }
                else if (rbFemale.Checked)
                {
                    pbPersonImage.ImageLocation = clsImage.FemaleImagePath;
                }
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _HandleGendorChanging();
            llRemoveImage.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void _LoadPersonDataFromUI()
        {
            _CurrentPerson.FirstName = txtFirstName.Text;
            _CurrentPerson.SecondName = txtSecondName.Text;
            _CurrentPerson.ThirdName = txtThirdName.Text;
            _CurrentPerson.LastName = txtLastName.Text;
            _CurrentPerson.DateOfBirth = dtpDateOfBirth.Value;
            _CurrentPerson.Gendor = (byte)(rbMale.Checked ? 0 : 1);
            _CurrentPerson.NationalityCountryID = (int)cmbCountries.SelectedValue;
            _CurrentPerson.NationalNo = txtNationalNo.Text;
            _CurrentPerson.Phone = txtPhone.Text;
            _CurrentPerson.Email = txtEmail.Text;
            _CurrentPerson.Address = txtAddress.Text;
            _CurrentPerson.ImagePath = _CheckIfDefaultImageIsUsed() ? null : pbPersonImage.ImageLocation;
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadPersonDataFromUI();

            string errorMessage;
            if (_CurrentPerson.Save(out errorMessage))
            {
                MessageBox.Show("Person Saved Successfully");
                _PersonId = _CurrentPerson.PersonId;
                _ResetForm();
                OnSave?.Invoke(_PersonId);
            }else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            openFileDialog.Title = "Select Profile Image";

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                if (File.Exists(selectedFilePath))
                {
                    pbPersonImage.Image = null;

                    pbPersonImage.ImageLocation = selectedFilePath;

                    llRemoveImage.Visible = true;
                }
            }
        }
    }
}
