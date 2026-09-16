using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicense.Presentation.applications
{
    public partial class frmLocalDrivingLicenseApplicationDetails : Form
    {
        public event Action<int> OnPersonalInformationSaved;
        private int _LocalDrivingLicenseApplicationId;
        public frmLocalDrivingLicenseApplicationDetails(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
        }


        private void frmLocalDrivingLicenseApplicationDetails_Load(object sender, EventArgs e)
        {
            if(_LocalDrivingLicenseApplicationId == -1)
            {
                MessageBox.Show("Choose Local Driving License To View Detials");
                this.Close();
                return;
            }
            usrLocalDrivingLicenseApplicationDetails1.LoadLocalDrivingLicenseInfo(_LocalDrivingLicenseApplicationId);
            usrLocalDrivingLicenseApplicationDetails1.OnPersonalInformationSaved += OnPersonalInformationSaved;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
