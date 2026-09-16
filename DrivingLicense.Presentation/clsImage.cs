using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.Presentation
{
    internal class clsImage
    {
        public static string MaleImagePath = $@"{clsSettings.storageDirectory}\Male 512.png";
        public static string FemaleImagePath = $@"{clsSettings.storageDirectory}\Female 512.png";
        public static string VisionTestImagePath = $@"{clsSettings.storageDirectory}\Vision 512.png";
        public static string WrittenTestImagePath = $@"{clsSettings.storageDirectory}\Written Test 512.png";
        public static string StreetTestImagePath = $@"{clsSettings.storageDirectory}\driving-test 512.png";
    }
}
