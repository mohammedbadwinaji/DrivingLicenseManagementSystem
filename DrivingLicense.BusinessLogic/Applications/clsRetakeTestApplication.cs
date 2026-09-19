using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Applications
{
    public class clsRetakeTestApplication  : clsApplication
    {

        public clsRetakeTestApplication() :base()
        {
            this.ApplicationType = Models.enApplicationType.RetakeTest;
            this.ApplicationStatus = Models.enApplicationStatus.Completed;
            this._Mode = enMode.AddNew;
        }
        public clsRetakeTestApplication(
            int applicationID, enApplicationStatus applicationStatus,
            decimal paidFees, enApplicationType applicationType,
            int applicantPersonID, DateTime applicationDate,
            DateTime lastStatusDate, int createdByUserID
            ) :base(applicationID, applicationStatus, paidFees, applicationType, applicantPersonID, applicationDate, lastStatusDate, createdByUserID)
        {
            this._Mode = enMode.Edit;
        }
        public static clsRetakeTestApplication FindByID(int retakeTestApplicationId)
        {
            int applicantPersonId, applicationTypeId, applicationStatusId, createdByUserId;
            decimal paidFees;
            DateTime applicationDate, lastStatusDate;
            bool isFound = clsApplicationDataAccess.GetByID
                (
                    retakeTestApplicationId,out applicantPersonId,out applicationDate,
                    out applicationTypeId ,out applicationStatusId,out lastStatusDate,
                    out paidFees, out createdByUserId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsRetakeTestApplication
                (
                    retakeTestApplicationId,(enApplicationStatus) applicationStatusId,paidFees,
                    (enApplicationType)applicationTypeId,applicantPersonId,applicationDate,
                    lastStatusDate,createdByUserId
                );
        }

        private bool _AddNewRetakeTestApplication(out string errorMessage)
        {

            errorMessage = string.Empty;
            this.ApplicationID =  clsApplicationDataAccess.Insert
                (
                    this.ApplicantPersonID,this.ApplicationDate,(int)this.ApplicationType,(int)this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID
                );
            if(this.ApplicationID != -1)
            {
                this._Mode = enMode.Edit;
            }

            return this.ApplicationID != -1;
        }
        private bool _EditNewRetakeTestApplication(out string errorMessage)
        {
            errorMessage = string.Empty;

            bool isUpdated = clsApplicationDataAccess.Update(this.ApplicationID, (int)this.ApplicationStatus);

            return isUpdated;
        }
        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(this.ApplicantPersonID == -1)
            {
                errorMessage = "Retake Test Must Be From Person";
                return false;
            }

            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Add / Edit Retake Test Application"; 
                return false;
            }

            if(this.PaidFees < clsApplicationType.GetFees(Models.enApplicationType.RetakeTest))
            {
                errorMessage = "Applicant Must Paidf All Fees To Retake Test";
                return false;
            }

            switch (this._Mode)
            {
                case enMode.AddNew:
                    return _AddNewRetakeTestApplication(out errorMessage);
                case enMode.Edit:
                    return _EditNewRetakeTestApplication(out errorMessage);
            }
            return false;
        }
    }
}
