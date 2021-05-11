using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
   public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodDAO(); return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private FoodDAO() { }

        //lay dl Bảng Món Ăn
        public List<Food> GetFoodList()
        {
            List<Food> list = new List<Food>();
            string query = "select * from food";
            DataTable data = DataConnection.Instance1.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        //Thêm món ăn mới vào bảng
        public bool InsertFood(string ten, int gia)
        {
            string query = string.Format("insert into Food values('{0}', {1})", ten, gia);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);

            return result > 0;
        }

        //Sửa món ăn tại ID nào đó
        public bool UpdateFood(int id, string ten, int gia)
        {
            string query = string.Format("update food set tenFood = '{0}', giafood = {1} where idfood = {2} ", ten, gia, id);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);
            return result > 0;
        }

        //Xóa món ăn tại ID nào đó
        public bool DeleteFood(int id)
        {
            string query = string.Format("delete food where idfood = {0} ", id);
            int result = DataConnection.Instance1.ExecuteNonQuery(query);
            return result > 0;
        }

        //chức năng tìm kiếm món ăn theo tên
        public List<Food> TimKiemMonAn(string ten )
        {
            List<Food> list = new List<Food>();
            string query = "select * from food where tenFood like '%" + ten + "%' ";
            DataTable data = DataConnection.Instance1.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

    }
}
