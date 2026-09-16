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
using DrivingLicense.BusinessLogic;
using DrivingLicense.Presentation.people;

namespace DrivingLicense.Presentation.controls
{
    public partial class usrPersonFilter : UserControl
    {
        public event Action<int> OnSearch;
        enum enFilterOption
        {
            Person_ID,
            National_No
        }
        private enFilterOption _CurrentFilterOption;

        public bool IsPersonExists = false;
        private string _GetFilterOptionString(enFilterOption filterOption)
        {
            return filterOption.ToString().Replace("_", " ");
        }
        public void LoadPersonInfo(int personId)
        {
            usrPersonDetails1.LoadPersonInfo(personId);
            cmbFilterOptions.SelectedValue = enFilterOption.Person_ID;
            txtFilterValue.Text = personId.ToString();
        }
        public void DisableFilter()
        {
            gbPersonFilter.Enabled = false;
        }
        public void EnableFilter()
        {
            gbPersonFilter.Enabled = true;
        }
        public int GetPersonID()
        {
            return usrPersonDetails1.GetPersonID();
        }

        private void SearchByID(int personId)
        {
            cmbFilterOptions.SelectedValue = enFilterOption.Person_ID;
            txtFilterValue.Text = personId.ToString();
            usrPersonDetails1.LoadPersonInfo(personId);
        }
        public usrPersonFilter()
        {
            InitializeComponent();
        }
        private void _ConfigureFilterOptions()
        {
            cmbFilterOptions.Items.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("FilterOptionView", typeof(string));
            dt.Columns.Add("FilterOptionValue", typeof(enFilterOption));

            foreach (enFilterOption filterOptoin in Enum.GetValues(typeof(enFilterOption)))
            {
                dt.Rows.Add(_GetFilterOptionString(filterOptoin), filterOptoin);
            }

            cmbFilterOptions.DisplayMember = "FilterOptionView";
            cmbFilterOptions.ValueMember = "FilterOptionValue";
            cmbFilterOptions.DataSource = dt;

            _CurrentFilterOption = enFilterOption.National_No;
            cmbFilterOptions.SelectedValue = _CurrentFilterOption;
        }
        private void usrPersonFilter_Load(object sender, EventArgs e)
        {
            _ConfigureFilterOptions();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearchPerson_Click(btnSearchPerson, EventArgs.Empty);
                return;
            }
            if (_CurrentFilterOption == enFilterOption.Person_ID)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            txtFilterValue.Focus();
            _CurrentFilterOption = (enFilterOption)cmbFilterOptions.SelectedValue;
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                MessageBox.Show("Write Value To Search");
                return;
            }
            if (_CurrentFilterOption ==  enFilterOption.Person_ID)
            {
                usrPersonDetails1.LoadPersonInfo(Convert.ToInt32(txtFilterValue.Text));
            } else
            {
                usrPersonDetails1.LoadPersonInfo(txtFilterValue.Text);
            }
            OnSearch?.Invoke(usrPersonDetails1.GetPersonID());
        }

        private void frmAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.OnSave += SearchByID;
            frm.ShowDialog();
        }
    }
}
