using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class frmTDHV : Form
    {
        public frmTDHV()
        {
            InitializeComponent();
        }

        public SqlConnection getConnection() {
            string connection = "Data Source=MT-PC\\MT;Initial Catalog=QLNS;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connection);
            return cnn;
        }

        public void getTDHV() {
            SqlConnection cnn = getConnection();
            cnn.Open();
            DataTable dtTDHV = new DataTable();
            SqlCommand cmdTDHV = new SqlCommand("sp_SelectAllTrinhDoHocVan", cnn);
            SqlDataAdapter daTDHV = new SqlDataAdapter(cmdTDHV);
            daTDHV.Fill(dtTDHV);
            dgvTDHV.DataSource = dtTDHV;
            dgvTDHV.Columns[0].HeaderText = "Mã TDHV";
            dgvTDHV.Columns[1].HeaderText = "Tên TDHV";
            dgvTDHV.Columns[2].HeaderText = "Chuyên nghành";
            cnn.Close();
        }

        public int ThemTDHV(string maTDHV, string tenTDHV, string cNganh) {
            SqlConnection cnn = getConnection();
            cnn.Open();
            int status = 0;
            try
            {
                SqlCommand cmdThem = new SqlCommand("sp_InsertTrinhDoHocVan", cnn);
                cmdThem.CommandText = "sp_InsertTrinhDoHocVan";
                cmdThem.CommandType = CommandType.StoredProcedure;
                cmdThem.Parameters.Add(new SqlParameter("@maTDHV", maTDHV));
                cmdThem.Parameters.Add(new SqlParameter("@tenTDHV", tenTDHV));
                cmdThem.Parameters.Add(new SqlParameter("@cNganh", cNganh));
                if (cmdThem.ExecuteNonQuery() != 0)
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                cnn.Close();
            }
            return status;
        }

        private void frmTDHV_Load(object sender, EventArgs e)
        {
            getTDHV();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTDHV_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dgvTDHV_Click(object sender, EventArgs e)
        {
            int row = dgvTDHV.CurrentCell.RowIndex;
            txtMaTDHV.Text = dgvTDHV.Rows[row].Cells[0].Value.ToString();
            txtTenTDHV.Text = dgvTDHV.Rows[row].Cells[1].Value.ToString();
            txtChuyenNghanh.Text = dgvTDHV.Rows[row].Cells[2].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ThemTDHV(txtMaTDHV.Text, txtTenTDHV.Text, txtChuyenNghanh.Text) != 0)
            {
                MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getTDHV();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
