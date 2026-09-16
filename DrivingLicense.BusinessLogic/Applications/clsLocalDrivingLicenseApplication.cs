using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Applications
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        private enum enMode
        {
            AddNew,
            Edit
        }
        private enMode _Mode;
        public int LocalDrivingLicenseApplicationsID { get; private set; }
        public int LicenseClassID { get; set; }
        public string LicenseClassName { get; private set; }
        public int PassedTests { get; private set; }

        public int LicenseID { get; private set; }

        public clsLocalDrivingLicenseApplication() : base()
        {
            this.LocalDrivingLicenseApplicationsID = -1;
            this.LicenseClassID = -1;
            this.ApplicationType = enApplicationType.NewLocalDrivingLicenseService;
            LicenseClassName = string.Empty;
            PassedTests = 0;
            this.LicenseID = -1;
            _Mode = enMode.AddNew;
        }
        private clsLocalDrivingLicenseApplication
            (
                int localDrivingLicenseApplicationsID,int applicationID,int licenseClassID,
                string licenseClassName,int applicantPersonID,string applicantFullName,
                DateTime applicationDate,enApplicationType applicationType,string applicationTypeTitle,
                enApplicationStatus applicationStatus,string applicationStatusTitle,DateTime lastStatusDate,
                decimal paidFees,int createdByUserID,string createdByUserName,int passedTests,int licenseId
            )
    : base
            (
            applicationID, applicantPersonID,applicantFullName,
            applicationDate, applicationType,applicationTypeTitle , 
            applicationStatus,applicationStatusTitle, lastStatusDate, 
            paidFees, createdByUserID,createdByUserName

          )
        {
            this.LocalDrivingLicenseApplicationsID = localDrivingLicenseApplicationsID;
            this.LicenseClassID = licenseClassID;
            this.LicenseClassName = licenseClassName;
            this.PassedTests = passedTests;
            this.LicenseID = licenseId;
            _Mode = enMode.Edit;
        }

        public static DataTable GetAllApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllApplications();          
        }

        public static clsLocalDrivingLicenseApplication FindByID(int localDrivingLicenseApplicationId)
        {
            int applicationId, licenseClassId, applicantPersonId, applicationTypeId, applicationStatusId, createdByUserId, passedTests,licenseId;
            string licenseClassName, applicantFullName, applicationTypeTitle, applicationStatusTitle, createdByUserName;
            DateTime applicationDate, lastStatusDate;
            decimal paidFees;

            bool found = clsLocalDrivingLicenseApplicationDataAccess.GetByID(
                localDrivingLicenseApplicationId,out applicationId,out licenseClassId,
                out licenseClassName,out applicantPersonId,out applicantFullName,
                out applicationDate,out applicationTypeId,out applicationTypeTitle,
                out applicationStatusId,out applicationStatusTitle,out lastStatusDate,
                out paidFees,out createdByUserId,out createdByUserName,
                out passedTests,out licenseId
            );

            if (!found)
                return null;

            return new clsLocalDrivingLicenseApplication(
                localDrivingLicenseApplicationId,applicationId,licenseClassId,
                licenseClassName,applicantPersonId,applicantFullName,
                applicationDate,(enApplicationType)applicationTypeId,applicationTypeTitle,
                (enApplicationStatus)applicationStatusId,applicationStatusTitle,lastStatusDate,
                paidFees,createdByUserId,createdByUserName,
                passedTests,licenseId
            );
        }


        private bool _AddNew(out string errorMessage)
        {

            errorMessage = string.Empty;

            if (this.ApplicantPersonID == -1)
            {
                errorMessage = $"Enter Person To Continue";
                return false;
            }
            decimal fees = clsApplicationType.GetFees(enApplicationType.NewLocalDrivingLicenseService);
            if (this.PaidFees < fees)
            {
                errorMessage = $" Person Must Pay All Fees {fees}";
                return false;
            }
            if (this.CreatedByUserID == -1)
            {
                errorMessage = $"User Must Create This Applicatoin ";
                return false;
            }
            if (this.LicenseClassID == -1)
            {
                errorMessage = $" Person Must Choose License";
                return false;
            }

            bool isApplicantHasActiveApplication = clsLocalDrivingLicenseApplicationDataAccess.IsApplicantAlreadyHasActiveApplicationWithSameLicenseClass(this.ApplicantPersonID, this.LicenseClassID, -1);

            if ( isApplicantHasActiveApplication)
            {
                errorMessage = $"Choose Another License Class , The Selected Person Already Have An Active Application For The Selected Class With id {ApplicantPersonID}";
                return false;
            }
          
            this.LocalDrivingLicenseApplicationsID = clsLocalDrivingLicenseApplicationDataAccess.Insert(
                this.ApplicantPersonID,
                this.ApplicationDate,
                (int)this.ApplicationType,
                (int)this.ApplicationStatus,
                this.LastStatusDate,
                this.PaidFees,
                this.CreatedByUserID,
                this.LicenseClassID
            );

            if (this.LocalDrivingLicenseApplicationsID == -1)
            {
                errorMessage = "Failed to add new local driving license application.";
                return false;
            }

            this._Mode = enMode.Edit;

            return true;
        }
        
        private bool _Edit(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (this.ApplicantPersonID == -1)
            {
                errorMessage = $"Enter Person To Continue";
                return false;
            }
            decimal fees = clsApplicationType.GetFees(enApplicationType.NewLocalDrivingLicenseService);
            if (this.PaidFees < fees)
            {
                errorMessage = $" Person Must Pay All Fees {fees}";
                return false;
            }
            if (this.CreatedByUserID == -1)
            {
                errorMessage = $"User Must Create This Applicatoin ";
                return false;
            }
            if (this.LicenseClassID == -1)
            {
                errorMessage = $" Person Must Choose License";
                return false;
            }

            bool isApplicantHasActiveApplication = clsLocalDrivingLicenseApplicationDataAccess.IsApplicantAlreadyHasActiveApplicationWithSameLicenseClass(this.ApplicantPersonID, this.LicenseClassID, this.LocalDrivingLicenseApplicationsID);

            if (isApplicantHasActiveApplication)
            {
                errorMessage = $"Choose Another License Class , The Selected Person Already Have An Active Application For The Selected Class With id {ApplicantPersonID}";
                return false;
            }

            bool isUpdated = clsLocalDrivingLicenseApplicationDataAccess.Update(LocalDrivingLicenseApplicationsID, LicenseClassID);

            if (!isUpdated)
            {
                errorMessage = "Server Error!";
                return false;
            }
            return true;
        }

        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNew(out errorMessage);
                case enMode.Edit:
                    return _Edit(out errorMessage);
            }
            return false;
        }

        public static bool Cancel(int localDrivingLicenseApplicationId, out string errorMessage) 
        {
            errorMessage = string.Empty;
            clsLocalDrivingLicenseApplication ldlApp = FindByID(localDrivingLicenseApplicationId);

            if(ldlApp == null)
            {
                errorMessage = $"No Local Driving License Application With ID {localDrivingLicenseApplicationId}";
                return false;
            }

            if(ldlApp.ApplicationStatus == enApplicationStatus.Completed)
            {
                errorMessage = $"Local Driving License Application With ID {localDrivingLicenseApplicationId} Already Completed , You Cannot Cancel It";
                return false;
            }
            if(ldlApp.ApplicationStatus == enApplicationStatus.Canceled)
            {
                errorMessage = $"Local Driving License Application With ID {localDrivingLicenseApplicationId} Already Canceled";
                return false;
            }


            return clsLocalDrivingLicenseApplicationDataAccess.UpdateStatus(localDrivingLicenseApplicationId, (int)enApplicationStatus.Canceled);
        }


    }
}
