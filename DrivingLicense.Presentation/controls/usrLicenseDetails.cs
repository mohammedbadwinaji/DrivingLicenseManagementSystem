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
        public usrLicenseDetails()
        {
            InitializeComponent();
        }

        public void LoadLicenseInof(int licenseId)
        {
            clsLicense license = clsLicense.FindByID(licenseId);

            if(license == null)
            {
                return;
            }

            lblLicenseClass.Text = license.GetLicenseClassName;
            lblName.Text = license.GetFullName;
            lblLicenseID.Text = license.LicenseID.ToString();
            lblNationalNo.Text = license.DriverInfo.PersonInfo.NationalNo;
            if(license.DriverInfo.PersonInfo.Gendor == 0)
            {
                lblGendor.Text = "Male";
                pbGendor.ImageLocation = clsImage.MaleImagePath;
            }else
            {
                lblGendor.Text = "Female";
                pbGendor.ImageLocation = clsImage.FemaleImagePath;
            }
            lblIssueDate.Text = license.IssueDate.ToShortDateString();
            lblIssueReason.Text = license.IssueReason.ToString();
            lblNotes.Text = string.IsNullOrEmpty(license.Notes) ? "No Notes":license.Notes;
            lblIsActive.Text = license.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = license.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = license.DriverID.ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();
            lblIsDetained.Text = license.IsDetained ? "Yes" : "No";

            string imagePath = license.DriverInfo.PersonInfo.ImagePath;
            if(imagePath == null)
            {
                pbPersonImage.ImageLocation = license.DriverInfo.PersonInfo.Gendor == 0 ?
                    clsImage.MaleImagePath : clsImage.FemaleImagePath;
            }
            else
            {
                pbPersonImage.ImageLocation = imagePath;
            }

        }
    }
}
