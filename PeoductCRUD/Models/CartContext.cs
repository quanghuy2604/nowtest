using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class CartContext
    {
        public string ConnectionString { get; set; }

        public CartContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Cart> GetCarts(string id_user)
        {
           
            List<Cart> list = new List<Cart>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT id_sp,ten,sl,gia,id_user,img FROM cart,sp WHERE id_sp=sp.id and id_user='"+id_user+"'", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Cart()
                        {
                            id = reader["id_sp"].ToString(),
                            id_user = reader["id_user"].ToString(),
                            sl = Convert.ToInt32(reader["sl"]),
                            ten = reader["ten"].ToString(),
                            gia = Convert.ToInt32(reader["gia"]),
                            img = reader["img"].ToString(),
                        }) ;
                    }
                }
            }
            return list;

        }
        public void XoaCart(string id, string name)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE id_sp='" + id + "' and id_user='" + name + "'", conn);
                cmd.ExecuteNonQuery();

            }
        }
        public void Tangsl(string id, string name, string sl )
        {
            var count = Convert.ToInt32(sl);
            count++;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE cart SET sl=" + count + " where id_sp='" + id + "' and id_user='" + name + "'", conn);
                cmd.ExecuteNonQuery();

            }
        }
        public void Giamsl(string id, string name,string sl)
        {
            var count = Convert.ToInt32(sl);
            
            
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                if (count == 1)
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM cart WHERE id_sp='" + id + "' and id_user='" + name + "'", conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    count--;
                    MySqlCommand cmd = new MySqlCommand("UPDATE cart SET sl=" + count + " where id_sp='" + id + "' and id_user='" + name + "'", conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
