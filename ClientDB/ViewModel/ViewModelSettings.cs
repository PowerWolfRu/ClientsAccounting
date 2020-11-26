using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class ViewModelSettings : DB
    {
        public string Ip { get { return Properties.Settings.Default.ip; } set { Properties.Settings.Default.ip = value; } }
        public string Name { get { return Properties.Settings.Default.name; } set { Properties.Settings.Default.name = value; } }
        public string Login { get { return Properties.Settings.Default.login; } set { Properties.Settings.Default.login = value; } }
        public string Password { get { return Properties.Settings.Default.password; } set { Properties.Settings.Default.password = value; } }

        public Commands SaveSettings { get; set; }
        public ViewModelSettings()
        {
            SaveSettings = new Commands(() =>
            {
                Properties.Settings.Default.Save();
                MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
                stringBuilder.Database = Properties.Settings.Default.name;
                stringBuilder.UserID = Properties.Settings.Default.login;
                stringBuilder.Password = Properties.Settings.Default.password;
                stringBuilder.Server = Properties.Settings.Default.ip;
                connection = new MySqlConnection(stringBuilder.ToString());
            });
        }
    }
}
