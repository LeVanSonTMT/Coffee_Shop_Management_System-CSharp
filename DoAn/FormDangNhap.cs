using DoAn.DAO;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
        // kiểm tra đăng nhập
        bool login(string username, string pass)
        {
            return AccountDAO.Instance.login(username, pass);
        }
        // button đăng nhập và xử lý.
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string pass = textBoxPassWord.Text;
            if (login(username, pass))
            {
                //lay du lieu Account theo USername va truyen ddi
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                FormQuanLyQuanCafe f = new FormQuanLyQuanCafe(loginAccount); //truyen dl qua formQuanLyQuanCafe
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else { MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!"); }            
        }
        // button thoát
        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn thoát không?","Thông báo!",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK )
            {
                e.Cancel = true;
            }
        }
    }
}
