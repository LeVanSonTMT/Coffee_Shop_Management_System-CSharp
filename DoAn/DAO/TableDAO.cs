using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
    class TableDAO
    {
        private static TableDAO instance;
        public static int tableWidth = 80;
        public static int tableHeight = 80;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableDAO(); return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private TableDAO() { }

        // chức năng chuyển bàn
        public void ChuyenBan(int id1, int id2)
        {
            DataTable data = DataConnection.Instance1.ExecuteQuery("USP_ChuyenBan @idBan1 , @idBan2 ", new object[] { id1, id2 });
        }

        //chức năng hiển thị Danh sách bàn ăn
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataConnection.Instance1.ExecuteQuery("USP_GetBanAn");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        
        //Thêm món ăn mới vào bảng
        public bool InsertBanAn(string ten)
        {
            string query = string.Format("insert into ban values( '{0}' ,'Trong')", ten);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa món ăn tại ID nào đó
        public bool UpdateBanAn(int id, string ten)
        {
            string query = string.Format("update ban set tenban = '{0}' where idban = {1} ", ten, id);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);
            return result > 0;
        }

        //Xóa món ăn tại ID nào đó
        public bool DeleteBanAn(int id)
        {
            string query = string.Format("delete ban where idban = {0} ", id);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);
            return result > 0;
        }

        //chức năng tìm kiếm Bàn ăn theo tên
        public List<Table> TimKiemBanAn(string ten)
        {
            List<Table> list = new List<Table>();
            string query = "select * from ban where tenban like '%" + ten + "%' ";
            DataTable data = DataConnection.Instance1.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table ban = new Table(item);
                list.Add(ban);
            }
            return list;
        }
    }
}
