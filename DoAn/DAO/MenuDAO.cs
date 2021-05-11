using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null) instance = new MenuDAO(); return MenuDAO.instance;
            }

            private set
            {
                MenuDAO.instance = value;
            }
        }

        private MenuDAO(){ }

        // chức năng hiển thị menu món ăn của bàn ăn nào đó
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = " select  c.tenFood, a.soluong, c.giafood, c.giafood*a.soluong as thanhtien from chitiethoadon as a, hoadon as b, food as c where a.idhd = b.idhd and a.idfood = c.idfood and b.tthd='chua thanh toan' and b.idban = " + id;
            DataTable data = DataConnection.Instance1.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
