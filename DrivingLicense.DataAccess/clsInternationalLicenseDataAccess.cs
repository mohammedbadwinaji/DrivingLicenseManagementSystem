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

        public static bool GetByID
            (
                int internationalLicenseId,out int applicationId,out int driverId,
                out int issuedUsingLicenseId,out DateTime issueDate,out DateTime expirationDate,
                out bool isActive , out int createdByUserId
            )
        {
            bool isFound = false;
            applicationId = driverId = issuedUsingLicenseId = createdByUserId = -1;
            issueDate = expirationDate = DateTime.Today;
            isActive = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                            FROM InternationalLicenses IL
                            WHERE IL.InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseId);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    applicationId = Convert.ToInt32(reader["ApplicationID"]);
                    driverId = Convert.ToInt32(reader["DriverID"]);
                    issuedUsingLicenseId = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);

                    issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                    isActive = Convert.ToBoolean(reader["IsActive"]);
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

        public static bool GetByLocalLicenseId(

            int issuedUsingLicenseId, out int internationalLicenseId, out int applicationId,
            out int driverId, out DateTime issueDate, out DateTime expirationDate,
            out bool isActive, out int createdByUserId
        )
        {
            bool isFound = false;
            applicationId = driverId = internationalLicenseId = createdByUserId = -1;
            issueDate = expirationDate = DateTime.Today;
            isActive = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                            FROM InternationalLicenses IL
                            WHERE IL.IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLicenseId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    internationalLicenseId = Convert.ToInt32(reader["InternationalLicenseID"]);
                    applicationId = Convert.ToInt32(reader["ApplicationID"]);
                    driverId = Convert.ToInt32(reader["DriverID"]);
                    createdByUserId = Convert.ToInt32(reader["CreatedByUserID"]);

                    issueDate = Convert.ToDateTime(reader["IssueDate"]);
                    expirationDate = Convert.ToDateTime(reader["ExpirationDate"]);

                    isActive = Convert.ToBoolean(reader["IsActive"]);
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

       

        public static int Insert
            (
                int applicationId,int driverId,int localLicenseId,
                int createdByUserId
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query  = @"INSERT INTO InternationalLicenses
                            (
		                    ApplicationID
                            ,DriverID
                            ,IssuedUsingLocalLicenseID
                            ,IssueDate
                            ,ExpirationDate
                            ,IsActive
                            ,CreatedByUserID
		                    )
                        VALUES
                            (
		                    @ApplicationID
                            ,@DriverID
                            ,@IssuedUsingLocalLicenseID
                            ,GETDATE()
                            ,DATEADD(YEAR,1, GETDATE())
                            ,1
                            ,@CreatedByUserID
		                    );
                            SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            command.Parameters.AddWithValue("@DriverID", driverId);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", localLicenseId);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    insertedId = Convert.ToInt32(result);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return insertedId;
        }
    }
}
