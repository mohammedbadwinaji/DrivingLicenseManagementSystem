using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingLicense.DataAccess;

namespace DrivingLicense.BusinessLogic
{
    public class clsUser
    {
        enum enMode
        {
            AddNew,
            Edit
        }
        public int UserId { get; private set; }
        public int PersonId { get; set; }   

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo { get; set; }

        private enMode _Mode;

        public clsUser()
        {
            UserId = -1;
            PersonId = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            PersonInfo = null;
            _Mode = enMode.AddNew;
        }
        private clsUser(int userId, int personId, string userName, string password, bool isActive, clsPerson personInfo)
        {
            UserId = userId;
            PersonId = personId;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            PersonInfo = personInfo;
            _Mode = enMode.Edit;
        }
        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }
        public static clsUser FindByID(int userId)
        {
            int personId;
            string username , password;
            bool isActive;
            bool isUserExists = clsUserDataAccess.GetUserByID(userId, out personId, out username, out password, out isActive);

            if (isUserExists)
            {
                clsPerson personInfo = clsPerson.FindById(personId);

                return new clsUser(userId,personId,username,password,isActive,personInfo);
            }
            return null;
        }
        private static clsUser FindByUserName(string username)
        {
            int userId,personId;
            string  password;
            bool isActive;
            bool isUserExists = clsUserDataAccess.GetUserByUserName(username,out userId,out personId,out password, out isActive);   

            if (isUserExists)
            {
                clsPerson personInfo = clsPerson.FindById(personId);

                return new clsUser(userId, personId, username, password, isActive, personInfo);
            }
            return null;
        }
        public static clsUser Login
            (
            string username, string password,
             bool rememberMe,out string errorMessage
            )
        {
            int userId = -1;
            errorMessage = "";
            if (string.IsNullOrEmpty(username))
            {
                errorMessage = "User Name Is Required";
                return null;
            }

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Password Is Required";
                return null;
            }
            clsUser user = clsUser.FindByUserName(username);

            if(user == null)
            {
                errorMessage = "Invalid Creditials";
                return null;
            }

            if(
                    user.UserName == username && user.Password == password
                )
            {
                if (user.IsActive)
                {
                    userId = user.UserId;
                    if (rememberMe)
                    {
                        clsRemeberMe.remeber(username, password);
                    }
                    else
                    {
                        clsRemeberMe.doNotRemeber();
                    }
                    return  clsUser.FindByID(userId);
                }
                else
                {
                    errorMessage = "You Account Is DeActivated Call Admin";
                    return null;
                }
            }else
            {
                errorMessage = "Invalid Creditials";
                return null;
            }
        }
        public bool _AddNew(out string errorMessage)
        {
            errorMessage = "";

            if (!clsPersonDataAccess.IsPersonIDExists(PersonId) ){
                errorMessage = $"Person With ID {PersonId} Is Not Exists";
                return false;
            }
            if (clsUserDataAccess.IsUserNameExists(UserName,UserId)) {
                errorMessage = $"User Name {UserName} Already Exists";
                return false;
            }

            UserId = clsUserDataAccess.Insert
                (
                    PersonId,UserName,Password,IsActive
                );

            if(UserId != -1)
            {
                PersonInfo = clsPerson.FindById(PersonId);
                _Mode = enMode.Edit;
            }else
            {
                errorMessage = "Server Errror";
            }
            return UserId != -1;
        }
        public bool _Edit(out string errorMessage)
        {
            errorMessage = "";

            if (!clsPersonDataAccess.IsPersonIDExists(PersonId))
            {
                errorMessage = $"Person With ID {PersonId} Is Not Exists";
                return false;
            }
            if (clsUserDataAccess.IsUserNameExists(UserName, UserId))
            {
                errorMessage = $"User Name {UserName} Already Exists";
                return false;
            }

            bool IsUserUpdated = clsUserDataAccess.Update(UserId,UserName,Password,IsActive);

            if (IsUserUpdated) {
                PersonInfo= clsPerson.FindById(PersonId);
            }
            else
            {
                errorMessage = "Server Error";
            }
            return  IsUserUpdated;
        }
        public  bool Save(out string errorMessage)
        {
            errorMessage = "";
            switch (_Mode)
            {
                case enMode.AddNew:
                    return _AddNew(out errorMessage);
                case enMode.Edit:
                    return _Edit(out errorMessage);
            }
            return false;
        }


        public static bool IsUserExists(int userId)
        {
            return clsUserDataAccess.IsUserIDExists(userId);
        }
        public static bool IsPasswordEqual(int userId, string password)
        {
            return clsUserDataAccess.IsPasswordEquals(userId, password);
        }

        public static bool ChangePassword(int userId,string currentPassword, string newPassword)
        {
            return clsUserDataAccess.UpdatePassword(userId, newPassword);
        }
    }
}
