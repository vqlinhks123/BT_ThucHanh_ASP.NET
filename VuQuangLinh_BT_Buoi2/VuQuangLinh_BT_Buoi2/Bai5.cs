using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Bai5
    {
        public void Execute()
        {
            GuessRandom();
            Console.ReadKey(); 
        }
        private void GuessRandom()
        {
            int num;
            string data;
            bool check_data;
            Random rand = new Random();
            do
            {
                Console.WriteLine("\nNhap vao mot so nguyen tu ban phim (tu 0 den 9): ");
                data = Console.ReadLine();
                check_data = int.TryParse(data, out num);
                if (num < 0 || num > 9 || check_data == false)
                    Console.WriteLine("Du lieu khong hop le, vui long nhap lai!");
                else
                {
                    if (rand.Next(10) == num)
                    {

                        Console.WriteLine("Chuc mung ban da doan dung!");
                    }
                    else
                        Console.WriteLine("Rat tiec ban doan sai roi, doan lai nhe!");
                }
            } while (check_data == false);
        }
    }
}
