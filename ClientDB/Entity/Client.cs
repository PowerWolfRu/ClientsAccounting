using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class Client : DB
    {
        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public int IdProduct { get; set; }

        public void AddClient()
        {
            string add = "INSERT INTO `client_table` (`id`, `fname`, `sname`, `lname`, `id_product`) VALUES (0, '" + FirstName + "', '" + SurName + "', '" + LastName + "',"+IdProduct+");";
            Query(add);
        }
        public void UpdateClient()
        {
            string update = "UPDATE client_table SET fname = '"+FirstName+"', sname = '"+SurName+"', lname = '"+LastName+"', id_product = "+IdProduct+" WHERE id = "+IdClient+";";
            Query(update);
        }

        public static List<Client> GetAllClients()
        {
            List<Client> array = new List<Client>();
            string sql = "SELECT * FROM `client_table`;";
            if(OpenConnection())
            {
                using(var mc = new MySqlCommand(sql, connection))
                using (MySqlDataReader dr = mc.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        array.Add(new Client
                        { 
                            IdClient = dr.GetInt32(0),
                            FirstName = dr.GetString(1),
                            SurName = dr.GetString(2), 
                            LastName = dr.GetString(3),
                            IdProduct = dr.GetInt32(4)
                        });
                    }
                }
                CloseConnection();
            }
            return array;
        }
    }
}
