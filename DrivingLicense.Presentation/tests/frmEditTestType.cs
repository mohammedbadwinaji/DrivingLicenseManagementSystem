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
    public partial class frmEditTestType : Form
    {
        public event Action<int> OnSave;

        private int _TestTypeID;
        private clsTestType _TestType;
        public frmEditTestType(int testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }


        private void _LoadTestType()
        {
            lblID.Text = _TestType.TestTypeID.ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString();
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            
            _TestType = clsTestType.FindByID(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show($"No Test Type With ID {_TestType}");
                this.Close();
                return;
            }
            _LoadTestType();
        }
        private void ExtractTestTypeData()
        {
            _TestType.TestTypeTitle = txtTitle.Text;
            _TestType.TestTypeDescription = txtDescription.Text;
            _TestType.TestTypeFees = Convert.ToDecimal(txtFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage;
            ExtractTestTypeData();
            if (_TestType.Save(out errorMessage))
            {
                MessageBox.Show("Test Type Saved Successfully");
                OnSave?.Invoke(_TestType.TestTypeID);
            }
            else
            {
                MessageBox.Show(errorMessage);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
