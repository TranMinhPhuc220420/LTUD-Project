using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    class clsKetNoiDB
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLNS;Integrated Security=True");
        //khai bao lop
        public clsKetNoiDB()
        {
            try
            {
                conn.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
        public DataTable LayDSPhongBan()
        {
            DataTable dtPhongBan = new DataTable();
            string spName = "sp_SelectAllPhongBan";
            SqlCommand cmdPhongBan = new SqlCommand(spName, conn);
            cmdPhongBan.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daPhongBan = new SqlDataAdapter(cmdPhongBan);
            daPhongBan.Fill(dtPhongBan);
            return dtPhongBan;
            //conn.Close();
        }
        
        public int ThemPhongBan(string maPB, string tenPB, string diaChi, string maTP)
        {
            string spName = "sp_InsertPhongBan";
            SqlCommand cmdThem = new SqlCommand(spName, conn);
            cmdThem.CommandText = spName;
            cmdThem.CommandType = CommandType.StoredProcedure;
            cmdThem.Parameters.Add(new SqlParameter("@maPB", maPB));
            cmdThem.Parameters.Add(new SqlParameter("@tenPB", tenPB));
            cmdThem.Parameters.Add(new SqlParameter("@diaChi", diaChi));
            cmdThem.Parameters.Add(new SqlParameter("@maTrgPhong", maTP));
            if (cmdThem.ExecuteNonQuery() > 0)
                return 1;
            else
                return 0;
        }

        public int XoaPhongBan(string maPB)
        {
            int ketQuaPB = 0;

        }
    }
}
