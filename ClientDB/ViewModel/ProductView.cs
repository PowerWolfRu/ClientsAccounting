using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDB
{
    public class ProductView
    {
        Product product;

        public string Name { get { return product.Name; } set { product.Name = value; } }
        public int Price
        {
            get
            {
                return product.Price;
            }
            set
            {
                product.Price = value;
            }
        }
        public int Count { get { return product.Count; } set { product.Count = value; } }


        public ProductView(Product product)
        {
            this.product = product;
        }

        public static explicit operator ProductView(Product product)
        {
            return new ProductView(product);
        }

        public static explicit operator Product(ProductView product)
        {
            return product.product;
        }
    }
}
