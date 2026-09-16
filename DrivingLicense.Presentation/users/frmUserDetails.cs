using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicense.Presentation.users
{
    public partial class frmUserDetails : Form
    {
        public event Action<int> OnPersonalInformationSave;
        private int _UserID;

        public frmUserDetails(int userId,string title = "User Information")
        {
            InitializeComponent();
            _UserID = userId;
            lblTitle.Text = title;
        }

        private void _LoadUserInfo()
        {
            usrUserDetails1.LoadUserInfo(_UserID);
            usrUserDetails1.OnPersonalInformationSave += _HandlePersonalInformationSave;
        }
        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            if(_UserID == -1)
            {
                MessageBox.Show("Choose User To View Detials");
                this.Close();
                return;
            }

            _LoadUserInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _HandlePersonalInformationSave(int personId)
        {
            OnPersonalInformationSave?.Invoke(personId);
        }
    }
}
