using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
   public  class ChiTietHoaDon
    {
        public ChiTietHoaDon(int id, int idhd, int idfood, int sl)
        {
            this.Id = id;
            this.Idhd = idhd;
            this.Idfood = idfood;
            this.Soluong = sl;
        }

        public ChiTietHoaDon(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Idhd = (int)row["idhd"];
            this.Idfood = (int)row["idfood"];
            this.Soluong = (int)row["soluong"];
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        private int idhd;
        public int Idhd
        {
            get
            {
                return idhd;
            }

            set
            {
                idhd = value;
            }
        }

        private int idfood;
        public int Idfood
        {
            get
            {
                return idfood;
            }

            set
            {
                idfood = value;
            }
        }

        private int soluong;
        public int Soluong
        {
            get
            {
                return soluong;
            }

            set
            {
                soluong = value;
            }
        }

    }
}
