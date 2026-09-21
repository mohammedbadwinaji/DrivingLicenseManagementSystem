using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Licenses;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Applications
{
    public class clsInternationalLicenseApplication : clsApplication
    {

        public clsInternationalLicenseApplication() : base()
        {
            this.ApplicationType = Models.enApplicationType.NewInternationalLicense;
            this.ApplicationStatus = Models.enApplicationStatus.New;
            _Mode = enMode.AddNew;
        }

        private clsInternationalLicenseApplication
            (
                int applicationID, enApplicationStatus applicationStatus, 
                decimal paidFees, enApplicationType applicationType, 
                int applicantPersonID, DateTime applicationDate, DateTime lastStatusDate,
                int createdByUserID
            ) : base(applicationID, applicationStatus, paidFees, applicationType, applicantPersonID, applicationDate, lastStatusDate, createdByUserID
            )
        {
            this._Mode = enMode
                .Edit;
        }


        public static DataTable GetAllApplications()
        {
            return clsInternationalLicenseApplicationDataAccess.GetAllApplications();
        }

        public static clsInternationalLicenseApplication FindByID(int internationalLicenseId)
        {
            int applicantPersonId, applicationTypeId, applicationStatusId, createdByUserId;
            DateTime applicationDate, lastStatusDate;
            decimal paidFees;
            bool isFound = clsApplicationDataAccess.GetByID
                (
                internationalLicenseId,out applicantPersonId,out applicationDate,
                out applicationTypeId,out applicationStatusId,out lastStatusDate,
                out paidFees,out createdByUserId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsInternationalLicenseApplication
                (   
                internationalLicenseId,(enApplicationStatus)applicationStatusId,paidFees,
                (enApplicationType)applicationTypeId,applicantPersonId,applicationDate,
                lastStatusDate,createdByUserId
                );
        }

        
        private bool _AddNewInternationalLicenseApplication(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(this.ApplicantPersonID == -1)
            {
                errorMessage = "Person Must Applied For This Application";
                return false;
            }

            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Add This Application";
                return false;
            }
            decimal applicationFees = clsApplicationType.GetFees(enApplicationType.NewInternationalLicense);
            if(this.PaidFees < applicationFees)
            {
                errorMessage = $"Person Must Pay All Fees {applicationFees}";
                return false;
            }


            DataTable personLicenses = clsLicense.GetPersonLicneses(this.ApplicantPersonID);
            bool isPersonHasLocalLicenseWithClass3 = false;
            bool isPersonLocalLicenseActive = false;
            bool isPersonLocalLicenseHasValidity = false;
            
            foreach(  DataRow row in personLicenses.Rows)
            {
                if (
                    (int)row["LicenseClass"] == (int)enLicenseClass.Class3)
                {
                    isPersonHasLocalLicenseWithClass3 = true;
                    if ((bool)row["IsActive"] == true)
                    {
                        isPersonLocalLicenseActive = true;
                    }
                    if ((DateTime)row["ExpirationDate"] >= DateTime.Today)
                    {
                        isPersonLocalLicenseHasValidity = true;
                    }
                }
                
            }

            if (!isPersonHasLocalLicenseWithClass3)
            {
                errorMessage = "Person Doesn't Has Local License With Class 3";
                return false;
            }
            if (!isPersonLocalLicenseActive)
            {
                errorMessage = "Person Local License Doesn't Active";
                return false;
            }
            if (!isPersonLocalLicenseHasValidity)
            {
                errorMessage = "Person Local License have been expired";
                return false;
            }


            DataTable personInternationalLicenses = clsInternationalLicenseDataAccess.GetPersonLicenses(this.ApplicantPersonID);

            foreach(DataRow row in personInternationalLicenses.Rows)
            {
                if ((bool)row["IsActive"] == true)
                {
                    errorMessage = $"Person Already Has An Active International License With ID {row["InternationalLicenseID"]}";
                    return false;
                }
            }


            this.ApplicationID = clsApplicationDataAccess.Insert
                (
                    this.ApplicantPersonID,this.ApplicationDate,(int)enApplicationType.NewInternationalLicense,
                    (int)enApplicationStatus.New,this.LastStatusDate,this.PaidFees,
                    this.CreatedByUserID
                );

            if(this.ApplicationID != -1)
            {
                this._Mode = enMode.Edit;
            }

            return this.ApplicationID != -1;
        }
        private bool _EditInternationalLicenseApplication(out string errorMessage)
        {
            errorMessage = string.Empty;

            clsInternationalLicenseApplication currentApp = FindByID(this.ApplicationID);

            if(currentApp.ApplicationStatus == enApplicationStatus.Completed ||
                currentApp.ApplicationStatus == enApplicationStatus.Canceled)
            {
                errorMessage = $"Cannot Update {currentApp.ApplicationStatus.ToString()} Application";
                return false;
            }

            bool isUpdated = clsApplicationDataAccess.Update(this.ApplicationID, (int)this.ApplicationStatus);

            return isUpdated;
        }
        public bool Add(out string errorMessage)
        {
            errorMessage = string.Empty;
            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNewInternationalLicenseApplication(out errorMessage);
                case enMode.Edit:
                    return _EditInternationalLicenseApplication(out errorMessage);
                   
            }

            return false;
        }
    }
}

