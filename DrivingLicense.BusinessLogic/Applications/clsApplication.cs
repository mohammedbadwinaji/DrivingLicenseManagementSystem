using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.BusinessLogic.Models;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic.Applications
{
    public abstract class clsApplication
    {
        protected enum enMode
        {
            AddNew,
            Edit
        }

        protected enMode _Mode;
        public int ApplicationID { get; protected set; }
        public enApplicationStatus ApplicationStatus { get; protected set; }
        public decimal PaidFees { get; set; }
        public enApplicationType ApplicationType { get; protected set; }
        public int ApplicantPersonID { get;  set; }
        public DateTime ApplicationDate { get; protected set; }
        public DateTime LastStatusDate { get; protected set; }    
        public int CreatedByUserID {  get; set; }

        public string GetApplicantFullName
        {
            get
            {
                return clsPersonDataAccess.GetFullNameByID(this.ApplicantPersonID);
            }
        }

        public string GetCreatedByUserName
        {
            get
            {
                return clsUserDataAccess.GetUsernameByID(this.CreatedByUserID);
            }
        }

        protected clsApplication() 
        {
            this.ApplicationID = -1;
            this.ApplicationDate = DateTime.Today;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Today;
            this.PaidFees = 0;
            this.ApplicationType = enApplicationType.None;
            this.CreatedByUserID = -1;
            this.ApplicantPersonID = -1;
        }
        protected clsApplication
            ( 
            int applicationID, enApplicationStatus applicationStatus,
            decimal paidFees, enApplicationType applicationType,
            int applicantPersonID, DateTime applicationDate, 
            DateTime lastStatusDate, int createdByUserID
            )
        {
            ApplicationID = applicationID;
            ApplicationStatus = applicationStatus;
            PaidFees = paidFees;
            ApplicationType = applicationType;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            LastStatusDate = lastStatusDate;
            CreatedByUserID = createdByUserID;
        }

        private bool _AddNewApplication(out string errorMessage)
        {
            errorMessage = string.Empty;
            this.ApplicationID =  clsApplicationDataAccess.Insert
                (
                    this.ApplicantPersonID,this.ApplicationDate,(int)this.ApplicationType,
                    (int)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, 
                    this.CreatedByUserID
                );
            return this.ApplicationID != -1;
        }
        private bool _EditApplication(out string errorMessage)
        {
            errorMessage = string.Empty;

            return clsApplicationDataAccess.Update
                (
                    ApplicationID, (int)this.ApplicationStatus
                );
        }

        public virtual bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(this.ApplicantPersonID == -1)
            {
                errorMessage = "You Must Person To Like With Application";
                return false;
            }
            if(this.ApplicationType == enApplicationType.None)
            {
                errorMessage = "You Must Choose Application Type";
                return false;
            }
            if(this.PaidFees < clsApplicationTypeDataAccess.GetApplicationTypeFeesByID((int)this.ApplicationType))
            {
                errorMessage = "You Must Pay All Fees";
                return false;
            }
            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Create/Edit This Application";
                return false;
            }

            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNewApplication(out errorMessage);
                case enMode.Edit:
                    return _EditApplication(out errorMessage);
            }
            return false;
        }

        public static bool ChangeStatus(int applicationId,enApplicationStatus newStatus)
        {
            return clsApplicationDataAccess.Update(applicationId, (int)newStatus);
        }
    }
}
