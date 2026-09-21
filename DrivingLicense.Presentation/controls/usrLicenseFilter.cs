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

namespace DrivingLicense.Presentation.controls
{
    public partial class usrLicenseFilter : UserControl
    {
        public event Action<int> OnSearch;
        public usrLicenseFilter()
        {
            InitializeComponent();
        }

        public int GetLicenseID()
        {
            return usrLicenseDetails1.GetLicenseID();
        }

        public clsLicense GetLicenseInfo()
        {
            return usrLicenseDetails1.GetLicenseInfo();
        }

        public void LoadLicenseInfo(int licenseId)
        {
            txtLicenseID.Text = licenseId.ToString();
            _Search();
        }

        public void DisableFilter()
        {
            gbFilter.Enabled = false;
        }
        public void EnableFilter()
        {
            gbFilter.Enabled = true;
        }
        private void _Search()
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text)) return;
            int licenseId = Convert.ToInt32(txtLicenseID.Text);
            usrLicenseDetails1.LoadLicenseInfo(licenseId);
            OnSearch?.Invoke(licenseId);
        }

        
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
         
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
            if(e.KeyChar == (char) Keys.Enter)
            {
                _Search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Search();
        }
    }
}
