using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsDetainedLicense
    {
        private enum enMode
        {
            AddNew,
            Edit
        }
        private enMode _Mode;
        public int DetainID { get; private set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get;set; }
        public bool IsReleased { get; set; }

        public Nullable<DateTime>ReleaseDate { get; set; }
        public Nullable<int> ReleasedByUserID { get; set; }
        public Nullable<int> ReleaseApplicationID { get;set; }


        public string GetCreatedByUsername
        {
            get
            {
                return clsUserDataAccess.GetUsernameByID(this.CreatedByUserID);
            }
        }
        public string GetReleasedByUsername
        {
            get
            {
                if (this.ReleasedByUserID.HasValue)
                {
                    return clsUserDataAccess.GetUsernameByID(this.ReleasedByUserID??-1);
                }
                return null;
            }
        }
        public clsDetainedLicense()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Today;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
            _Mode = enMode.AddNew;
        }
        public clsDetainedLicense(int detainID, int licenseID, DateTime detainDate, decimal fineFees, int createdByUserID, bool isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            _Mode = enMode.Edit;
        }


        public static clsDetainedLicense FindByID(int detainId)
        {
            int licenseId, createdByUserId;
            int? releasedByUserId, releaseApplicationId;

            DateTime detainDate;
            DateTime? releaseDate;

            decimal fineFees;
            bool isReleased;

            bool isFound = clsDetainedLicenseDataAccess.GetByID
                (
                    detainId,out licenseId,out detainDate,
                    out fineFees,out createdByUserId,out isReleased,
                    out releaseDate,out releasedByUserId,out releaseApplicationId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsDetainedLicense
                (
                    detainId,licenseId,detainDate,fineFees,
                    createdByUserId,isReleased, releaseDate,
                    releasedByUserId,releaseApplicationId
                );
        }

        public static clsDetainedLicense GetLastDetainedPerLicenseID(int licenseId)
        {
            int detainId, createdByUserId;
            int? releasedByUserId, releaseApplicationId;

            DateTime detainDate;
            DateTime? releaseDate;

            decimal fineFees;
            bool isReleased;

            bool isFound = clsDetainedLicenseDataAccess.GetLastDetainPerLicenseID
                (
                    licenseId, out detainId, out detainDate,
                    out fineFees, out createdByUserId, out isReleased,
                    out releaseDate, out releasedByUserId, out releaseApplicationId
                );

            if (!isFound)
            {
                return null;
            }

            return new clsDetainedLicense
                (
                    detainId, licenseId, detainDate, fineFees,
                    createdByUserId, isReleased, releaseDate,
                    releasedByUserId, releaseApplicationId
                );
        }



        private bool _AddNew(out string errorMessage)
        {
            errorMessage = string.Empty;

            clsDetainedLicense LastLicenseDetain = GetLastDetainedPerLicenseID(this.LicenseID);

            if(LastLicenseDetain != null)
            {
                if ( ! LastLicenseDetain.IsReleased)
                {
                    errorMessage = $"License With ID {this.LicenseID} Already Detained";
                    return false;
                }
            }

            this.DetainID = clsDetainedLicenseDataAccess.Insert
                (
                    this.LicenseID,DateTime.Now,this.FineFees,
                    this.CreatedByUserID,false,null,
                    null,null
                );

            if(this.DetainID != -1)
            {
                this._Mode = enMode.Edit;
            }

            return this.DetainID != -1;
        }

        private bool _Edit(out string errorMessage)
        {
            errorMessage = string.Empty;
            bool isUpdated = clsDetainedLicenseDataAccess.Update
                (
                    this.DetainID,this.LicenseID,this.DetainDate,
                    this.FineFees,this.CreatedByUserID,this.IsReleased,
                    this.ReleaseDate,this.ReleasedByUserID,this.ReleaseApplicationID
                );

            return isUpdated;
        }
        public bool Save(out string errorMessage)
        {
            errorMessage = string.Empty;

            if(this.LicenseID == -1)
            {
                errorMessage = "License Is Required";
                return false;
            }
            if(this.CreatedByUserID == -1)
            {
                errorMessage = "User Must Detain The License";
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
    }
}
