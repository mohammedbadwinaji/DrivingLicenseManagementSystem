using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsLicenseClassDataAccess
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"   SELECT *
                                FROM LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return dt;
        }

        public static bool GetByID
            (
                int licenseClassId,out string className, out string classDescription,
                out byte minimumAllowedAge ,out byte defaultValidityLength,out decimal classFess
            )
        {
            bool isFound = false;

            className = classDescription = string.Empty;
            minimumAllowedAge = defaultValidityLength = 0;
            classFess = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT *
                                FROM LicenseClasses L
                                WHERE L.LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    className = (string)reader["ClassName"];
                    classDescription = (string)reader["ClassDescription"];
                    minimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    defaultValidityLength = (byte)reader["DefaultValidityLength"];
                    classFess = (decimal)reader["ClassFees"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return isFound;
        }


        public static bool Update
            (
                int licenseClassId , decimal classFees
            )
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   UPDATE LicenseClasses
                                SET ClassFees = @ClassFees
                                WHERE LicenseClassID = @LicenseClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassFees", classFees);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassId);
            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return affectedRows > 0;
        }


        
    }
}
