using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrivingLicense.Presentation.people
{
    public partial class frmPersonDetails : Form
    {
        public event Action<int> OnSave;
        int _PersonId;
        public frmPersonDetails(int personId)
        {
            InitializeComponent();
            _PersonId = personId;
        }

        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            usrPersonDetails1.OnSave += OnSave;
            usrPersonDetails1.LoadPersonInfo(_PersonId);   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
