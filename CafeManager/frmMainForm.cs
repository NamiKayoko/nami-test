using CafeManager.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManager
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

      

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            Login();
        }

        public void Login()
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog(this);
            if (frm.isLogin)
            {
                MessageBox.Show("Dang nhap thanh cong","Thông báo");
            }
            else
            {
                this.Close();
            }
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmThongTinKhachHang tt = new frmThongTinKhachHang();
            this.Hide();
            tt.ShowDialog();
            this.Show();
        }

       
    }
}
