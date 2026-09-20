using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsInternationalLicenseDataAccess
    {
        public static DataTable GetPersonLicenses(int personId)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT	IL.InternationalLicenseID,
		                            IL.ApplicationID,
		                            IL.IssuedUsingLocalLicenseID,
		                            IL.IssueDate,
		                            IL.ExpirationDate,
		                            IL.IsActive
                            FROM InternationalLicenses IL
                            INNER JOIN Drivers D
                            ON IL.DriverID = D.DriverID
                            WHERE D.PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
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
    }
}
