using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class Product : DB
    {
        public int IDProduct { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public void AddProduct()
        {
            string add = "INSERT INTO `product_table` (`id_prod`, `name`, `price`, `count`) VALUES (0, '" + Name + "', " + Price + ", "+Count+");";
            Query(add);
        }

        public void UpdateProduct()
        {
            string add = "UPDATE product_table SET name = '"+Name+"', price = "+Price+", count ="+Count+" WHERE id_prod = "+IDProduct+";";
            Query(add);
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> array = new List<Product>();
            string sql = "SELECT * FROM `product_table`";
            if(OpenConnection())
            {
                using(var mc = new MySqlCommand(sql, connection))
                {
                    using(MySqlDataReader dr = mc.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            array.Add(new Product
                            {
                                IDProduct = dr.GetInt32(0),
                                Name = dr.GetString(1),
                                Count = dr.GetInt32(2)
                            });
                        }
                    }
                }
                CloseConnection();
            }
            return array;
        }
    }
}
