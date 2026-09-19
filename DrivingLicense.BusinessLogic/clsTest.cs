using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsTest
    {
        public int TestID { get; private set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = null;
            this.CreatedByUserID = -1;
        }
        public clsTest(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            this.Notes = notes;
            this.CreatedByUserID = createdByUserID;
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(this.TestID != -1)
            {
                errorMessage = "You Need To Take Other Appointment To Retake Test";
                return false;
            }
            if(this.TestAppointmentID == -1)
            {
                errorMessage = "You Cannot Save Take Test Without Appointment";
                return false;
            }

            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Enroll Test Result";
                return false;
            }
            clsTestAppointment testAppointment = clsTestAppointment.FindByID(this.TestAppointmentID);
            if(testAppointment.TestID != -1)
            {
                errorMessage = "You Already Taked This Test , You Need To Add Another Appointment To Retake Test";
                return false;
            }

            this.TestID = clsTestDataAccess.Insert(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            clsTestAppointmentDataAccess.UpdateIsLocked(TestAppointmentID, true);
                
            return this.TestID != -1;

        }
        public static clsTest FindByID(int testId)
        {
            int testAppointmentId, createdByUserId;
            bool testResult;
            string notes;
            bool isFound = clsTestDataAccess.GetByID(testId, out testAppointmentId, out testResult, out notes, out createdByUserId);

            if (!isFound)
            {
                return null;
            }

            return new clsTest(testId, testAppointmentId, testResult, notes, createdByUserId);
        }
    }
}
