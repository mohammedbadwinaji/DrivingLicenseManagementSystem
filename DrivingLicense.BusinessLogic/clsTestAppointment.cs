using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private enMode _Mode;
        public int TestAppointmentID { get; private set; }
        public int TestID { get; private set; }
        public enTestType TestType { get; set; }
        public string TestTypeTitle { get; private set; }

        public enLicenseClass LicenseClass { get; set; }
        public string LicenseClassTitle { get; private set; }

        public int LocalDrivingLicenseApplicationID { get; set; }

        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public string CreatedByUsername { get; private set; }
        public bool IsLocked { get; private set; }

        public string FullName { get;private set; }
        public int Trail {  get; private set; }

        private clsTestAppointment( int testAppointmentID, int testID, enTestType testType, string testTypeTitle, enLicenseClass licenseClass, string licenseClassTitle, int localDrivingLicenseApplicationID, DateTime appointmentDate, decimal paidFees, int createdByUserID, string createdByUsername, bool isLocked, string fullName, int trail)
        {
            TestAppointmentID = testAppointmentID;
            TestID = testID;
            TestType = testType;
            TestTypeTitle = testTypeTitle;
            LicenseClass = licenseClass;
            LicenseClassTitle = licenseClassTitle;
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            CreatedByUsername = createdByUsername;
            IsLocked = isLocked;
            FullName = fullName;
            Trail = trail;
            _Mode = enMode.Edit;
        }

        public static DataTable GetAllTestAppointmentsByLocalDrivingLicenseApplicationID(int localDrivingLicenseApplicationId,int testTypeId)
        {
            return clsTestAppointmentDataAccess.GetAllAppointmentsByLocalDrivingLicenseApplicationAndTestType(localDrivingLicenseApplicationId,testTypeId);
        }

        public clsTestAppointment
            (
            int localDrivingLicenseApplicationID,int testTypeId
            )
        {
            clsLocalDrivingLicenseApplication ldlApp = clsLocalDrivingLicenseApplication.FindByID(localDrivingLicenseApplicationID);
            if(ldlApp == null)
            {
                TestAppointmentID = -1;
                TestType = enTestType.None;
                TestTypeTitle = string.Empty;
                LocalDrivingLicenseApplicationID = -1;
                LicenseClass = enLicenseClass.None;
                LicenseClassTitle = string.Empty;
                AppointmentDate = DateTime.Now;
                PaidFees = 0;
                CreatedByUserID = -1;
                CreatedByUsername = string.Empty;
                IsLocked = false;
                FullName = string.Empty;
                Trail = 0;
                TestID = -1;
                _Mode = enMode.AddNew;
                return;
            }
            TestAppointmentID = -1;
            TestType = (enTestType)testTypeId;
            TestTypeTitle = string.Empty;
            LocalDrivingLicenseApplicationID = ldlApp.LocalDrivingLicenseApplicationsID;
            LicenseClass = (enLicenseClass)ldlApp.LicenseClassID;
            LicenseClassTitle = ldlApp.LicenseClassName;
            AppointmentDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
            CreatedByUsername = string.Empty;
            IsLocked = false;
            FullName = ldlApp.ApplicantFullName;
            Trail = 0;
            TestID = -1;
            _Mode = enMode.AddNew;
        }

        
        public static bool IsLocalApplicationAlreadyHasActiveAppointment
            (
            int localDrivingLicenseApplicationId, int testTypeId
            )
        {
            return clsTestAppointmentDataAccess.CheckIfLocalApplicationHasActiveTestAppintment(localDrivingLicenseApplicationId, testTypeId);
            
        }
        public static bool IsAlreadyPassedTest
            (
                int localDrivingLicenseApplicationId, int testTypeId
            )
        {
            return clsTestAppointmentDataAccess.CheckIfPassedTest(localDrivingLicenseApplicationId, testTypeId);
        }
        private bool _AddNew(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (IsLocalApplicationAlreadyHasActiveAppointment(this.LocalDrivingLicenseApplicationID, (int)this.TestType))
            {
                errorMessage = $"Local Application {this.LocalDrivingLicenseApplicationID} Already Has Active Appointment";
                return false;
            }

            if (this.AppointmentDate < DateTime.Today)
            {
                errorMessage = "You Cannot Save Appointment In Past";
                return false;
            }
            this.TestAppointmentID = clsTestAppointmentDataAccess.Insert
                (
                    (int) this.TestType,this.LocalDrivingLicenseApplicationID,this.AppointmentDate,
                    this.PaidFees,this.CreatedByUserID,this.IsLocked
                );
            return false;
        }
        
        private bool _Edit(out string errorMessage)
        {
            errorMessage = string.Empty;
            return false;
        }
        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(this.LocalDrivingLicenseApplicationID == -1)
            {
                errorMessage = "No Local Application Related To THis Appointments, Cannot Save This Appointment";
                return false;
            }

            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Add This Appointment";
                return false;
            }

            if (this.TestType == enTestType.None)
            {
                errorMessage = "Please Select Test Type";
                return false;
            }

            if(this.PaidFees < clsTestType.FindByID((int)this.TestType).TestTypeFees)
            {
                errorMessage = "You Cannot Save Appointment Without Paying All Fees";
                return false;
            }


                switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNew(out errorMessage);
                case enMode.Edit:
                    return _Edit(out errorMessage);
            }

            return false;
        }

        public static  clsTestAppointment FindByID(int testAppointmentId)
        {
            int localDrivingLicenseApplicationId, licenseClassId, testTypeId, createdByUserId,testId,trail;
            string testTypeTitle, licenseClassName, fullName, createdByUsername;
            DateTime appointmentDate;
            decimal paidFees;
            bool isLocked;
            bool isFound = clsTestAppointmentDataAccess.GetByID
                (
                    testAppointmentId, out localDrivingLicenseApplicationId, out licenseClassId,
                    out testTypeId, out testTypeTitle, out licenseClassName, out fullName,
                    out trail, out appointmentDate, out paidFees,out testId,
                    out createdByUserId, out createdByUsername, out isLocked
                );

            if (!isFound)
            {
                return null;
            }

            return new clsTestAppointment
                (
                    testAppointmentId, testId, (enTestType)testTypeId, testTypeTitle,
                    (enLicenseClass)licenseClassId, licenseClassName, localDrivingLicenseApplicationId,
                    appointmentDate, paidFees, createdByUserId, createdByUsername,
                    isLocked, fullName, trail
                );
        }
        
    }
}
