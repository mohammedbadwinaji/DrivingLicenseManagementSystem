using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingLicense.DataAccess
{
    public class clsUserDataAccess
    {
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT	U.UserID,
		                            P.PersonID,
		                            (
			                            P.FirstName + ' ' +
			                            P.SecondName + ' '+
			                            ISNULL(P.ThirdName,'')+ ' '+
			                            P.LastName+ ' '
		                            ) AS 'FullName',
		                            U.UserName,
		                            U.IsActive
                            FROM Users U
                            INNER JOIN People P
                            ON U.PersonID = P.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception) {
                connection.Close();
                throw;
            }
            return dt;
        }

        public static bool GetUserByID
            (
                int userId, out int personId, out string username,
                out string password ,out bool isActive
            )
        {
            bool isFound = false;
            personId = -1;
            username = "";
            password = "";
            isActive = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT	*
                            FROM Users U
                            WHERE U.UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    personId = (int)reader["PersonID"];
                    username = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception) { 
                connection.Close(); throw;
            }

            return isFound;
        }

        public static bool GetUserByUserName
    (
        string username , out int userId, out int personId,
        out string password, out bool isActive
    )
        {
            bool isFound = false;
            userId = -1;
            personId = -1;
            password = "";
            isActive = false;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT *
                                FROM Users U
                                WHERE U.UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    userId = (int)reader["UserID"];
                    personId = (int)reader["PersonID"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
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
                connection.Close(); throw;
            }

            return isFound;
        }

        public static int Insert
            (
                int personId ,string username , 
                string password , bool isActive 
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"INSERT INTO Users
                                        (
			                            PersonID
                                        ,UserName
                                        ,Password
                                        ,IsActive
		                                )
                                    VALUES
                                        (
			                             @PersonID
                                        ,@UserName
                                        ,@Password
                                        ,@IsActive
		                                )
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result != null)
                {
                    insertedId = Convert.ToInt32(result);
                }
                connection.Close();
            }catch(Exception) { connection.Close();throw;}    
            return insertedId;
        }

        public static bool Update
            (
                int userId ,  string username,
                 string password,  bool isActive
            )
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection (clsSettings.connectionString);

            string query = @"   UPDATE Users
                                SET UserName = @UserName,
                                    Password = @Password,
                                    IsActive = @IsActive
                                WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@Password", password);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@UserID", userId);

            try
            {

                connection.Open();
                rowsAffected = command.ExecuteNonQuery ();
                connection.Close();
            }catch(Exception) { connection.Close(); throw;}  
            return rowsAffected > 0;
        }


        public static bool IsUserNameExists(string username , int exeptUserId = -1)
        {
            bool isUsernameAlreadyExists = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT 1
                                FROM Users U
                                WHERE   U.UserName = @UserName AND
                                        U.UserID <> @ExeptUserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            command.Parameters.AddWithValue("@ExeptUserID", exeptUserId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) { 
                    isUsernameAlreadyExists = true;
                }else
                {
                    isUsernameAlreadyExists= false;
                }
                connection.Close();
            }catch  (Exception) { connection.Close();    throw; } 
            return isUsernameAlreadyExists;
        }



        public static bool IsUserIDExists(int userId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT 1
                                FROM Users U
                                WHERE U.UserID = @UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if(result == null || result == DBNull.Value)
                {
                    isFound = false;
                } else
                {
                    isFound = true;
                }
            }catch(Exception) {
                connection.Close();
                throw;
            }

            return isFound;
        }


        public static bool IsPasswordEquals(int userId, string password)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   SELECT 1
                                FROM Users U
                                WHERE   U.UserID = @UserID AND
                                        U.Password = @Password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userId);
            command.Parameters.AddWithValue("@Password", password);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    isFound = false;
                }
                else
                {
                    isFound = true;
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            return isFound;
        }

        public static bool UpdatePassword(int userId, string password) {
            int affectedRows = 0;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"   UPDATE Users
                                SET Password = @Password
                                WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userId);
            command.Parameters.AddWithValue("@Password", password);
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
