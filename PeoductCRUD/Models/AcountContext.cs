using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeoductCRUD.Models
{
    public class AcountContext
    {
        public string ConnectionString { get; set; }
        public string Ten { get; private set; }

        public AcountContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public bool SignUp(Account account)
        {
            using (MySqlConnection conn = GetConnection())
            {
                string flag = "";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select username from login where username='"+account.user+ "'", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        flag = reader["username"].ToString();
                    }
                }
                

                if (flag != "")
                {
                    return false;
                }
                MySqlCommand tao = new MySqlCommand("INSERT INTO login(username, passwork, ten, email, dia_chi, sdt) VALUES('"+account.user+"', '"+account.pass+"', '"+account.Ten+"', '"+account.Email+"', '"+account.dia_chi+"', '"+account.sdt+"')", conn);
                tao.ExecuteNonQuery();
            }
            return true;

        }
    }
}
