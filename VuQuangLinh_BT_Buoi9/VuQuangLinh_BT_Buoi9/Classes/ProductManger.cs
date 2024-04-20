using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    internal class ProductManger
    {
        List<Product> listProduct;
       
        public ProductManger(int size)
        {
            listProduct = new List<Product>(size);
        }
        public Product getProduct(int index)
        {
            return listProduct[index];
        }
        public int Count()
        {
            return (int)listProduct.Count;
        }
        public void Insert(Product product)
        {
            listProduct.Add(product);
        }
        public void SearchByName(string productName)
        {
            foreach (Product product in listProduct)
            {
                if (product.Name == productName)
                    product.Display();
            }
        }
        public void SearchByDiscountType(int discountType)
        {
            foreach (Product product in listProduct)
            {
                if (product.DiscountType == discountType)
                    product.Display();
            }
        }
        internal void DisplayListProduct()
        {
            foreach (Product product in listProduct)
            {
                product.Display();
            }
        }
        internal void ArrangeDecrease()
        {
                listProduct.Sort((x,y) => y.PriceAfterDiscount.CompareTo(x.PriceAfterDiscount));    
        }
    }
}
