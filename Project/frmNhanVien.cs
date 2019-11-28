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
    public partial class frmNhanVien : Form
    {
        //Variable
        private handleDatabase db = new handleDatabase();

        public frmNhanVien()
        {
            //Show funtion and display form
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            int r = dgvNhanVien.CurrentCell.RowIndex;
            txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            cbGioTinh.Text = dgvNhanVien.Rows[r].Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            txtDanToc.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            txtQueQuan.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
            txtCMND.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString();
            cbPhongBan.Text = dgvNhanVien.Rows[r].Cells[9].Value.ToString();
            cbChucVu.Text = dgvNhanVien.Rows[r].Cells[10].Value.ToString();
            cbTrinhDoHocVan.Text = dgvNhanVien.Rows[r].Cells[11].Value.ToString();
            txtLuongCB.Text = dgvNhanVien.Rows[r].Cells[12].Value.ToString();
            cbLoaiHopDong.Text = dgvNhanVien.Rows[r].Cells[13].Value.ToString();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //show data NHANVIEN on dataGridView NHANVIEN
            dgvNhanVien.DataSource = db.getTableNhanVien();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
