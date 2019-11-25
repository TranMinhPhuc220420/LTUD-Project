using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmMDIMain : Form
    {
        public frmMDIMain()
        {
            InitializeComponent();
        }

        private void frmMDIMain_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.MdiParent = this;
            frmLogin.Show();
        }
    }
}
