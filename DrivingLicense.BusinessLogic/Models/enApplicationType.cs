using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.BusinessLogic.Models
{
    public enum enApplicationType
    {
        None = 0,
        NewLocalDrivingLicenseService =1,
        RenewDrivingLicenseService=2,
        ReplacementForALostDrivingLicense=3,
        ReplacementForADamagedDrivingLicense=4,
        ReleaseDetainedDrivingLicsense=5,
        NewInternationalLicense=6,
        RetakeTest= 7
    }
}
