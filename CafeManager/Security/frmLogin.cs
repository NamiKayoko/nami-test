using CafeManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManager.Security
{
    public partial class frmLogin : Form
    {
        public bool isLogin = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == string.Empty)
            {
                MessageBox.Show("Vui long nhap ten dang nhap","Thông báo");
                txtUserID.Focus();
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Vui long nhap mat khau");
                txtPassword.Focus();
            }
            ConnectDB conn = new ConnectDB();
            string sql = "select * from taikhoan where TENDANGNHAP='" + txtUserID.Text + "' and matkhau='" + txtPassword.Text + "'";
            DataTable dt = conn.ExecuteNonQuery(sql);
            if (dt.Rows.Count > 0)
            {
                isLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai","Thông Báo");
                isLogin = false;
                //this.Close();
            }
        }

       
        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter || e.KeyCode ==Keys.Tab)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao;
            ThongBao = MessageBox.Show("bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ThongBao == DialogResult.Yes)
                Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dl;
            //dl = MessageBox.Show("Bạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dl == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
            //else
            //{
            //    e.Cancel = false;
            //}
        }
    }
}
