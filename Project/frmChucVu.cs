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
    public partial class frmChucVu : Form
    {
        private handleDatabase connSV = new handleDatabase();

        public frmChucVu()
        {
            InitializeComponent();
        }

        private void loadTableChucVu()
        {
            dgvChucVu.DataSource = connSV.getTalbeChucVu();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            loadTableChucVu();
        }

        private bool isTxtEmpty()
        {
            if(txtMaCV.Text == string.Empty)
            {
                errorTxt.SetError(txtMaCV, "Dữ liệu còn thiếu");
                MessageBox.Show("Dữ liệu Mã Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                errorTxt.Clear();
                if(txtTenCV.Text == string.Empty)
                {
                    errorTxt.SetError(txtTenCV, "Dữ liệu còn thiếu");
                    MessageBox.Show("Dữ liệu Tên Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                else
                {
                    errorTxt.Clear();
                }
            }
            return false;
        }

        private void dgvChucVu_Click(object sender, EventArgs e)
        {
            int r = dgvChucVu.CurrentCell.RowIndex;

            txtMaCV.Text = dgvChucVu.Rows[r].Cells[0].Value.ToString();
            txtTenCV.Text = dgvChucVu.Rows[r].Cells[1].Value.ToString();
        }

        private void enbledAllBtnFunctuinMain()
        {
            //Enabled don't need
            txtMaCV.Enabled = true;
            txtTenCV.Enabled = true;

            txtMaCV.Text = "mã chức vụ...";
            txtTenCV.Text = "tên chức vụ...";

            btnSearch.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            dgvChucVu.Enabled = false;
        }

        private void restartAllBtnFunctuinMain()
        {
            //Turn on comeback
            txtMaCV.Enabled = false;
            txtTenCV.Enabled = false;
            txtMaCV.Text = "mã chức vụ...";
            txtTenCV.Text = "tên chức vụ....";
            btnAdd.Enabled = true;
            btnSearch.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            dgvChucVu.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Remove btnAdd and after that add btnCancelAdd
            this.btnCancelAdd.Visible = true;
            this.btnAddSub.Visible = true;

            //Enabled don't need
            enbledAllBtnFunctuinMain();

            //Clear txt to input
            txtMaCV.Text = "mã chức vụ";
            txtTenCV.Text = "tên chức vụ";

            txtMaCV.Focus();
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            //Remove btnCancelAdd and after that add btnAdd
            this.btnCancelAdd.Visible = false;
            this.btnAddSub.Visible = false;

            //Turn on comeback
            restartAllBtnFunctuinMain();
        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            if (this.connSV.insertChucVu(this.txtMaCV.Text, this.txtTenCV.Text) == 1)
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Reload table ChucVu
            loadTableChucVu();

            //Remove btnCancelAdd and after that add btnAdd
            this.btnCancelAdd.Visible = false;
            this.btnAddSub.Visible = false;
            //Turn on comeback
            restartAllBtnFunctuinMain();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();

            result = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá Chức Vụ " + txtTenCV.Text + " không?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (this.connSV.deleteChucVu(txtMaCV.Text) == 0)
                {
                    MessageBox.Show(
                       "Xoá không thành công",
                       "Thông báo",
                       MessageBoxButtons.OK, 
                       MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                       "Xoá thành công",
                       "Thông báo",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Asterisk);
                }
                //reload table chuc vu
                loadTableChucVu();
            }
        }

        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaCV.Text == string.Empty)
            {
                errorTxt.SetError(txtMaCV, "Dữ liệu còn thiếu");
                MessageBox.Show("Dữ liệu Mã Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                errorTxt.Clear();
            }
        }

        private void txtTenCV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenCV.Text == string.Empty)
            {
                errorTxt.SetError(txtTenCV, "Dữ liệu còn thiếu");
                MessageBox.Show("Dữ liệu Tên Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                errorTxt.Clear();
            }
        }
    }
}
