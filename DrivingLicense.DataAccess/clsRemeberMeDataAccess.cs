using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsRemeberMeDataAccess
    {
        public static bool Save(string username, string password)
        {
            try
            {
                string directory = Path.GetDirectoryName(clsSettings.rememberMeStoragePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string[] dataToSave = { username, password };
                File.WriteAllLines(clsSettings.rememberMeStoragePath, dataToSave, Encoding.UTF8);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Delete()
        {
            try
            {
                if (File.Exists(clsSettings.rememberMeStoragePath))
                {
                    File.Delete(clsSettings.rememberMeStoragePath);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool GetStoredCredentials(out string username, out string password)
        {
            username = string.Empty;
            password = string.Empty;

            try
            {
                if (File.Exists(clsSettings.rememberMeStoragePath))
                {
                    string[] lines = File.ReadAllLines(clsSettings.rememberMeStoragePath);
                    if (lines.Length >= 2)
                    {
                        username = lines[0];
                        password = lines[1];
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
