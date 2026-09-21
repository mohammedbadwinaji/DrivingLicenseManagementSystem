using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrivingLicense.BusinessLogic.Licenses;

namespace DrivingLicense.Presentation.licenses
{
    public partial class frmShowLicenseDetails : Form
    {
        private int _LicenseID;
        public frmShowLicenseDetails(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }

        private void frmShowLicenseDetails_Load(object sender, EventArgs e)
        {
            if(_LicenseID == -1)
            {
                MessageBox.Show("Choose License To View Details");
                this.Close();
                return;
            }

            usrLicenseDetails1.LoadLicenseInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
