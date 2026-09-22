using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Applications
{
    internal class clsReplacementForDamageApplication : clsApplication
    {
        public clsReplacementForDamageApplication() : base() 
        {
            this.ApplicationType = Models.enApplicationType.ReplacementForADamagedDrivingLicense;
            this._Mode = enMode.AddNew;
        }

        public clsReplacementForDamageApplication(int applicationID, enApplicationStatus applicationStatus, decimal paidFees, enApplicationType applicationType, int applicantPersonID, DateTime applicationDate, DateTime lastStatusDate, int createdByUserID) : base(applicationID, applicationStatus, paidFees, applicationType, applicantPersonID, applicationDate, lastStatusDate, createdByUserID)
        {
            this._Mode = enMode.Edit;
        }


        public static clsReplacementForDamageApplication FindByID(int replacementForDamageApplicationId)
        {
            int applicantPersonId, applicationTypeId, applicationStatusId, createdByUserId;
            DateTime applicationDate, lastStatusDate;
            decimal paidFees;
            bool isFound = clsApplicationDataAccess.GetByID
                (
                    replacementForDamageApplicationId,out applicantPersonId,out applicationDate,
                    out applicationTypeId,out applicationStatusId,out lastStatusDate,
                    out paidFees,out createdByUserId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsReplacementForDamageApplication
                (
                    replacementForDamageApplicationId,(enApplicationStatus)applicationStatusId,paidFees,
                    (enApplicationType)applicationTypeId,applicantPersonId,applicationDate,
                    lastStatusDate,createdByUserId
                );
        }

        internal bool AddNewApplication(out string errorMessage)
        {
            errorMessage = string.Empty;
            if (this.ApplicantPersonID == -1)
            {
                errorMessage = "Cannot Create Application Without Applicant";
                return false;
            }
            if (this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Create This Application";
                return false;
            }

            this.ApplicationID = clsApplicationDataAccess.Insert
                (
                this.ApplicantPersonID, this.ApplicationDate, (int)enApplicationType.ReplacementForADamagedDrivingLicense,
                (int)this.ApplicationStatus, this.LastStatusDate, this.PaidFees,
                this.CreatedByUserID
                );

            if (this.ApplicationID != -1)
            {
                this._Mode = enMode.Edit;
            }

            return this.ApplicationID != -1;
        }
    }
}
