using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
   public class Table
    {
        public Table(int id, string tenban, string ttban)
        {
            this.Idban = id;
            this.Tenban = tenban;
            this.Ttban = ttban;
        }

        public Table(DataRow row)
        {
            this.Idban = (int)row["idban"];
            this.Tenban = row["tenban"].ToString();
            this.Ttban = row["ttban"].ToString();
        }

        private int idban;
        public int Idban
        {
            get
            {
                return idban;
            }

            set
            {
                idban = value;
            }
        }

        private string tenban;
        public string Tenban
        {
            get
            {
                return tenban;
            }

            private set
            {
                tenban = value;
            }
        }

        private string ttban;
        public string Ttban
        {
            get
            {
                return ttban;
            }

            private set
            {
                ttban = value;
            }
        }

        
    }
}
