using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ClientDB
{
    public class ViewModelProduct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void RaiseProperty([CallerMemberName] string name = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public IEnumerable<ProductView> Products 
        { 
            get
            {
                return Product.GetAllProducts().Select(s => (ProductView)s);
            }
        }

        public Commands Add { get; set; }
        public Commands Edit { get; set; }
        private Page _currentPage;
        public Page CurrentPage { get => _currentPage; set { _currentPage = value; RaiseProperty(); } }

        public ViewModelProduct()
        {
            Add = new Commands(() =>
            {
                CurrentPage = new PageAddProduct(new ViewModelProductEditor(new Product()));
                RaiseProperty(nameof(Products));
            });
            Edit = new Commands((s) =>
            {
                CurrentPage = new PageAddProduct(new ViewModelProductEditor((Product)(ProductView)s));
                RaiseProperty(nameof(Products));
            });
            
        }
    }
}
