using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientDB
{
    public class ViewModelClient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseProperty([CallerMemberName] string name = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public IEnumerable<ClientView> Clients
        {
            get
            {
                return Client.GetAllClients().Select(s => (ClientView)s);
            }
        }

        public Commands Edit { get; set; }
        private Page _currentPage;
        public Page CurrentPage { get => _currentPage; set { _currentPage = value; RaiseProperty(); } }

        public ViewModelClient()
        {
            Edit = new Commands((s) => 
            {
                CurrentPage = new PageAddClients(new ViewModelClientEditor((Client)(ClientView)s));             
            });
        }
    }
}
