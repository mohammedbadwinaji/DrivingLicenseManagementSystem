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
    public partial class frmEditApplicationType : Form
    {
        public event Action<int> OnSave;
        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicationTypeID;
        }


        private void _LoadApplicationTypeData()
        {
            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.FindByID(this._ApplicationTypeID);

            if(_ApplicationType == null)
            {
                MessageBox.Show($"No Applicatoin Type With ID {_ApplicationTypeID}");
                this.Close();
                return;
            }

            _LoadApplicationTypeData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.ApplicationTypeTitle = txtTitle.Text;
            _ApplicationType.ApplicationTypeFees = Convert.ToDecimal(txtFees.Text);

            string errorMessage = string.Empty;
            if (_ApplicationType.Save(out errorMessage))
            {
                MessageBox.Show("Application Type Saved Successfully");
                OnSave?.Invoke(_ApplicationType.ApplicationTypeID);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
