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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "admin" && txtPassword.Text == "123")
            {
                MessageBox.Show("OKe");
            }
            else
            {
                MessageBox.Show("Not oke");
                txtPassword.Text = "";
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if(txtUsername.Text == string.Empty)
            {
                erpTxt.SetError(txtUsername, "Chưa nhập dữ liệu");
            }
            else
            {
                erpTxt.Clear();
            }
        }
    }
}
