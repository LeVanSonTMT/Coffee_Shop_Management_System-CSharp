using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? vao, DateTime? ra, string tt)
        {
            this.Id = id;
            this.Thoigianra = ra;
            this.Thoigianvao = vao;
            this.Tthd = tt; 
        }

        public Bill(DataRow row)
        {
            this.Id = (int)row["idhd"];
            this.Thoigianvao = (DateTime?)row["thoigianvao"];

            var ktThoigianra = row["thoigianra"];
            if(ktThoigianra.ToString() != "")
                this.Thoigianra = (DateTime?)ktThoigianra;

            this.Tthd = row["tthd"].ToString();
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

        private DateTime? thoigianvao;
        public DateTime? Thoigianvao
        {
            get
            {
                return thoigianvao;
            }

            set
            {
                thoigianvao = value;
            }
        }

        private DateTime? thoigianra;
        public DateTime? Thoigianra
        {
            get
            {
                return thoigianra;
            }

            set
            {
                thoigianra = value;
            }
        }

        private string tthd;
        public string Tthd
        {
            get
            {
                return tthd;
            }

            set
            {
                tthd = value;
            }
        }

    }
}
