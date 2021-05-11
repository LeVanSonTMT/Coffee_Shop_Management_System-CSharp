using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
   public class Menu
    {
        public Menu(string monAn, int sl, int gia, int thanhtien=0)
        {
            this.Monan = monAn;
            this.Soluong = sl;
            this.Gia = gia;
            this.Thanhtien = thanhtien;
        }

        public Menu(DataRow row)
        {
            this.Monan = row["tenFood"].ToString();
            this.Soluong = (int)row["soluong"];
            this.Gia = (int)row["giafood"];
            this.Thanhtien = (int)row["thanhtien"];
        }
        
        private string monan;
        public string Monan
        {
            get
            {
                return monan;
            }

            set
            {
                monan = value;
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

        private int gia;
        public int Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }

        private int thanhtien;
        public int Thanhtien
        {
            get
            {
                return thanhtien;
            }

            set
            {
                thanhtien = value;
            }
        }

    }
}
