using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string data;
            int choice, flag = 1;
            bool check_data;
            do
            {
                Console.WriteLine("\n--------- Moi ban chon 1 trong cac muc duoi day --------- ");
                Console.WriteLine("1. Bai 1");
                Console.WriteLine("2. Bai 2");
                Console.WriteLine("3. Bai 3");
                Console.WriteLine("4. Bai 4");
                Console.WriteLine("5. Bai 5");
                Console.WriteLine("6. Bai 6");
                Console.WriteLine("0. Thoat chuong trinh");
                Console.WriteLine("\nNhap lua chon cua ban: ");
                data = Console.ReadLine();
                check_data = int.TryParse(data,out choice);

                if (check_data == false)
                {
                    Console.WriteLine("Lua chon khong hop le, vui long nhap lai!");
                    continue;
                }    
                    
                switch (choice)
                {
                    case 1:
                        Bai1 bai1 = new Bai1();
                        bai1.Execute();
                        break;
                    case 2:
                        Bai2 bai2 = new Bai2();
                        bai2.Execute(); 
                        break;
                    case 3:
                        Bai3 bai3 = new Bai3();
                        bai3.Execute();
                        break;
                    case 4:
                        Bai4 bai4 = new Bai4();
                        bai4.Execute();
                        break;
                    case 5:
                        Bai5 bai5 = new Bai5();
                        bai5.Execute();
                        break;
                    case 6:
                        Bai6 bai6 = new Bai6();
                        bai6.Execute();
                        break;
                    case 0: 
                        flag = 0; ; break;
                    default: 
                        Console.WriteLine("Lua chon khong hop le, vui long nhap lai!"); break;
                }
            } while (flag != 0);
            Console.ReadKey();
        }
    }
}
