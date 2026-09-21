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
    public partial class usrInternationalLicenseDetails : UserControl
    {
        private int _InternationalLicenseID;

        private clsInternationalLicense _InternationalLicenseInfo;
        public usrInternationalLicenseDetails()
        {
            InitializeComponent();
            
        }

        private void _LoadDefaultData()
        {
            lblName.Text = "???";
            lblInternationalLicenseID.Text = "???";
            lblLicenseID.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            pbGendor.Hide();
            lblIssueDate.Text = "???";
            lblApplicationID.Text = "???";
            lblIsActive.Text = "???";
            lblDateOfBirth.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            pbPersonImage.ImageLocation = "";
        }
        private void _LoadInternationalLicenseInfo()
        {
            
            lblName.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.GetFullName;
            lblInternationalLicenseID.Text = _InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicenseInfo.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            if(_InternationalLicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pbGendor.ImageLocation = clsImage.MaleImagePath;
            } else
            {
                lblGendor.Text = "Feale";
                pbGendor.ImageLocation = clsImage.FemaleImagePath;
            }
            lblIssueDate.Text = _InternationalLicenseInfo.IssueDate.ToShortDateString();
            lblApplicationID.Text = _InternationalLicenseInfo.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicenseInfo.IsActive ? "Yes": "No";
            lblDateOfBirth.Text = _InternationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _InternationalLicenseInfo.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = _InternationalLicenseInfo.ExpirationDate.ToShortDateString();

            string imagePath = _InternationalLicenseInfo.DriverInfo.PersonInfo.ImagePath;

            if (string.IsNullOrEmpty(imagePath))
            {
                pbPersonImage.ImageLocation = _InternationalLicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ?
                                                clsImage.MaleImagePath :
                                                clsImage.FemaleImagePath;
            } else
            {
                pbPersonImage.ImageLocation = imagePath;
            }
        }
        public void LoadInternationalLicenseInfo(int InternationalLicenseId)
        {
            _InternationalLicenseID = InternationalLicenseId;
            _InternationalLicenseInfo = clsInternationalLicense.FindByID(InternationalLicenseId);
            if (_InternationalLicenseInfo == null) {
                _LoadDefaultData();
                return;
            }

            _LoadInternationalLicenseInfo();
        }
    }
}
