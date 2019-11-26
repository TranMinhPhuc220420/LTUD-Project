﻿using System;
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
            //load form menu main
        }
         
        private void thoátChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhongBan frmLogin = new frmPhongBan();
            frmLogin.MdiParent = this;
            frmLogin.Show();
        }

        private void frmMDIMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show(
                "Bạn có muốn thoát chương trình?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frmNhanVien = new frmNhanVien();
            frmNhanVien.MdiParent = this;
            frmNhanVien.Show();
        }

        private void hợpĐồngLaoĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHopDongLaoDong frmHopDongLaoDong = new frmHopDongLaoDong();
            frmHopDongLaoDong.MdiParent = this;
            frmHopDongLaoDong.Show();
        }

        private void chucVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu frmChucVu = new frmChucVu();
            frmChucVu.MdiParent = this;
            frmChucVu.Show();
        }
    }
}
