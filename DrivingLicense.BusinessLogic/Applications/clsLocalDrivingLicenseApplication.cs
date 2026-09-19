using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace DrivingLicense.BusinessLogic.Applications
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public int LocalDrivingLicenseApplicationID { get; private set; }
        public enLicenseClass LicenseClass { get; set; }
        public  int PassedTests { get; private set; }
        public int LicenseID {get; private set;}

        private clsLocalDrivingLicenseApplication
        (
                int applicationID, enApplicationStatus applicationStatus, decimal paidFees, 
                enApplicationType applicationType,int applicantPersonID, DateTime applicationDate,
                DateTime lastStatusDate, int createdByUserID,int localDrivingLicenseApplicationID, 
                enLicenseClass licenseClass, int passedTests, int licenseID
            ) : base(applicationID,applicationStatus,paidFees,applicationType,applicantPersonID,applicationDate,lastStatusDate,createdByUserID)
        {
            LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            LicenseClass = licenseClass;
            PassedTests = passedTests;
            LicenseID = licenseID;
            _Mode = enMode.Edit;
        }

        public clsLocalDrivingLicenseApplication() : base()
        {
            this.ApplicationType = enApplicationType.NewLocalDrivingLicenseService;
           
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClass = enLicenseClass.None;
            this.PassedTests = 0;
            this.LicenseID = -1;

            this._Mode = enMode.AddNew;
        }


        private bool _AddNewLocalApplication(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (clsLocalDrivingLicenseApplicationDataAccess.IsApplicantAlreadyHasActiveApplicationWithSameLicenseClass(this.ApplicantPersonID,(int)this.LicenseClass,-1))
            {
                errorMessage = "Applicant already has an active application with the same license class.";
                clsApplicationDataAccess.Delete(this.ApplicationID);
                return false;
            }

            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationDataAccess.Insert
                (
                    this.ApplicationID,(int)this.LicenseClass
                );
                
            if(this.LocalDrivingLicenseApplicationID != -1)
            {
                this._Mode = enMode.Edit;
            }
            return this.LocalDrivingLicenseApplicationID != -1;
        }

        private bool _EditLocalApplication(out string errorMessage)
        {
            errorMessage = string.Empty;
            if (clsLocalDrivingLicenseApplicationDataAccess.IsApplicantAlreadyHasActiveApplicationWithSameLicenseClass(this.ApplicantPersonID, (int)this.LicenseClass, this.LocalDrivingLicenseApplicationID))
            {
                errorMessage = "Applicant already has an active application with the same license class.";
                return false;
            }

            bool isUpdated = clsLocalDrivingLicenseApplicationDataAccess.Update(this.LocalDrivingLicenseApplicationID, (int)this.LicenseClass);
            return isUpdated;
        }
        public bool Save(out string errorMessage)
        {
            if (!base.Save(out errorMessage))
            {
                return false;
            }

                switch (this._Mode)
            {
                case enMode.AddNew:
                    return _AddNewLocalApplication(out errorMessage);
                case enMode.Edit:
                    return _EditLocalApplication(out errorMessage);
            }

            return false;
        }

        public static DataTable GetAllLocalApplications()
        {
            return clsLocalDrivingLicenseApplicationDataAccess.GetAllApplications();
        }
        public static clsLocalDrivingLicenseApplication FindByID(int localDrivingLicenseApplicationId)
        {
            int applicationId, licenseClassId, applicantPersonId, applicationTypeId, applicationStatusId, createdByUserId, licenseId;
            DateTime applicationDate, lastStatusDate;
            decimal paidFees;
            int passedTests;
            bool isFound  =  clsLocalDrivingLicenseApplicationDataAccess.GetByID
                (
                    localDrivingLicenseApplicationId,out applicationId, out licenseClassId,
                    out applicantPersonId,out applicationDate,out applicationTypeId,out applicationStatusId,
                    out lastStatusDate,out paidFees,out createdByUserId,out passedTests,out licenseId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsLocalDrivingLicenseApplication
                (
                applicationId,(enApplicationStatus)applicationStatusId, paidFees,(enApplicationType) applicationTypeId, applicantPersonId, applicationDate, lastStatusDate, createdByUserId, localDrivingLicenseApplicationId,(enLicenseClass) licenseClassId, passedTests, licenseId
                );
        }

        
    }
}
