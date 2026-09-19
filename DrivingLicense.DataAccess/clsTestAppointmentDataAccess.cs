using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsTestAppointmentDataAccess
    {

        public static DataTable GetAllLocalAppsAppointmentsPerTestType
            (
                int localDrivingLicenseApplicationId,int testTypeId
            )
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	TA.TestAppointmentID,
		                            TA.AppointmentDate,
		                            TA.PaidFees,
		                            TA.IsLocked
                            FROM TestAppointments TA
                            WHERE	TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                    AND
		                            TA.TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);

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

       

        public static bool GetLastLocalAppAppointmentPerTestType(
                int localDrivingLicenseApplicaationId, int testTypeId,out int testAppointmentId,
                out DateTime appointmentDate, out decimal paidFees, out int createdByUserId,
                out bool isLocked, out int retakeTestApplicationId, out int testId
            )
        {
            bool isFound = false;
            testAppointmentId = createdByUserId = retakeTestApplicationId = testId = -1;
            appointmentDate = DateTime.Today;
            paidFees = 0;
            isLocked = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	TOP 1
		                            TA.TestAppointmentID,
		                            TA.TestTypeID,
		                            TA.LocalDrivingLicenseApplicationID,
		                            TA.AppointmentDate,
		                            TA.PaidFees,
		                            TA.CreatedByUserID,
		                            TA.IsLocked,
		                            (
			                            CASE 
				                            WHEN TA.RetakeTestApplicationID IS NULL THEN -1
				                            ELSE TA.RetakeTestApplicationID
			                            END
		                            ) as RetakeTestApplicationID,
		                            (
			                            CASE
				                            WHEN T.TestID IS NULL THEN -1
				                            ELSE T.TestID
			                            END
		                            ) as TestID
                            FROM TestAppointments TA
                            LEFT JOIN Tests T
                            ON TA.TestAppointmentID = T.TestAppointmentID
                            WHERE	TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
		                            AND
		                            TA.TestTypeID = @TestTypeID
                            ORDER BY TA.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicaationId);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    testAppointmentId = (int)reader["TestAppointmentID"];
                    appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    paidFees = Convert.ToDecimal(reader["PaidFees"]);
                    createdByUserId = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];
                    retakeTestApplicationId = (int)reader["RetakeTestApplicationID"];
                    testId = (int)reader["TestID"];
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

        public static bool GetByID
           (
               int testAppointmentId, out int localDrivingLicenseApplicaationId, out int testTypeId,
               out DateTime appointmentDate, out decimal paidFees, out int createdByUserId,
               out bool isLocked, out int retakeTestApplicationId, out int testId
           )
        {
            bool isFound = false;
            localDrivingLicenseApplicaationId = testTypeId = createdByUserId = retakeTestApplicationId = testId = -1;
            appointmentDate = DateTime.Today;
            paidFees = 0;
            isLocked = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	TA.TestAppointmentID,
		                            TA.TestTypeID,
		                            TA.LocalDrivingLicenseApplicationID,
		                            TA.AppointmentDate,
		                            TA.PaidFees,
		                            TA.CreatedByUserID,
		                            TA.IsLocked,
		                            (
			                            CASE 
				                            WHEN TA.RetakeTestApplicationID IS NULL THEN -1
				                            ELSE TA.RetakeTestApplicationID
			                            END
		                            ) as RetakeTestApplicationID,
		                            (
			                            CASE
				                            WHEN T.TestID IS NULL THEN -1
				                            ELSE T.TestID
			                            END
		                            ) as TestID

                            FROM TestAppointments TA
                            LEFT JOIN Tests T
                            ON TA.TestAppointmentID = T.TestAppointmentID
                            WHERE	TA.TestAppointmentID= @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    localDrivingLicenseApplicaationId = (int)reader["LocalDrivingLicenseApplicationID"];
                    testTypeId = (int)reader["TestTypeID"];
                    appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    paidFees = Convert.ToDecimal(reader["PaidFees"]);
                    createdByUserId = (int)reader["CreatedByUserID"];
                    isLocked = (bool)reader["IsLocked"];
                    retakeTestApplicationId = (int)reader["RetakeTestApplicationID"];
                    testId = (int)reader["TestID"];
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

        public static int Insert
            (
                int testTypeId, int localDrivingLicenseApplicationId,
                DateTime appointmentDate, decimal paidFees,
                int createdByUserId, bool isLocked, int retakeTestApplicationId
            )
        {
            int insertedId = -1;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO TestAppointments
                                       (
		                               TestTypeID
                                       ,LocalDrivingLicenseApplicationID
                                       ,AppointmentDate
                                       ,PaidFees
                                       ,CreatedByUserID
                                       ,IsLocked
                                       ,RetakeTestApplicationID
		                               )
                                 VALUES
                                       (
		                               @TestTypeID
                                       ,@LocalDrivingLicenseApplicationID
                                       ,@AppointmentDate
                                       ,@PaidFees
                                       ,@CreatedByUserID
                                       ,@IsLocked
                                       ,@RetakeTestApplicationID
		                               );
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);
            command.Parameters.AddWithValue("@IsLocked", isLocked);
            if(retakeTestApplicationId == -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", retakeTestApplicationId);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
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

        public static bool Update
            (
                int testAppointmentId,DateTime appointmentDate,bool isLocked
            )
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   UPDATE TestAppointments
                                SET  AppointmentDate = @Date,
                                     IsLocked = @IsLocked
                                WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentId);
            command.Parameters.AddWithValue("@Date", appointmentDate);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                command.Clone();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return affectedRows > 0;
        }

        public static bool UpdateIsLocked(int testAppointmentId , bool isLocked)
        {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   UPDATE TestAppointments
                                SET  IsLocked = @IsLocked
                                WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentId);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
                command.Clone();
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
