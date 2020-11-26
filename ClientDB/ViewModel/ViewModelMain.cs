using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClientDB
{
    public class ViewModelMain : INotifyPropertyChanged
    {
        private Page currentPage;
        public Commands OpenAddClient { get; set; }
        public Commands OpenListClient { get; set; }
        public Commands OpenAddProduct { get; set; }
        public Commands OpenListProduct { get; set; }
        public Commands OpenAddService { get; set; }
        public Commands OpenListService { get; set; }
        public Commands OpenSettings { get; set; }
        public Commands EditProduct { get; set; }
        public Page CurrentPage { get => currentPage; set { currentPage = value;  RaiseProperty(); } }
        public ViewModelMain()
        {
            
            OpenAddClient = new Commands(() =>
            {
                CurrentPage = new PageAddClients(new ViewModelClientEditor(new Client()));
            });
            OpenListClient = new Commands(() => 
            {
                CurrentPage = new PageClientList(new ViewModelClient());
                R();
            });
            OpenAddProduct = new Commands(() => 
            {
                CurrentPage = new PageAddProduct(new ViewModelProductEditor(new Product()));
                R();
            });
            OpenListProduct = new Commands(() =>
            {
                CurrentPage = new PageListProduct(new ViewModelProduct());
                R();
            });
            OpenSettings = new Commands(() => 
            {
                CurrentPage = new PageSettings(new ViewModelSettings());
                R();
            });
        }

        public List<Product> Products { get { return Product.GetAllProducts(); } }
        public List<Client> Clients { get { return Client.GetAllClients(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty([CallerMemberName] string prop = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        void R()
        {
            RaiseProperty(nameof(Products));
            RaiseProperty(nameof(Clients));
        }
    }
}
