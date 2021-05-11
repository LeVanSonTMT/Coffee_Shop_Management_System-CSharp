using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private AccountDAO() { }

        // kiểm tra đăng nhập
        public bool login(string username, string pass)
        {
            string query = "USP_Login @username , @pass";
            DataTable result = DataConnection.Instance1.ExecuteQuery(query, new object[]{username, pass });
            return result.Rows.Count > 0;
        }

        //lấy dl thông qua username
        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataConnection.Instance1.ExecuteQuery("Select * From account Where username = '" + username+"'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        // cập nhập lại thông tin theo id 
        public bool UpdateAccount(int id, string ten, string user, string pass, string newpass)
        {
            string query = "exec USP_UpdateAccount @id , @tenDK , @username , @pass , @newpass";
            int result = DataConnection.Instance1.ExecuteNonQuery(query, new object[] { id, ten, user, pass, newpass });
            return result > 0;
        }

        //lấy dl bảng tài khoản
        public List<Account> GetAccount()
        {
            List<Account> list = new List<Account>();
            string query = "SELECT * FROM account";
            DataTable data = DataConnection.Instance1.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                list.Add(acc);
            }
            return list;
        }

        //Thêm nhân viên mới vào bảng
        public bool InsertNV(string tenNV, string username , int loai)
        {
            string query = string.Format("insert into account values('{0}','{1}','{2}',{3})", username,username, tenNV, loai);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa thông tin nhân viên tại ID nào đó
        public bool UpdateNV(string tenNV, string username, int loai, int id)
        {
            string query = string.Format("update account set username = '{0}' , tendK = '{1}' , loai = {2} where id = {3} ", username, tenNV, loai, id);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);
            return result > 0;
        }

        //Xóa nhân viên tại username nào đó
        public bool DeleteNV(string username)
        {
            string query = string.Format("delete account where username = '{0}' ", username);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);
            return result > 0;
        }

        //chức năng tìm kiếm nhân viên theo tên
        public List<Account> TimKiemNVTheoTen(string ten)
        {
            List<Account> list = new List<Account>();
            string query = "select * from account where tendK like '%" + ten + "%' ";
            DataTable data = DataConnection.Instance1.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account acc = new Account(item);
                list.Add(acc);
            }
            return list;
        }

    }
}
