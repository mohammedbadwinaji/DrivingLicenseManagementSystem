using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic;

namespace DrivingLicense.Presentation.controls
{
    public partial class usrUserDetails : UserControl
    {
        public event Action<int> OnPersonalInformationSave;
        public usrUserDetails()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int userId)
        {
            if(userId == -1)
            {
                return;
            }

            clsUser user = clsUser.FindByID(userId);
            if (user == null) {
                MessageBox.Show($"User With ID {userId} Not Found");
                return;
            }

            usrPersonDetails1.LoadPersonInfo(user.PersonId);
            usrPersonDetails1.OnSave += _HandlePersonInfoSaved;

            lblUserID.Text = user.UserId.ToString();
            lblUsername.Text = user.UserName;
            lblIsActive.Text = user.IsActive ? "Yes" : "No";
        }
        public void _HandlePersonInfoSaved(int personId) {
            OnPersonalInformationSave?.Invoke(personId);   
        }
       
    }
}
