using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class ViewModelProductEditor
    {
        Product product;

        public string Name { get { return product.Name; } set { product.Name = value.Replace("'", ""); } }
        public int Price { get { return product.Price; } set { product.Price = value; } }
        public int Count { get { return product.Count; } set { product.Count = value; } }


        public Commands Save { get; set; }

        public ViewModelProductEditor(Product product)
        {
            this.product = product;
            Save = new Commands(() =>
            {
                if (Name == null || Name == "")
                {
                    System.Windows.MessageBox.Show("Пожалуйста заполните поля");
                    return;
                }
                else
                {
                    if (product.IDProduct == 0)
                        product.AddProduct();
                    else
                        product.UpdateProduct();
                }
            });
        }
    }
}
