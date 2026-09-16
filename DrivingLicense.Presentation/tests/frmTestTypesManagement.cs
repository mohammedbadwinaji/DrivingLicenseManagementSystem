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

namespace DrivingLicense.Presentation.tests
{
    public partial class frmTestTypesManagement : Form
    {
        public frmTestTypesManagement()
        {
            InitializeComponent();
        }

        private void _LoadTestTypes()
        {
            DataTable testTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = testTypes;

            dgvTestTypes.Columns["TestTypeID"].HeaderText = "ID";
            dgvTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";
            dgvTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";
            dgvTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";

            dgvTestTypes.Columns["TestTypeDescription"].Width = 250;
            dgvTestTypes.Columns["TestTypeTitle"].Width = 150;
            dgvTestTypes.Columns["TestTypeFees"].Width = 100;
        }
        private void frmTestTypesManagement_Load(object sender, EventArgs e)
        {
            _LoadTestTypes();
        }


        private int _GetSelectedTestTypeID()
        {
            int testTypeId = -1;

            if(dgvTestTypes.SelectedRows.Count > 0)
            {
                testTypeId  = Convert.ToInt32(dgvTestTypes.SelectedRows[0].Cells["TestTypeID"].Value);
            }

            return testTypeId;
        }
        private void cmiEditTestType_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType(_GetSelectedTestTypeID());
            frm.OnSave += _HandleTestTypeSave;
            frm.Show();
        }
        private void _HandleTestTypeSave(int testTypeId)
        {
            _LoadTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
