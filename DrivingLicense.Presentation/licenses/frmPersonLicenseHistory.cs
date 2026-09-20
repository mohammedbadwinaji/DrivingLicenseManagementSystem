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
    public partial class frmPersonLicenseHistory : Form
    {
        private int _PersonID;
        public frmPersonLicenseHistory(int personId)
        {
            InitializeComponent();
            _PersonID = personId;
        }
        private void _ConfigureUserPersonFilterControl()
        {
            usrPersonFilter1.LoadPersonInfo(_PersonID);
            usrPersonFilter1.DisableFilter();
        }
        private void _LoadLicenseHistory()
        {
            usrPersonLicenses1.LoadPersonLicenses(_PersonID);
        }
        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            _ConfigureUserPersonFilterControl();
            _LoadLicenseHistory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
