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

namespace DrivingLicense.Presentation.controls
{
    public partial class usrPersonDetails : UserControl
    {
        public event Action<int> OnSave;

        private int _PersonID = -1;
        public usrPersonDetails()
        {
            InitializeComponent();
        }
        private void _SetDefaultData()
        {
            llEditPersonInfo.Enabled = false;
            lblPersonID.Text = "???";
            lblName.Text ="???";
            lblNationalNo.Text = "???";
            lblDateOfBirth.Text = "???";
            lblGendor.Text = "???";
            lblPhone.Text = "???";
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblCountry.Text = "???";
            pbPersonImage.Image = null;
            _PersonID = -1;
        }

        public int GetPersonID()
        {
            return _PersonID;
        }
        private void usrPersonDetails_Load(object sender, EventArgs e)
        {
            pbGendor.Visible = false;
            llEditPersonInfo.Enabled = false;
        }

        private void _LoadPersonInfo(clsPerson person)
        {
            llEditPersonInfo.Enabled = true;
            lblPersonID.Text = person.PersonId.ToString();
            lblName.Text = person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
            lblNationalNo.Text = person.NationalNo;
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            pbGendor.Visible = true;
            if (person.Gendor == 0)
            {
                pbGendor.ImageLocation = clsImage.MaleImagePath;
                pbPersonImage.ImageLocation = clsImage.MaleImagePath;
                lblGendor.Text = "Male";

            }
            else
            {
                pbGendor.ImageLocation = clsImage.MaleImagePath;
                pbPersonImage.ImageLocation = clsImage.FemaleImagePath;
                lblGendor.Text = "Female";
            }

            lblPhone.Text = person.Phone;
            lblEmail.Text = string.IsNullOrEmpty(person.Email) ? "N/A" : person.Email;
            lblAddress.Text = person.Address;
            lblCountry.Text = person.CountryInfo.CountryName;


            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                pbPersonImage.Image = null;
                pbPersonImage.ImageLocation = person.ImagePath;
            }

            _PersonID = person.PersonId;
        }
        public void LoadPersonInfo(string nationalNo)
        {
            clsPerson person = clsPerson.FindByNationalNo(nationalNo);
            if (person == null)
            {
                MessageBox.Show($"Person With National No {nationalNo} Is Not Exists");
                _SetDefaultData();
                return;
            }
            _LoadPersonInfo(person);
        }
        public void LoadPersonInfo(int personId)
        {
            clsPerson person = clsPerson.FindById(personId);
            if(person == null)
            {
                MessageBox.Show($"Person With ID {personId} Is Not Exists");
                _SetDefaultData();
                return;
            }
            _LoadPersonInfo(person);
        }
        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(Convert.ToInt32(lblPersonID.Text));
            frm.OnSave += _HandlePersonSave;
            frm.ShowDialog();   
        }

        private void _HandlePersonSave(int personId)
        {
            LoadPersonInfo(personId);
            OnSave?.Invoke(personId);
        }
    }
}
