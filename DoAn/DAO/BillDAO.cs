using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO(); return  instance;
            }

           private set
            {
                instance = value;
            }
        }

        private BillDAO() { }

        // lấy hóa hoa theo id bàn
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataConnection.Instance1.ExecuteQuery("Select * from hoadon where idban = "+ id + " and tthd = 'chua thanh toan' ");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }

        //chức năng thanh toán/ cập nhật lại hóa đơn
        public void ThanhToanHoaDon(int id, int tongtien)
        {
            string query = "UPDATE hoadon SET tthd='da thanh toan' , thoigianra=GETDATE() , tongtien = "  + tongtien + " WHERE idhd = " + id;
            DataConnection.Instance1.ExecuteNonQuery(query);
        }

        // them thong tin vào hóa đơn
        public void InsertBill(int id)
        {
            DataConnection.Instance1.ExecuteNonQuery("exec USP_InsertBill @idban ", new object[] { id });

        }

        // lấy id hóa đơn lớn nhất 
        public int GetMaxID()
        {
            try
            {
                return (int)DataConnection.Instance1.ExecuteScalar("Select MAX(idhd) from hoadon");
            }
            catch { return 1; }            
        }

        // hiển thị hóa đơn cho bảng doanh thu
        public DataTable hienthiDoanhThu(DateTime a, DateTime b)
        {
          return   DataConnection.Instance1.ExecuteQuery("exec USP_GETListBillByDate @tgvao , @tgra ", new object[] { a , b });
        }


    }
}
