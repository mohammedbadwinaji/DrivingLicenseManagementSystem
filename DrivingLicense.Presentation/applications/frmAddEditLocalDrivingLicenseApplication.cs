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
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.BusinessLogic.Models;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        public event Action<int> OnSave;
        private enum enMode
        {
            AddNew,
            Edit
        }
        private enMode _Mode;
        private int _LDLAppID;
        private clsLocalDrivingLicenseApplication _LDLApp;

        private bool _AllowGoNext = false;

        public frmAddEditLocalDrivingLicenseApplication(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LDLAppID = localDrivingLicenseApplicationId;
            _LDLApp = new clsLocalDrivingLicenseApplication();
        }

      

        private void _ConfigureMode()
        {
            _Mode = _LDLAppID == -1 ? enMode.AddNew : enMode.Edit;
        }
        private void _ConfigureTitle()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    lblTitle.Text = "Add New Local Driving License Application";
                    
                    break;
                case enMode.Edit:
                    lblTitle.Text = "Edit Local Driving License Application";
                    break;
            }
            int horizontalCenter = (this.Width / 2) - (lblTitle.Width / 2);
            lblTitle.Location = new Point(horizontalCenter, 20);
        }

        private void _ConfigureSaveButton()
        {
            btnSave.Enabled = _LDLAppID != -1 && usrPersonFilter1.GetPersonID() != -1;
        }
        private void _ConfigureLicenseClassesComboBox()
        {
            DataTable licenseClasses = clsLicenseClass.GetAllLicenseClasses();
            cmbLicenseClasses.DataSource = licenseClasses;

            cmbLicenseClasses.DisplayMember = "ClassName";
            cmbLicenseClasses.ValueMember = "LicenseClassID";

            cmbLicenseClasses.SelectedIndex = 2;
        }
        private void _ConfureFormData()
        {

            if(_Mode == enMode.AddNew)
            {
                _LDLApp = new clsLocalDrivingLicenseApplication();
                lblLDLAppID.Text = "???";
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblFees.Text = clsApplicationType.GetFees(enApplicationType.NewInternationalLicense).ToString();
                lblCreatedByUsername.Text = clsSettings.CurrentLoggedInUser?.UserName ?? "No Logged In User";
                lblCreatedByUsername.Tag = clsSettings.CurrentLoggedInUser?.UserId ?? -1;
                cmbLicenseClasses.SelectedIndex = 2;
            }
            if (_Mode == enMode.Edit)
            {
                _LDLApp = clsLocalDrivingLicenseApplication.FindByID(_LDLAppID);
                if (_LDLApp == null)
                {
                    MessageBox.Show("The application could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                usrPersonFilter1.LoadPersonInfo(_LDLApp.ApplicantPersonID);
                usrPersonFilter1.DisableFilter();
                lblLDLAppID.Text = _LDLApp.LocalDrivingLicenseApplicationsID.ToString();
                lblApplicationDate.Text = _LDLApp.ApplicationDate.ToShortDateString();
                lblFees.Text = _LDLApp.PaidFees.ToString();
                lblCreatedByUsername.Text = _LDLApp.CreatedByUserName;
                lblCreatedByUsername.Tag = _LDLApp.CreatedByUserID;
                cmbLicenseClasses.SelectedValue = _LDLApp.LicenseClassID;
            }
        }

        private void _ResetForm()
        {
            _ConfigureMode();
            _ConfigureTitle();
            _ConfigureLicenseClassesComboBox();
            usrPersonFilter1.OnSearch += _HandlePersonSearch;
            _ConfureFormData();
            _ConfigureSaveButton();
            _AllowGoNext = _Mode == enMode.AddNew ? false : true;
        }
        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetForm();
        }

        private void _HandlePersonSearch(int personId)
        {
            _ConfigureSaveButton();
            if(personId == -1)
            {
                _AllowGoNext = false;
            } else
            {
                _AllowGoNext = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void _LoadLDLADataFromUI()
        {
            _LDLApp.ApplicantPersonID = usrPersonFilter1.GetPersonID();
            _LDLApp.LicenseClassID =(int)cmbLicenseClasses.SelectedValue;
            _LDLApp.PaidFees = Convert.ToDecimal(lblFees.Text);
            _LDLApp.CreatedByUserID =(int) lblCreatedByUsername.Tag;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _LoadLDLADataFromUI();

            string errorMessage = string.Empty;
            if(_LDLApp.Save(out errorMessage))
            {
                MessageBox.Show("Driving License Application Saved Successfully");
                _LDLAppID = _LDLApp.LocalDrivingLicenseApplicationsID;
                _ResetForm();
                OnSave?.Invoke(_LDLAppID);
            } else
            {
                MessageBox.Show(errorMessage,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (usrPersonFilter1.GetPersonID() == -1)
            {
                MessageBox.Show("Choose Person First ");
                btnSave.Enabled = false;
                return;
            }
            _GoToNextPage();
            btnSave.Enabled = true;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _GoToPrevPage();
        }

        private void _GoToNextPage()
        {
            if (tbLDLApp.TabCount <= tbLDLApp.SelectedIndex + 1)
            {
                return;
            }
            _AllowGoNext = true;
            tbLDLApp.SelectedIndex = tbLDLApp.SelectedIndex + 1;
        }
        private void _GoToPrevPage()
        {
            if (tbLDLApp.SelectedIndex == 0)
            {
                return;
            }
            _AllowGoNext = true;
            tbLDLApp.SelectedIndex = tbLDLApp.SelectedIndex - 1;
        }

        private void tbLDLApp_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_AllowGoNext)
            {
                e.Cancel = true;
            }
        }
    }
}
