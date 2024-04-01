using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Bai4
    {
        public void Execute()
        {
            uint num;
            string data;
            bool check_data;
            do
            {
                Console.WriteLine("\nNhap vao mot so nguyen tu ban phim: ");
                data = Console.ReadLine();
                check_data = uint.TryParse(data, out num);
                if (check_data == false)
                    Console.WriteLine("Du lieu khong hop le, vui long nhap lai!");
            } while (check_data == false);

            Console.WriteLine("Giai thua cua " + num + " la: " + CalculateFactorial(num));
            Console.ReadKey();
        }
        private ulong CalculateFactorial(uint num)
        {
            ulong result = 1;
            uint temp = 1;
            do
            {
                result *= temp;
                temp++;
            } while (temp <= num);
            return result;
        }
       
    }
}
