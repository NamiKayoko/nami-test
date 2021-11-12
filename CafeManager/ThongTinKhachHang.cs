using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CafeManager
{
    public partial class frmThongTinKhachHang : Form
    {
        private object ds;
        private object adapter;

        public class ThongTinKhachhang
        {
            private string text1;
            private string text2;

            public ThongTinKhachhang(string text1, string text2)
            {
                this.text1 = text1;
                this.text2 = text2;
            }
        }
        public frmThongTinKhachHang()
        {
            InitializeComponent();
        }

      

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao;
            ThongBao = MessageBox.Show("bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ThongBao == DialogResult.Yes)
            
                Application.Exit();
        }

        private void frmThongTinKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Clear();
            txtTenKhachHang.Clear();
            btnLuu.Enabled = true;    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                //conn.Open();
                int CurrentIndex = dtgvThongTinKhachhang.CurrentCell.RowIndex;
                string MaKhachHang = Convert.ToString(dtgvThongTinKhachhang.Rows[CurrentIndex].Cells[0].Value.ToString());
                string deletedStr = "Delete from ThongTinKhachHang where MaKhachHang='" + MaKhachHang + "'";
                SqlCommand deletedCmd = new SqlCommand(deletedStr, conn);
                deletedCmd.CommandType = CommandType.Text;
                deletedCmd.ExecuteNonQuery();
                //adapter.update(ds, "ThongTinKhachHang");
                LoadData();
                MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvThongTinKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            btnLuu.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
             
            try
            {
                SqlConnection conn = new SqlConnection();
                //conn.Open();
                int CurrentIndex = dtgvThongTinKhachhang.CurrentCell.RowIndex;
                string MaKhachHang = Convert.ToString(dtgvThongTinKhachhang.Rows[CurrentIndex].Cells[0].Value.ToString());
                string TenKhachHang = Convert.ToString(dtgvThongTinKhachhang.Rows[CurrentIndex].Cells[1].Value.ToString());
          
                string updateStr = "Update KhachHang set MaKhachHang='" + MaKhachHang + "',TenKhachHang='" + TenKhachHang + "' ";
                SqlCommand updateCmd = new SqlCommand(updateStr, conn);
                updateCmd.CommandType = CommandType.Text;
                updateCmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("Bạn đã cập nhật thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            throw new NotImplementedException();
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            //string t = "select *from ThongTinKhachHang";
            // sqlConnection sql = new sqlConnection();
            //DataTable dt = sql.ExecuteQuery(t);
            //dtgvThongTinKhachhang.DataSource = dt;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
    }

   
    
}

