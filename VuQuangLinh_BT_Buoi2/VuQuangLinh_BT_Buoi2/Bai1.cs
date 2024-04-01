using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Bai1
    {
        public void Execute()
        {
            int num;
            string data;
            bool check_data;
            do
            {
                Console.WriteLine("\nNhap vao mot so nguyen tu ban phim: ");
                data = Console.ReadLine();
                check_data = int.TryParse(data, out num);
                if (num < 2 || check_data == false)
                    Console.WriteLine("Du lieu khong hop le, vui long nhap lai!");
            } while (num < 2 || check_data == false);

            if (check_data == true)
            {
                Console.WriteLine("Cac so nguyen to nho hon " + num + " la: ");

                for (int i = 2; i < num; i++)
                {
                    if (CheckPrimeNumber(i) == true)
                    {
                        Console.Write(i + " ");
                    }
                }
                Console.WriteLine(" ");
            }             
        }

        private bool CheckPrimeNumber(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}
