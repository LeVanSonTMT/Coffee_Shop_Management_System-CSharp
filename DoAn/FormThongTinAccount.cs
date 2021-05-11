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
    public partial class FormThongTinAccount : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                doiThongTinTK(loginAccount);
            }
        }

        public FormThongTinAccount(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }
        
        void doiThongTinTK(Account acc)
        {
            textBoxUsername.Text = acc.Username;
            textBoxUser.Text = acc.TendK;
            textBoxPass.Text = acc.Passwork;
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            string tendk = textBoxUser.Text;
            string username = textBoxUsername.Text;
            string pass = textBoxPass.Text;
            string newpass = textBoxNewPass.Text;
            string repass = textBoxReNewPass.Text;
            int id = (int)LoginAccount.Id;

            if(!newpass.Equals(repass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(id, tendk, username, pass, newpass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                   
                }
                else { MessageBox.Show("Vui lòng điền đúng mật khẩu của bạn!"); }
            }
             
        }


        private void FormThongTinAdmin_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNewPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
