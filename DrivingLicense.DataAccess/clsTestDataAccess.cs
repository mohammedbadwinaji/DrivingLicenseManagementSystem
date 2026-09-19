using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsTestDataAccess
    {
        public static bool GetByID
            (   
                int testId,out int testAppointmentId,out bool testResult,out string notes,out int createdByUserId
            )
        {
            bool isFound = false;
            testAppointmentId = createdByUserId = -1;
            testResult = false;
            notes = string.Empty;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT *
                            FROM Tests T
                            WHERE T.TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", testId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    testAppointmentId = (int)reader["TestAppointmentID"];
                    createdByUserId = (int)reader["CreatedByUserID"];
                    testResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == null || reader["Notes"] == DBNull.Value)
                    {
                        notes = string.Empty;
                    }
                    else
                    {
                        notes =(string) reader["Notes"];
                    }
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

        public static int GetTestCount
            (
                int localDrivingLicenseApplicationid,int testTypeId
            )
        {
            int trials = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT COUNT(T.TestID) as Trails
                                FROM TestAppointments TA
                                LEFT JOIN Tests T
                                ON TA.TestAppointmentID = T.TestAppointmentID
                                WHERE	TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
		                                AND
		                                TA.TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationid);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    trials  = (int)result;
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }


            return trials;
        }

        public static int Insert
            (
                int testAppointmentId,bool testResult,string notes,int createdByUserId
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"INSERT INTO Tests
                               (
		                       TestAppointmentID
                               ,TestResult
                               ,Notes
                               ,CreatedByUserID
		                       )
                         VALUES
                               (
		                       @TestAppointmentID
                               ,@TestResult
                               ,@Notes
                               ,@CreatedByUserID
		                       );
                        SELECT SCOPE_IDENTITY()";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentId);
            command.Parameters.AddWithValue("@TestResult", testResult);
            if (!string.IsNullOrEmpty(notes)) { 
                command.Parameters.AddWithValue("@Notes", notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
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
