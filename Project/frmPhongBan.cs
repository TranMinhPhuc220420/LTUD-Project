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
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }

        clsKetNoiDB ketnoi = new clsKetNoiDB();

        //FORM LOAD EVENT
        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            dgvPhongBan.DataSource = ketnoi.LayDSPhongBan();
            dgvPhongBan.Columns[0].HeaderText = "Mã Phòng Ban";
            dgvPhongBan.Columns[1].HeaderText = "Tên Phòng Ban";
            dgvPhongBan.Columns[2].HeaderText = "Địa Chỉ";
            dgvPhongBan.Columns[3].HeaderText = "Mã Trưởng Phòng";
        }

        //EXIT FUNCTION
        private void exit()
        {
            try
            {
                if(MessageBox.Show("Do you want exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        internal static frmPhongBan GetInstance()
        {
            throw new NotImplementedException();
        }

        //ADD BUTTON
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //goi thuc thi
            try
            {
                if (ketnoi.ThemPhongBan(txtMaPB.Text, txtTenPB.Text, txtDiaChi.Text, cbMaTP.Text) == 1)
                {
                    MessageBox.Show("Đã thêm thành công", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        //LẤY DÒNG VỪA CLICK DGV VÀ ĐỔ LÊN CONTROL
        private void DgvPhongBan_Click(object sender, EventArgs e)
        {
            //lay dòng vừa click
            int row = dgvPhongBan.CurrentCell.RowIndex;
            txtMaPB.Text = dgvPhongBan.Rows[row].Cells[0].Value.ToString();
            txtTenPB.Text = dgvPhongBan.Rows[row].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvPhongBan.Rows[row].Cells[2].Value.ToString();
            cbMaTP.Text = dgvPhongBan.Rows[row].Cells[3].Value.ToString();
        }

        //EXIT BUTTON
        private void BtnExit_Click(object sender, EventArgs e)
        {
            exit();
        }
    }
}
