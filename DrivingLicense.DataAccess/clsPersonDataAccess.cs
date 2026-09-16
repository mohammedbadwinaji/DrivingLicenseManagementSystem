using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DrivingLicense.DataAccess
{
    public class clsPersonDataAccess
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT	P.PersonID,
		                            P.NationalNo,
		                            P.FirstName,
		                            P.SecondName,
		                            P.ThirdName,
		                            P.LastName,
		                            P.Gendor,
		                            P.DateOfBirth,
		                            C.CountryName AS 'Nationality',
		                            P.Phone,
		                            P.Email
                            FROM People P
                            INNER JOIN Countries C
                            ON P.NationalityCountryID = C.CountryID";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            return dt;
        }


        public static bool GetPersonByID
            (
            int personId, out string firstName, out string secondName, out string thirdName,
            out string lastName, out string nationalNo, out DateTime dateOfBirth, out byte gendor,
            out string phone, out string email, out int nationalityCountryId,
            out string address, out string imagePath

            )
        {
            firstName = secondName = thirdName = lastName = nationalNo = phone = email = address = imagePath = "";
            nationalityCountryId = -1;
            dateOfBirth = DateTime.MinValue;
            gendor = 0;

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT	P.PersonID,
		                            P.NationalNo,
		                            P.FirstName,
		                            P.SecondName,
		                            P.ThirdName,
		                            P.LastName,
		                            P.Gendor,
		                            P.DateOfBirth,
                                    P.NationalityCountryID,
		                            P.Phone,
		                            P.Email,
                                    P.Address, 
                                    P.ImagePath
                            FROM People P
                            WHERE P.PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    firstName = reader["FirstName"].ToString();
                    secondName = reader["SecondName"].ToString();
                    thirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"].ToString();
                    lastName = reader["LastName"].ToString();
                    nationalNo = reader["NationalNo"].ToString();
                    phone = reader["Phone"].ToString();
                    email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                    address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString();
                    imagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString();
                    nationalityCountryId = Convert.ToInt32(reader["NationalityCountryID"]);
                    dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    gendor = Convert.ToByte(reader["Gendor"]);
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            return isFound;
        }


        public static bool GetPersonByNationalNo
           (
           string nationalNo,out int personId, out string firstName, out string secondName, out string thirdName,
           out string lastName, out DateTime dateOfBirth, out byte gendor,
           out string phone, out string email, out int nationalityCountryId,
           out string address, out string imagePath

           )
        {
            firstName = secondName = thirdName = lastName = phone = email = address = imagePath = "";
            personId = nationalityCountryId = -1;
            dateOfBirth = DateTime.MinValue;
            gendor = 0;

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);

            string query = @"SELECT	P.PersonID,
		                            P.NationalNo,
		                            P.FirstName,
		                            P.SecondName,
		                            P.ThirdName,
		                            P.LastName,
		                            P.Gendor,
		                            P.DateOfBirth,
                                    P.NationalityCountryID,
		                            P.Phone,
		                            P.Email,
                                    P.Address, 
                                    P.ImagePath
                            FROM People P
                            WHERE P.NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    personId = (int)reader["PersonID"];
                    firstName = reader["FirstName"].ToString();
                    secondName = reader["SecondName"].ToString();
                    thirdName = reader["ThirdName"] == DBNull.Value ? "" : reader["ThirdName"].ToString();
                    lastName = reader["LastName"].ToString();
                    nationalNo = reader["NationalNo"].ToString();
                    phone = reader["Phone"].ToString();
                    email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                    address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString();
                    imagePath = reader["ImagePath"] == DBNull.Value ? "" : reader["ImagePath"].ToString();
                    nationalityCountryId = Convert.ToInt32(reader["NationalityCountryID"]);
                    dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    gendor = Convert.ToByte(reader["Gendor"]);
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }
            return isFound;
        }
        public static int Insert
            (
            string nationalNo, string firstName, string secondName, string thirdName,
            string lastName, DateTime dateOfBirth, byte gendor, string address, string phone,
            string email, int nationalityCountryID, string imagePath
            )
        {
            int insertedId = -1;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);


            string query = @"INSERT INTO People 
                            (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath) 
                            VALUES 
                            (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName", (object)secondName ?? DBNull.Value);
            command.Parameters.AddWithValue("@ThirdName", (object)thirdName ?? DBNull.Value);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gendor", gendor);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);

            string insertedImagePath = null;
            if (imagePath == null)
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                insertedImagePath = clsImageDataAccess.InsertImage(imagePath);
                command.Parameters.AddWithValue("@ImagePath", insertedImagePath);
            }

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    insertedId = Convert.ToInt32(result);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                clsImageDataAccess.DeleteImage(insertedImagePath);
                throw ex;
            }
            return insertedId;
        }

        public static bool Update
            (
            int personId, string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, DateTime dateOfBirth, byte gendor, string address,
            string phone, string email, int nationalityCountryID, string imagePath
            )
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"UPDATE People 
                            SET NationalNo = @NationalNo,
                                FirstName = @FirstName,
                                SecondName = @SecondName,
                                ThirdName = @ThirdName,
                                LastName = @LastName,
                                DateOfBirth = @DateOfBirth,
                                Gendor = @Gendor,
                                Address = @Address,
                                Phone = @Phone,
                                Email = @Email,
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath = @ImagePath 
                            WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@SecondName",secondName);
            command.Parameters.AddWithValue("@ThirdName", (object)thirdName ?? DBNull.Value);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@Gendor", gendor);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
            command.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);

            string finalImagePath = null;

            if (string.IsNullOrEmpty(imagePath))
            {
                string currentImagePath = null;
                GetPersonImage(personId, out currentImagePath);
                if(currentImagePath != null)
                {
                    clsImageDataAccess.DeleteImage(currentImagePath);
                }
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                string currentFirstName, currentSecondName, currentThirdName, currentLastName, currentNationalNo, currentPhone, currentEmail, currentAddress, currentImagePath;
                int currentNationalityCountryId; DateTime currentDob; byte currentGendor;

                bool recordExists = GetPersonByID(personId, out currentFirstName, out currentSecondName, out currentThirdName, out currentLastName, out currentNationalNo, out currentDob, out currentGendor, out currentPhone, out currentEmail, out currentNationalityCountryId, out currentAddress, out currentImagePath);

                if (recordExists && currentImagePath == imagePath)
                {
                    finalImagePath = imagePath;
                    
                }
                else
                {
                    if(currentImagePath == null)
                    {
                        finalImagePath = clsImageDataAccess.InsertImage(imagePath);
                    } else
                    {
                        finalImagePath = clsImageDataAccess.UpdateImage(currentImagePath, imagePath);
                    }
                }
                command.Parameters.AddWithValue("@ImagePath", finalImagePath);
            }

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return rowsAffected != 0;
        }


        public static bool IsPersonIDExists(int personId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 1
                            FROM People P
                            WHERE P.PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);

            try
            {
                connection.Open();
                object result= command.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    isFound = true;
                }else
                {
                    isFound = false;
                }
                connection.Close();
            }
            catch (Exception ex) {
                connection.Close();
                throw ex;
            }

            return isFound;
        }
        private static string GetPersonImage(int personId, out string ImagePath)
        {
            ImagePath = null;
            if(! IsPersonIDExists(personId))
            {
                return null;
            }
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT ImagePath
                            FROM People P
                            WHERE P.PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    ImagePath = result.ToString();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }

            return ImagePath;

        }

        public static bool IsNationalNoExists(string nationalNo,int exeptPersonId=-1)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 1
                            FROM People P
                            WHERE   P.NationalNo = @NationalNo  AND
                                    P.PersonID <> @ExeptPersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            command.Parameters.AddWithValue("@ExeptPersonID", exeptPersonId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
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

        public static bool IsPersonAUser(int personId)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsSettings.connectionString);
            string query = @"SELECT 1
                            FROM Users U
                            WHERE U.PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personId);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                throw ex;
            }

            return isFound;
        }

    }

}
