using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    internal class clsApplicationDataAccess
    {
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT *
                                FROM Applications
                            ";

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
                int applicationId , out int applicantPersonId,out DateTime applicationDate,
                out int applicationTypeId ,out int applicationStatusId ,out DateTime lastStatusDate,
                out decimal paidFees , out int createdByUserId
            )
        {
            bool isFound = false;
            applicantPersonId = applicationTypeId = applicationStatusId = createdByUserId = -1;
            applicationDate = lastStatusDate = DateTime.MinValue;
            paidFees = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT * 
                                FROM Applications 
                                WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    applicantPersonId = (int)reader["ApplicantPersonID"];
                    applicationDate = (DateTime)reader["ApplicationDate"];
                    applicationTypeId = (int)reader["ApplicationTypeID"];
                    applicationStatusId = (int)reader["ApplicationStatusID"];
                    lastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    createdByUserId = (int)reader["CreatedByUserID"];
                }

                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return isFound;
        }
        public static int Insert(
                int applicantPersonId,DateTime applicationDate,int applicationTypeId,
                int applicationStatusId,DateTime lastStatusDate,decimal paidFees,
                int createdByUserId
            )
        {
            int insertedApplicationId = -1;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO Applications
                            (
                                ApplicantPersonID, ApplicationDate, ApplicationTypeID, 
                                ApplicationStatusID, LastStatusDate, PaidFees, 
                                CreatedByUserID
                            )
                            VALUES
                            (
                                @ApplicantPersonID, @ApplicationDate, @ApplicationTypeID,
                                @ApplicationStatusID, @LastStatusDate, @PaidFees, 
                                @CreatedByUserID
                            );
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonId);
            command.Parameters.AddWithValue("@ApplicationDate", applicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeId);
            command.Parameters.AddWithValue("@ApplicationStatusID", applicationStatusId);
            command.Parameters.AddWithValue("@LastStatusDate", lastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    insertedApplicationId = id;
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return insertedApplicationId;
        }

        public static bool Update
            (
                int applicationId,int applicationStatusId
            )
        {
            int affectedRows = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   UPDATE Applications
                                SET ApplicationStatusID = @ApplicationStatusID
                                WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationStatusID", applicationStatusId);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);

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

        public static bool Delete(int applicationId)
        {
            int affectedRows = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   DELETE FROM Applications
                                WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);

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
