using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        public static ChiTietHoaDonDAO Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietHoaDonDAO(); return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private ChiTietHoaDonDAO() { }

        public List<ChiTietHoaDon> GetChiTietHD(int id)
        {
            List<ChiTietHoaDon> listBill = new List<ChiTietHoaDon>();
            DataTable data = DataConnection.Instance1.ExecuteQuery("select * from chitiethoadon where idhd = "+id);
            foreach(DataRow item in data.Rows)
            {
                ChiTietHoaDon d = new ChiTietHoaDon(item);
                listBill.Add(d);
            }
            return listBill;
        }

        public void InsertChiTietHoaDon(int idhd, int idfood, int soluong)
        {
            DataConnection.Instance1.ExecuteNonQuery("exec USP_InsertChiTietHoaDon @idhd , @idfood , @soluong ", new object[] { idhd, idfood, soluong });
            
        }


    }
}
