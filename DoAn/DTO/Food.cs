using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class Food
    {
        public Food(int id, string ten, int gia)
        {
            this.Idfood = id;
            this.TenFood = ten;
            this.Giafood = gia;
        }

        public Food(DataRow row)
        {
            this.Idfood = (int)row["idfood"];
            this.TenFood = row["tenFood"].ToString();
            this.Giafood = (int)row["giafood"];
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

        private string tenFood;
        public string TenFood
        {
            get
            {
                return tenFood;
            }

            set
            {
                tenFood = value;
            }
        }

        private int giafood;
        public int Giafood
        {
            get
            {
                return giafood;
            }

            set
            {
                giafood = value;
            }
        }
    }
}
