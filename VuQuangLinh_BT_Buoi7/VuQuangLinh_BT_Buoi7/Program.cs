using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = false;
            int choice;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n-----Lựa chọn chức năng dưới đây-----");
                Console.WriteLine("1. Bài 1");
                Console.WriteLine("2. Bài 2");
                Console.WriteLine("2. Bài 3");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            Bai1 bai1 = new Bai1();
                            bai1.ThucThiBai1();
                            break;
                        case 2:
                            Bai2 bai2 = new Bai2();
                            bai2.ThucThiBai2();
                            break;
                        case 3:
                            Bai3 bai3 = new Bai3();
                            bai3.ThucThiBai3();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
            Console.ReadKey();
        }
    }
}
