using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DAO
{
    public class DataConnection
    {
        private static DataConnection Instance;

        public static DataConnection Instance1
        {
            get
            {
                if (Instance == null) Instance = new DataConnection(); return  DataConnection.Instance;
            }
            private set { DataConnection.Instance = value; }
        }

        private DataConnection(){}

        private String duongdan = "Data Source=.\\sqlexpress;Initial Catalog=DataQLQuanCafe;Integrated Security=True";

        public DataTable ExecuteQuery(String q , object[] para = null )
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(duongdan))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(q, connection);

                if(para != null)
                {
                    string[] listpara = q.Split(' ');
                    int i = 0;
                    foreach(string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            comm.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(String q, object[] para = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(duongdan))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(q, connection);

                if (para != null)
                {
                    string[] listpara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            comm.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }
                data = comm.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(String q, object[] para = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(duongdan))
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(q, connection);

                if (para != null)
                {
                    string[] listpara = q.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            comm.Parameters.AddWithValue(item, para[i]);
                            i++;
                        }
                    }
                }
                data = comm.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

    }
}
