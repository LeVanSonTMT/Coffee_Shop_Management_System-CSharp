using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    public class Account
    {
        public Account(string user, string pass, string ten, int loai, int id)
        {
            this.Id = id;
            this.Tendk = ten;
            this.Username = user;
            this.Passwork = pass;            
            this.Loai = loai;            
        }

        public Account(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Tendk = row["tendK"].ToString();
            this.Username = row["username"].ToString();
            this.Passwork = row["passwork"].ToString();
            this.Loai = (int)row["loai"];            
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

        private string tendk;
        public string Tendk
        {
            get
            {
                return tendK;
            }

            set
            {
                tendK = value;
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        private string passwork;
        public string Passwork
        {
            get
            {
                return passwork;
            }

            set
            {
                passwork = value;
            }
        }

        private int loai;
        public int Loai
        {
            get
            {
                return loai;
            }

            set
            {
                loai = value;
            }
        }

        
    }
}
