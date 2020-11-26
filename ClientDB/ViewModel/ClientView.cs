using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class ClientView
    {
        Client Client;
        static List<Product> listProducts;

        public static void SetProduct(List<Product> product)
        {
            listProducts = product;
        }

        public string ProductName
        {
            get
            {
                return listProducts.Find(s => s.IDProduct == Client.IdProduct).Name;//тут ловлю эксепшн, пока не разбирался почему
            }
        }

        public string FirstName { get { return Client.FirstName; } set { Client.FirstName = value; } }
        public string SurName { get { return Client.SurName; } set { Client.SurName = value; } }
        public string LastName { get { return Client.LastName; } set { Client.LastName = value; } }

        public ClientView(Client client) 
        {
            this.Client = client; 
        }
        public static explicit operator ClientView(Client client) 
        {
            return new ClientView(client); 
        } 
        public static explicit operator Client(ClientView clientView)
        {
            return clientView.Client;
        }
    }
}
