using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic.Licenses;

namespace DrivingLicense.Presentation.controls
{
    public partial class usrLicenseDetails : UserControl
    {
        private int _LicenseID = -1;

        private clsLicense _LicenseInfo = null;
        public usrLicenseDetails()
        {
            InitializeComponent();
        }

        private void _LoadDefaultData()
        {
            _LicenseID = -1;
            lblLicenseClass.Text = "???";
            lblName.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            pbGendor.Hide();
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblIsActive.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblIsDetained.Text = "???";

            pbPersonImage.ImageLocation = "";
        }
        public int GetLicenseID()
        {
            return _LicenseID;
        }
        public clsLicense GetLicenseInfo()
        {
            return _LicenseInfo;
        }

        private void _LoadLicenseInfo()
        {
            _LicenseID = _LicenseInfo.LicenseID;
            lblLicenseClass.Text = _LicenseInfo.GetLicenseClassName;
            lblName.Text = _LicenseInfo.GetFullName;
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            if (_LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pbGendor.ImageLocation = clsImage.MaleImagePath;
            }
            else
            {
                lblGendor.Text = "Female";
                pbGendor.ImageLocation = clsImage.FemaleImagePath;
            }
            lblIssueDate.Text = _LicenseInfo.IssueDate.ToShortDateString();
            lblIssueReason.Text = _LicenseInfo.IssueReason.ToString();
            lblNotes.Text = string.IsNullOrEmpty(_LicenseInfo.Notes) ? "No Notes" : _LicenseInfo.Notes;
            lblIsActive.Text = _LicenseInfo.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _LicenseInfo.DriverID.ToString();
            lblExpirationDate.Text = _LicenseInfo.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = _LicenseInfo.IsDetained ? "Yes" : "No";

            string imagePath = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;
            if (imagePath == null)
            {
                pbPersonImage.ImageLocation = _LicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ?
                    clsImage.MaleImagePath : clsImage.FemaleImagePath;
            }
            else
            {
                pbPersonImage.ImageLocation = imagePath;
            }
        }
        public void LoadLicenseInfo(int licenseId)
        {
            _LicenseInfo = clsLicense.FindByID(licenseId);

            if(_LicenseInfo == null)
            {
                _LoadDefaultData();
                return;
            }

            _LoadLicenseInfo();
         

        }
    }
}
