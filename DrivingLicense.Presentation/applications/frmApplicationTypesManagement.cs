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

namespace DrivingLicense.Presentation.applications
{
    public partial class frmApplicationTypesManagement : Form
    {
        public frmApplicationTypesManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _LoadApplicationTypes()
        {
            DataTable applicationTypes = clsApplicationType.GetAllApplicationTypes();

            dgvApplicationTypes.DataSource = applicationTypes;
            dgvApplicationTypes.Columns["ApplicationTypeID"].HeaderText = "ID";
            dgvApplicationTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";
            dgvApplicationTypes.Columns["ApplicationFees"].HeaderText = "Fees";

            lblRecords.Text = dgvApplicationTypes.Rows.Count.ToString();
        }
        private void frmApplicationTypesManagement_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypes();
          
        }

        private int _GetSelectedApplicationTypeID()
        {
            int applicatoinTypeId = -1;
            if (dgvApplicationTypes.SelectedRows.Count > 0)
            {
                applicatoinTypeId = Convert.ToInt32(dgvApplicationTypes.SelectedRows[0].Cells["ApplicationTypeID"].Value);
            }
            return applicatoinTypeId;
        }
        private void cmiEditApplicationType_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType(_GetSelectedApplicationTypeID());
            frm.OnSave += _HandleApplicationTypeSave;
            frm.ShowDialog();
        }
        private void _HandleApplicationTypeSave(int applicationTypeID)
        {
            _LoadApplicationTypes();
        }
    }
}
