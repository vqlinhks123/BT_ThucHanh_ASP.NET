using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int DiscountType { get; set; }
        public double PriceAfterDiscount { get; set; }
        public string returnDiscountType()
        {
            string str1 = "Theo tiền";
            string str2 = "Theo phần trăm";
            if (DiscountType == 1)
                return str1;
            else
                return str2;
        }
        public double calculatorDiscountByMoney()
        {
            double discount = 0;
            if (Price >= 10000)
                discount = 1000;
            if (Price >= 100000)
                discount = 10000;
            if (Price >= 1000000)
                discount = 100000;
            return Price - discount;
        }
        public double calculatorDiscountByPercentage(double percentage_discount)
        {
            return Price - (percentage_discount/100) * Price;
        }

        public Product(string name, double price, int discountType)
        {
            Name = name;
            Price = price;
            DiscountType = discountType;
        }
        public void Display()
        {

            Console.WriteLine($"Tên sản phẩm: {Name}, Giá: {Price}, Loại chiết khấu: {returnDiscountType()}, Giá sau chiết khấu: {PriceAfterDiscount}");
        }
    }
}
