using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class ViewModelClientEditor
    {
        Client Client;
        public string FirstName { get { return Client.FirstName; } set { Client.FirstName = value.Replace("'", ""); } }
        public string SurName { get { return Client.SurName; } set { Client.SurName = value.Replace("'", ""); } }
        public string LastName { get { return Client.LastName; } set { Client.LastName = value.Replace("'", ""); } }
         
        public IEnumerable<ClientView> Clients
        {
            get
            {
                return Client.GetAllClients().Select(s => (ClientView)s);
            }
        }

        public List<Product> Products { get; set; }
        public Product ProductName
        {
            get { return Products.Find(s => s.IDProduct == Client.IdProduct); }
            set
            {
                Client.IdProduct = ((Product)value).IDProduct;
            }
        }

        public Commands SaveClient { get; set; }
        public ViewModelClientEditor(Client client)
        {
            this.Client = client;
            Products = Product.GetAllProducts();
            SaveClient = new Commands(() =>
            {
                if (FirstName == null || FirstName == "" || SurName == null || SurName == "" || LastName == null || LastName == "")
                {
                    System.Windows.MessageBox.Show("Пожалуйста, заполните поля корректно");
                    return;
                }
                else
                {
                    if (Client.IdClient == 0)
                        client.AddClient();
                    else
                        client.UpdateClient();
                }
            });
        }
    }
}
