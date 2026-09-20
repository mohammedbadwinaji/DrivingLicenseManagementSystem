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
using DrivingLicense.BusinessLogic.Licenses;
using DrivingLicense.BusinessLogic.Models;

namespace DrivingLicense.Presentation.controls
{
    public partial class usrPersonLicenses : UserControl
    {
        public usrPersonLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenses(int personId)
        {
            DataTable dt = clsLicense.GetPersonLicneses(personId);
            dgvLocalLicenses.DataSource = dt;

            dgvLocalLicenses.Columns["LicenseID"].HeaderText = "Lic ID";
            dgvLocalLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvLocalLicenses.Columns["LicenseClass"].HeaderText = "Class Name";
            dgvLocalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvLocalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvLocalLicenses.Columns["IsActive"].HeaderText = "Is Active";

            lblLocalLicensesRecords.Text = dgvLocalLicenses.Rows.Count.ToString();
        }
        private void _LoadInternationalLicenses(int personId)
        {
            DataTable dt = clsInternationalLicense.GetPersonLicneses(personId);
            dgvInternationalLicenses.DataSource = dt;

            dgvInternationalLicenses.Columns["InternationalLicenseID"].HeaderText = "Int License ID";
            dgvInternationalLicenses.Columns["ApplicationID"].HeaderText = "App ID";
            dgvInternationalLicenses.Columns["IssuedUsingLocalLicenseID"].HeaderText = "L License ID";
            dgvInternationalLicenses.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvInternationalLicenses.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvInternationalLicenses.Columns["IsActive"].HeaderText = "Is Active";

            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        public void LoadPersonLicenses(int personId)
        {
            _LoadLocalLicenses(personId);
            _LoadInternationalLicenses(personId);
        }

        private void dgvLocalLicenses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
         
            if (dgvLocalLicenses.Columns[e.ColumnIndex].Name == "LicenseClass" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int classId))
                {
                    e.Value = clsLicenseClass.GetLicenseName((enLicenseClass)e.Value);
                    e.FormattingApplied = true;
                }
            }

    }
}
}
