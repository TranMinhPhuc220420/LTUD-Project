using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class handleDatabase
    {
        //Variable
        SqlConnection connSV = new SqlConnection();
        private SqlCommand cmd;
        private SqlDataAdapter adpt;

        /// <summary>
        /// Constructor 
        /// Connect Database and open this
        /// </summary>
        public handleDatabase()
        {
            try
            {
                this.connSV.ConnectionString = "Data Source=DESKTOP-N36TKI7;Initial Catalog=QLNS;Integrated Security=True";
                this.connSV.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message,
                    "Lỗi kết nối",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Kiem tra bien connSV da co ket noi hay chua. Neu chua thi tien hang ket noi vao mo
        /// </summary>
        public void setConnSVOpen()
        {
            if (this.connSV.State != ConnectionState.Open)
            {
                this.connSV.Open();
            }
        }

        /// <summary>
        /// Get all information in table NHANVIEN
        /// </summary>
        /// <returns></returns>
        public DataTable getTableNhanVien()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(@"sp_SelectAllNhanVien", connSV);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);

            this.connSV.Close();
            return dataTable;
        }


        /// <summary>
        /// Get all information in table CHUCVU
        /// </summary>
        /// <returns></returns>
        public DataTable getTalbeChucVu()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(@"sp_SelectAllChucVu", connSV);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);

            this.connSV.Close();
            return dataTable;
        }

        /// <summary>
        /// Them du lieu vao trong bang Chuc Vu
        /// </summary>
        /// <param name="MaCV">Ma chuc vu them</param>
        /// <param name="tenCV">Ten chuc vu them</param>
        /// <returns> int </returns>
        public int insertChucVu(string MaCV, string tenCV)
        {
            setConnSVOpen();
            int resultAdd;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_InsertChucVu", connSV);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MaCV", MaCV);
                sqlCommand.Parameters.AddWithValue("@TenCV", tenCV);

                //Exec query
                resultAdd = sqlCommand.ExecuteNonQuery();
            }
            catch(SqlException sqlEx)
            {
                System.Windows.Forms.MessageBox.Show(
                   "Lỗi trong dữ liệu\n " + sqlEx.Message,
                   "Lỗi trong kết nối",
                   System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Question
                   );
                resultAdd = 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    ex.Message,
                    "Lỗi trong kết nối",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Question
                    );
                resultAdd = 0;
            }
            finally
            {
                this.connSV.Close();
            }

            return resultAdd;
        }

        public int deleteChucVu(string MaCV)
        {
            setConnSVOpen();
            int result = 0;
            try
            {
                this.cmd = new SqlCommand("sp_DeleteChucVu", this.connSV);
                this.cmd.CommandType = CommandType.StoredProcedure;
                this.cmd.Parameters.AddWithValue("@maCV", MaCV);

                result = this.cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Lỗi SQL\n" + sqlEx.Message,
                    "Lỗi dữ liệu",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Lỗi ngoại lệ: \n" + ex.Message,
                    "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                this.connSV.Close();
            }
            
            return result;
        }
    }
}
