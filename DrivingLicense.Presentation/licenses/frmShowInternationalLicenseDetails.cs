using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicense.Presentation.licenses
{
    public partial class frmShowInternationalLicenseDetails : Form
    {
        private int _InternationalLicenseID;
        public frmShowInternationalLicenseDetails(int internationalLicenseId)
        {
            InitializeComponent();
            _InternationalLicenseID = internationalLicenseId;
        }

        private void frmShowInternationalLicenseDetails_Load(object sender, EventArgs e)
        {
            usrInternationalLicenseDetails1.LoadInternationalLicenseInfo(_InternationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
