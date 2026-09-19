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
        public static DataTable GetAllAppointmentsByLocalDrivingLicenseApplicationAndTestType
            (
                int localDrivingLicenseApplicationId,
                int testTypeId
            )
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	TA.TestAppointmentID,
		                            TA.AppointmentDate,
		                            TA.PaidFees,
		                            TA.IsLocked
                            FROM LocalDrivingLicenseApplications LDLA
                            INNER JOIN Applications A
                            ON LDLA.ApplicationID = A.ApplicationID
                            INNER JOIN TestAppointments TA
                            ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                            WHERE       LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                    AND TA.TestTypeID = @TestTypeID";

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

        public static bool GetByID
    (
                int testAppointmentId,out int localDrivingLicenseApplicaationId,out int testTypeId,
        out int testTypeId, out string testTypeTitle,out string licenseClassName, out string fullName, out int trail,
        out DateTime appointmentDate, out decimal paidFees, out int testId,
        out int createdByUserId,out string createdByUsername,out bool isLocked
    )
        {
            bool isFound = false;
            localDrivingLicenseApplicationId = -1;
            licenseClassId = -1;
            licenseClassName = "";
            fullName = "";
            trail = 0;
            appointmentDate = DateTime.Now;
            paidFees = 0;
            testId = -1;
            testTypeId = -1;
            testTypeTitle= string.Empty;
            createdByUserId = -1;
            createdByUsername= string.Empty;
            isLocked = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	TA.LocalDrivingLicenseApplicationID,
		                            LC.LicenseClassID,
		                            LC.ClassName,
		                            TT.TestTypeID,
		                            TT.TestTypeTitle,
		                            (
			                            P.FirstName + ' ' +
			                            P.SecondName + ' ' +
			                            ISNULL(P.ThirdName,'') + ' ' +
			                            P.LastName + ' '
		                            ) AS FullName,
		                            (
			                            SELECT COUNT(T.TestID)
			                            FROM Tests T
			                            WHERE T.TestAppointmentID = TA.TestAppointmentID
		                            ) AS Trial,
		                            TA.AppointmentDate,
		                            TA.PaidFees,
		                            TA.CreatedByUserID,
		                            U.UserName,
                                    TA.IsLocked,
		                            (
			                            CASE
				                            WHEN T.TestID IS NULL THEN -1
				                            ELSE T.TestID
			                            END
		                            ) AS TestID
                            FROM TestAppointments TA
                            INNER JOIN LocalDrivingLicenseApplications LDLA
                            ON TA.LocalDrivingLicenseApplicationID = LDLA.LocalDrivingLicenseApplicationID
                            INNER JOIN LicenseClasses LC
                            ON LC.LicenseClassID = LDLA.LicenseClassID
                            INNER JOIN Applications A
                            ON LDLA.ApplicationID = A.ApplicationID
                            INNER JOIN People P
                            ON A.ApplicantPersonID = P.PersonID
                            INNER JOIN Users U
                            ON U.UserID = TA.CreatedByUserID
                            INNER JOIN TestTypes TT
                            ON TA.TestTypeID = TT.TestTypeID
                            LEFT JOIN Tests T
                            ON TA.TestAppointmentID = T.TestAppointmentID
                            WHERE TA.TestAppointmentID = @TestAppointmentID";

            
            SqlCommand command = new SqlCommand (query, connection);    
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentId);

            try
                {
                    connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                        
                if (reader.Read())
                {
                    isFound = true;

                    localDrivingLicenseApplicationId = (int)reader["LocalDrivingLicenseApplicationID"];
                    licenseClassId = (int)reader["LicenseClassID"];
                    licenseClassName = (string)reader["ClassName"];
                    testTypeId = (int)reader["TestTypeID"];
                    testTypeTitle = (string)reader["TestTypeTitle"];
                    fullName = (string)reader["FullName"];
                    trail = (int)reader["Trial"];
                    appointmentDate = (DateTime)reader["AppointmentDate"];
                    paidFees = (decimal)reader["PaidFees"];
                    testId = (int)reader["TestID"];
                    createdByUserId = (int)reader["CreatedByUserID"];
                    createdByUsername = (string)reader["UserName"];
                    isLocked = (bool)reader["IsLocked"];
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                isFound = false;
            }
                
        

            return isFound;
        }

        public static int Insert
            (
                int testTypeId, int localDrivingLicenseApplicationId,
                DateTime appointmentDate, decimal paidFees,
                int createdByUserId, bool isLocked
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
		                               )
                                 VALUES
                                       (
		                               @TestTypeID
                                       ,@LocalDrivingLicenseApplicationID
                                       ,@AppointmentDate
                                       ,@PaidFees
                                       ,@CreatedByUserID
                                       ,@IsLocked
		                               );
                            SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationId);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserId);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

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

        public static bool CheckIfLocalApplicationHasActiveTestAppintment
            (
            int localDrivingLicenseApplication,int testTypeId
            )
        {
            bool hasActiveAppointment = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 1
                            FROM TestAppointments TA
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                            AND IsLocked = 0    AND
		                        TA.TestTypeID = @TestTypeID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplication);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    hasActiveAppointment = true;
                } else
                {
                    hasActiveAppointment = false;
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return hasActiveAppointment;
        }

        public static bool CheckIfPassedTest
            (
            int localDrivingLicenseApplication, int testTypeId
            )
        {
            bool passedTest = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 1
                            FROM TestAppointments TA
                            LEFT JOIN Tests T
                            ON TA.TestAppointmentID = T.TestAppointmentID
                            WHERE	TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID AND
		                            TA.IsLocked = 1		AND
		                            TA.TestTypeID = @TestTypeID	AND
		                            T.TestResult = 1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplication);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    passedTest = true;
                }
                else
                {
                    passedTest = false;
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return passedTest;
        }

    }
}
