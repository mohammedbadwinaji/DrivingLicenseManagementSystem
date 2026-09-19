using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Applications;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsTestAppointment
    {
        private enum enMode
        {
            AddNew,
            Edit
        }
        public int TestAppointmentID { get; private set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public enTestType TestType { get;  set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; private set; }
        public int RetakeTestApplicationID { get; set; }

        public clsRetakeTestApplication RetakeTestApplicationInfo { get; private set; }
        public int TestID { get; private set; }
        private enMode _Mode;

        public int GetTrial
        {
            get
            {
               return clsTestDataAccess.GetTestCount(this.LocalDrivingLicenseApplicationID,(int)this.TestType);
            }
        }
        public static int GetTrails(int localDrivingLicenseApplicationId,enTestType testType)
        {
            return clsTestDataAccess.GetTestCount(localDrivingLicenseApplicationId, (int)testType);
        }
        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.TestType = enTestType.None;
            this.AppointmentDate = DateTime.Today;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;
            this.TestID = -1;
            this._Mode = enMode.AddNew;
            this.RetakeTestApplicationInfo = null;
        }

        public clsTestAppointment(int testAppointmentID, int localDrivingLicenseApplicationID, enTestType testType, DateTime appointmentDate, decimal paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID,int testId)
        {
            TestAppointmentID = testAppointmentID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            TestType = testType;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
            RetakeTestApplicationID = retakeTestApplicationID;
            TestID = testId;
            this._Mode = enMode.Edit;
            RetakeTestApplicationInfo = clsRetakeTestApplication.FindByID(retakeTestApplicationID);
        }

        public static DataTable GetAllLocalAppAppointmentsPerTestType
            (
                int localDrivingLicenseApplicationId,enTestType testType
            )
        {
            return clsTestAppointmentDataAccess.GetAllLocalAppsAppointmentsPerTestType(localDrivingLicenseApplicationId, (int)testType);
        }

        public static clsTestAppointment GetLastLocalAppAppointmentPerTestType
            (
                int localDrivingLicenseApplicationId, enTestType testType
            )
        {
            int testAppointmentId, createdByUserId, retakeTestApplicationId, testId;
            DateTime appointmentDate;
            bool isLocked;
            decimal paidFees;
            bool isFound = clsTestAppointmentDataAccess.GetLastLocalAppAppointmentPerTestType
                (
                localDrivingLicenseApplicationId,(int)testType,out testAppointmentId,
                out appointmentDate,out paidFees,out createdByUserId,out isLocked,
                out retakeTestApplicationId,out testId
                );
            if (!isFound)
            {
                return null;
            }

            return new clsTestAppointment(testAppointmentId, localDrivingLicenseApplicationId, testType, appointmentDate, paidFees, createdByUserId, isLocked, retakeTestApplicationId, testId);
        }

        
        public static clsTestAppointment FindByID(int testAppointmentId)
        {
            int localDrivingLicenseApplicationId, testTypeId, createdByUserId, retakeTestApplicationId, testId;
            bool isLocked;
            DateTime appointmentDate;
            decimal paidFees;

            bool isFound = clsTestAppointmentDataAccess.GetByID
                (
                testAppointmentId, out localDrivingLicenseApplicationId, out testTypeId,
                out appointmentDate, out paidFees, out createdByUserId,
                out isLocked, out retakeTestApplicationId, out testId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsTestAppointment(testAppointmentId, localDrivingLicenseApplicationId, (enTestType)testTypeId, appointmentDate, paidFees, createdByUserId, isLocked, retakeTestApplicationId,testId);
        }
        

        
        private bool _AddNewAppointment(out string errorMessage)
        {
            errorMessage = string.Empty;

            clsTestAppointment lastAppointment = GetLastLocalAppAppointmentPerTestType(this.LocalDrivingLicenseApplicationID, this.TestType);

            if(lastAppointment != null)
            {
                if (!lastAppointment.IsLocked)
                {
                    errorMessage = "Person Already Has An Active Appointment for This Test , You Cannot Add New Appointment"; 
                        return false;
                }
                clsTest test = clsTest.FindByID(lastAppointment.TestID);
                if (test != null) { 
                    if(test.TestResult == true)
                    {
                        errorMessage = "Person Already Passed This Test";
                        return false;
                    }
                }
            }


            this.TestAppointmentID = clsTestAppointmentDataAccess.Insert
                (
                   (int)this.TestType, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                   this.PaidFees, this.CreatedByUserID, this.IsLocked,this.RetakeTestApplicationID
                );

            if(this.TestAppointmentID != -1)
            {
                this._Mode = enMode.Edit;
            }

            return this.TestAppointmentID != -1;
        }
        private bool _EditAppointment (out string errorMessage)
        {
            
            errorMessage = string.Empty;

            clsTestAppointment currentAppointment = FindByID(this.TestAppointmentID);

            if (currentAppointment != null)
            {
                if (currentAppointment.IsLocked)
                {
                    errorMessage = "Appointment Is Locked  ,You Cannot Edit The Appointment"; 
                        return false;
                }
            }

            bool isUpdated = clsTestAppointmentDataAccess.Update
                (
                    this.TestAppointmentID, this.AppointmentDate, this.IsLocked)
                ;
            return isUpdated;
        }
        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;
            if(this.LocalDrivingLicenseApplicationID == -1)
            {
                errorMessage = "Cannot Save Without Select Local App";
                return false;
            }
            if(this.TestType == enTestType.None)
            {
                errorMessage = "Cannot Save Without Select Test Type";
                return false;
            }
            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Save The Appointment";
                return false;
            }
            

            switch (this._Mode)
            {
                case enMode.AddNew:
                    return _AddNewAppointment(out errorMessage);
                case enMode.Edit:
                    return _EditAppointment(out errorMessage);
            }

            return false;
        }
    }
}
