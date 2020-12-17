using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class LoginContext
    {
        public string ConnectionString { get; set; }

        public LoginContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public Account Login(string user, string pass)
        {
            Account list = new Account();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from login where username='" + user + "' and passwork='" + pass + "'", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = (new Account()
                        {
                            user = reader["username"].ToString(),
                            Ten = reader["ten"].ToString()
                        });

                    }
                }
            }
            return list;
        }
        public void SignUp(Account account)
        {
           
        }
    }
}
