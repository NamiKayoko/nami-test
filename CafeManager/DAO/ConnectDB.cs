using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CafeManager.DAO
{
    public class ConnectDB
    {
        private string sconn = "Data Source=DESKTOP-UMNNHN6;Initial Catalog=QLQUANCAFE;Integrated Security=True";
        SqlConnection conn = null; //
        SqlCommand cmd = null;
        DataSet ds = new DataSet();

        /// <summary>
        /// Mo ket noi
        /// </summary>
        public void ConnecDB()
        {
            try
            {
                conn = new SqlConnection(sconn);
                conn.Open();
            }
            catch
            {

            }
        }
        // thuc hien cau sql truyen vao
        public DataTable ExecuteNonQuery(string sql)
        {
            DataTable dt = new DataTable();
            try {
                ConnecDB();
                cmd = new SqlCommand(sql, conn); //cau truy van de thuc thi( thuc thi query tren ket noi nao )
                SqlDataAdapter adapter = new SqlDataAdapter(cmd); //trung gian thuc hien cau truy vấn để lấy dl 
                adapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception exp)
            {

                dt = null;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

    }
}
