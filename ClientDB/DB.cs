using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClientDB
{
    public class DB
    {
        
        static protected MySqlConnection connection;
        
        static DB()
        {
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
            stringBuilder.Server = Properties.Settings.Default.ip;
            stringBuilder.Database = Properties.Settings.Default.name;
            stringBuilder.UserID = Properties.Settings.Default.login;
            stringBuilder.Password = Properties.Settings.Default.password;
            stringBuilder.CharacterSet = "utf8";
            connection = new MySqlConnection(stringBuilder.ToString());
        }

        public static bool OpenConnection()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public static void Query(string query)
        {
            if(OpenConnection())
            {
                using (var mc = new MySqlCommand(query, connection))
                    mc.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
