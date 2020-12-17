using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class SPContext
    {
        public string ConnectionString { get; set; }

        public SPContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<SP> GetAllAlbums()
        {
            List<SP> list = new List<SP>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sp", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SP()
                        {
                            id = reader["id"].ToString(),
                            ten = reader["ten"].ToString(),
                            loai = reader["loai"].ToString(),
                            gia = Convert.ToInt32(reader["gia"]),
                            mota = reader["mota"].ToString(),
                            brand = reader["brand"].ToString(),
                            img= reader["img"].ToString()
                            

                        });
                    }
                }
            }
            return list;

        }
        public SP GetSinhgleSP(string id)
        {
            SP list = new SP();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from sp where id='"+id+"'", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list=(new SP()
                        {
                            id = reader["id"].ToString(),
                            ten = reader["ten"].ToString(),
                            loai = reader["loai"].ToString(),
                            gia = Convert.ToInt32(reader["gia"]),
                            mota = reader["mota"].ToString(),
                            brand = reader["brand"].ToString(),
                            img = reader["img"].ToString()


                        });
                    }
                }
            }
            return list;
        }
        public void AddtoCart(string id, string sl, string name)
        {
            var count = Convert.ToInt32(sl);
            var flag = "";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select sl from cart where id_sp='" + id+"' and id_user='"+name+"'", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        flag = reader["sl"].ToString();
                    }
                }
                if (flag == "") {
                    MySqlCommand insert = new MySqlCommand("INSERT INTO cart(id_user, sl,id_sp) VALUES ('" + name + "'," + count + ",'" + id + "')", conn);
                    insert.ExecuteNonQuery();
                }
                else
                {
                    count = Convert.ToInt32(sl) + Convert.ToInt32(flag);
                    MySqlCommand insert = new MySqlCommand("UPDATE cart SET sl="+count+ " where id_sp='" + id + "' and id_user='" + name+"'", conn);
                    insert.ExecuteNonQuery();
                }

                
            }
        }
        


    }
}
