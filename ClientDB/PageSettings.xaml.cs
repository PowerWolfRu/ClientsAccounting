using Microsoft.Win32;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientDB
{
    /// <summary>
    /// Логика взаимодействия для PageSettings.xaml
    /// </summary>
    public partial class PageSettings : Page
    {
        
        public PageSettings(ViewModelSettings settings)
        {
            InitializeComponent();
            DataContext = settings;
        }

        private void ResultClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
