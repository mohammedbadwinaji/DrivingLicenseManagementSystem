using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DrivingLicense.Presentation
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private clsPerson _GetPersonByID(int id)
        {
            return clsPerson.FindById(id);
        }
        private void btnViewPersonDetails_Click(object sender, EventArgs e)
        {
            clsPerson person = _GetPersonByID(1);
            if (person == null) {
                MessageBox.Show("Person Not Exists");
            } else
            {
                string personData = "";
                personData += ("National No " + person.NationalNo + '\n');
                personData += ("Full Name " + person.FirstName + " " + person.LastName + '\n');
                personData += ("Country Name : " + person.CountryInfo.CountryName + '\n');

                MessageBox.Show(personData);    
            }
        }

        private void btnInsertNewPerson_Click(object sender, EventArgs e)
        {
            clsPerson person = new clsPerson();
            person.NationalNo = "n15";
            person.FirstName = "Mohammed";
            person.SecondName = "B";
            person.ThirdName = "C";
            person.LastName = "D";
            person.DateOfBirth = DateTime.Now;
            person.Gendor = 0;
            person.Phone = "0987654321";
            person.Email = null;
            person.Address = "street 1234";
            person.ImagePath = null;
            person.NationalityCountryID = 169;

            string errorMessages;
            if (person.Save(out errorMessages))
            {
                MessageBox.Show("Person Saved Successfully");
            } else
            {
                MessageBox.Show(errorMessages);
            }

        }

        private void btnUpdatePerson_Click(object sender, EventArgs e)
        {
            clsPerson person = clsPerson.FindById(3041);
            person.NationalityCountryID = 5;

            string errorMessages;
            if (person.Save(out errorMessages))
            {
                
                MessageBox.Show($"Person Saved Successfully \n\nupdated country is {person.CountryInfo.CountryName}");
                
            }
            else
            {
                MessageBox.Show(errorMessages);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            try
            {
                clsTestAppointment testAppointment = new clsTestAppointment();
                testAppointment.LocalDrivingLicenseApplicationID = 55;
                testAppointment.AppointmentDate = DateTime.Today;
                testAppointment.TestType = enTestType.Vision;
                testAppointment.PaidFees = clsTestType.FindByID((int)enTestType.Vision).TestTypeFees;
                testAppointment.CreatedByUserID = 1028;
                int trails = testAppointment.GetTrial;

                string errorMessage;
                if (testAppointment.Save(out errorMessage))
                {
                    MessageBox.Show("Appointment Saved Successfully");
                    if (trails > 0)
                    {
                        clsRetakeTestApplication retakeTestApplication = new clsRetakeTestApplication();
                        retakeTestApplication.ApplicantPersonID = 3045;
                        retakeTestApplication.CreatedByUserID = 1028;
                        retakeTestApplication.Save(out errorMessage);
                    }
                }
                clsTest test = new clsTest();

                test.TestAppointmentID = 1074;
                test.TestResult = false;
                test.Notes = null;
                test.CreatedByUserID = 1028;

                if (test.Save(out errorMessage))
                {

                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
