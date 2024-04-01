using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static VuQuangLinh_BT_Buoi4.Bai1;

namespace VuQuangLinh_BT_Buoi4
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            bool valid = false;
            int choice = -1;
            do
            {
                Console.WriteLine("\n-------- Hay chon chuc nang duoi day --------");
                Console.WriteLine("1. Thuc hien bai 1");
                Console.WriteLine("2. Thuc hien bai 2");
                Console.WriteLine("3. Thuc hien bai 3");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Nhap lua chon: ");

                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message); valid = false;
                }

                switch(choice)
                {
                    case 0: Console.WriteLine("Ket thuc chuong trinh!"); valid = true; break;
                    case 1: 
                        Console.WriteLine("\nQuan ly thong tin Sach"); 
                        Bai1 bai1 = new Bai1();
                        bai1.ExecuteTask1();
                        break;
                    case 2: 
                        Console.WriteLine("\nQuan ly thong tin Hoc Sinh");
                        Bai2 bai2 = new Bai2();
                        bai2.ExecuteTask2();
                        break;
                    case 3: 
                        Console.WriteLine("\nQuan ly thong tin Hoa Don"); 
                        Bai3 bai3 = new Bai3();
                        bai3.ExecuteTask3();
                        break;
                    default: Console.WriteLine("Lua chon chua dung, moi ban nhap lai!"); valid = false; break;
                }
            } while (!valid);
            Console.ReadKey();
        }
    }
}
