using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi9.Classes;
using VuQuangLinh_BT_Buoi9.ValidationAndNotification;

namespace VuQuangLinh_BT_Buoi9.RunExercises
{
    public class Bai1
    {
        PushNotification notify = new PushNotification();
        ValidationData validate = new ValidationData();
        ProductManger listProduct;
        internal void RunExercise1()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuExercise1();
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    notify.returnMsg = "Dữ liệu nhập vào phải là số và không được bỏ trống!";
                    Console.WriteLine(notify.returnMsg);
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            ImportListProduct();
                            Console.WriteLine();
                            break;
                        case 2:
                            if (listProduct == null)
                                break;
                            SearchByDiscountType();
                            Console.WriteLine();
                            break;
                        case 3:
                            if (listProduct == null)
                                break;
                            SearchByName();
                            Console.WriteLine();
                            break;
                        case 4:
                            if (listProduct == null)
                                break;
                            DisplayListProduct();
                            Console.WriteLine();
                            break;
                        case 5:
                            if (listProduct == null)
                                break;
                            ArrangeDecrease();
                            notify.returnMsg = "Đã sắp xếp thành công!";
                            Console.WriteLine(notify.returnMsg);
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        internal void MenuExercise1()
        {
            Console.WriteLine("\n-----Quản Lý Sản Phẩm-----");
            Console.WriteLine("1. Nhập danh sách sản phẩm");
            Console.WriteLine("2. Tìm kiếm sản phẩm theo loại chiết khấu");
            Console.WriteLine("3. Tìm kiếm sản phẩm theo tên");
            Console.WriteLine("4. Hiển thị danh sách sản phẩm");
            Console.WriteLine("5. Sắp xếp sản phẩm theo giá trị chiết khấu giảm dần");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        internal void ImportListProduct()
        {
            int capacity = 0;
            bool flag = false;
            do
            {
                Console.WriteLine("Nhập vào số lượng sản phẩm: ");
                try
                {
                    capacity = Int32.Parse(Console.ReadLine());
                    flag = true;
                }
                catch
                {
                    notify.returnMsg = "Dữ liệu nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!flag);

            // Khởi tạo danh sách sản phẩm
            listProduct = new ProductManger(capacity);

            for (int i = 0; i < capacity; i++)
            {
                Console.WriteLine("\nNhập thông tin sản phẩm thứ " + (i + 1));
                Product new_product = ImportProduct();
                listProduct.Insert(new_product);
            }
        }
        internal Product ImportProduct()
        {
            string name;
            double price = 0;
            int discountType = 0;

            bool valid = true;
            //Nhập tên sản phẩm
            do
            {
                Console.Write("Nhập tên sản phẩm: ");
                name = Console.ReadLine();
                if (validate.CheckContainSpecialChar(name) || validate.CheckIsNullOrWhiteSpace(name) || validate.ContainsNumber(name))
                {
                    notify.returnMsg = "Tên nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }    
                else
                    valid = true;
            } while (!valid);

            // Nhập giá sản phẩm
            do
            {
                Console.Write("Nhập giá sản phẩm: ");
                try
                {
                    price = Double.Parse(Console.ReadLine());
                    if (validate.CheckPrice(price))
                        valid = true;
                    else
                        valid = false;
                }
                catch
                {
                    notify.returnMsg = "Giá nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
                
            } while (!valid);

            // Nhập loại chiết khấu
            do
            {
                Console.Write("Nhập loại chiết khấu (1. Theo tiền, 2. Theo phần trăm): ");
                try
                {
                    discountType = int.Parse(Console.ReadLine());
                    if (discountType == 1 || discountType == 2)
                        valid = true;
                    else
                    {
                        notify.returnMsg = "Chỉ nhập 1 hoặc 2!";
                        Console.WriteLine(notify.returnMsg);
                        valid = false;
                    }    
                }
                catch
                {
                    notify.returnMsg = "Chỉ nhập 1 hoặc 2!";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
               
            } while (!valid);
            // Khởi tạo sản phẩm mới
            Product new_product = new Product(name, price, discountType);

            // Tính giá sau chiết khấu
            if (discountType == 1)
                new_product.PriceAfterDiscount = new_product.calculatorDiscountByMoney();
            if (discountType == 2)
            {
                double percentage;
                do
                {
                    try
                    {
                        Console.WriteLine("Nhập vào chiết khấu theo phần trăm: ");
                        percentage = double.Parse(Console.ReadLine());
                        new_product.PriceAfterDiscount = new_product.calculatorDiscountByPercentage(percentage);
                        valid = true;
                    }
                    catch
                    {
                        notify.returnMsg = "Chiết khấu nhập vào không hợp lệ";
                        Console.WriteLine(notify.returnMsg);
                        valid = false;
                    }
                } while (!valid);              
            }             
            return new_product;
        }
        public void SearchByDiscountType()
        {
            int discountType;
            Console.WriteLine("Nhập vào loại chiết khấu cần tìm (1. Theo tiền, 2. Theo phần trăm): ");
            try
            {
                discountType = Int32.Parse(Console.ReadLine());
                if (discountType == 1 || discountType == 2)  
                    listProduct.SearchByDiscountType(discountType);
            }
            catch
            {
                notify.returnMsg = "Dữ liệu không hợp lệ";
                Console.WriteLine(notify.returnMsg);
                return;
            }         
        }
        public void SearchByName()
        {
            Console.WriteLine("Nhập vào tên sản phẩm cần tìm: ");
            string name = Console.ReadLine();
            if (validate.ContainsNumber(name) || validate.CheckContainSpecialChar(name) || validate.CheckIsNullOrWhiteSpace(name))
            {
                notify.returnMsg = "Dữ liệu không hợp lệ";
                Console.WriteLine(notify.returnMsg);
                return;
            }
            else
                listProduct.SearchByName(name);
        }
        public void DisplayListProduct()
        {
            listProduct.DisplayListProduct();
        }
        public void ArrangeDecrease()
        {
            listProduct.ArrangeDecrease();
        }
    }
}
