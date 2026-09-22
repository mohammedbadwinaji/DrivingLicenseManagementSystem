using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Applications
{
    public class clsRenewLocalLicenseApplication : clsApplication
    {
        internal clsRenewLocalLicenseApplication() : base()
        {
            this.ApplicationType = Models.enApplicationType.RenewDrivingLicenseService;
            this.ApplicationStatus = Models.enApplicationStatus.New;
            this._Mode = enMode.AddNew;
        }

        private clsRenewLocalLicenseApplication(int applicationID, enApplicationStatus applicationStatus, decimal paidFees, enApplicationType applicationType, int applicantPersonID, DateTime applicationDate, DateTime lastStatusDate, int createdByUserID) : base(applicationID, applicationStatus, paidFees, applicationType, applicantPersonID, applicationDate, lastStatusDate, createdByUserID)
        {
            this._Mode = enMode.Edit;
        }

        public static clsRenewLocalLicenseApplication FindByID(int renewLicenseApplicationId)
        {
            int applicantPersonId, applicationTypeId, applicationStatusId, createdByUserId;
            DateTime applicationDate, lastStatusDate;
            decimal paidFees;
            bool isFound = clsApplicationDataAccess.GetByID
                (
                    renewLicenseApplicationId, out applicantPersonId, out applicationDate,
                    out applicationTypeId, out applicationStatusId, out lastStatusDate,
                    out paidFees, out createdByUserId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsRenewLocalLicenseApplication
                (
                    renewLicenseApplicationId,(enApplicationStatus)applicationStatusId,paidFees,
                    (enApplicationType)applicationTypeId,applicantPersonId,applicationDate,
                    lastStatusDate,createdByUserId
                );
        }


        internal bool AddNewApplication(out string errorMessage)
        {
            errorMessage = string.Empty;
            if(this.ApplicantPersonID == -1)
            {
                errorMessage = "Cannot Create Application Without Applicant";
                return false;
            }
            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Create This Application";
                return false;
            }

            this.ApplicationID =  clsApplicationDataAccess.Insert
                (
                this.ApplicantPersonID, this.ApplicationDate, (int)enApplicationType.RenewDrivingLicenseService,
                (int)this.ApplicationStatus, this.LastStatusDate, this.PaidFees,
                this.CreatedByUserID
                );

            if(this.ApplicationID != -1)
            {
                this._Mode = enMode.Edit;
            }

            return this.ApplicationID != -1;
        }
    }
}
