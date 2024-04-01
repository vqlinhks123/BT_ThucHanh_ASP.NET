using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Bai3
    {
        public void Execute()
        {
            string data;
            string c;
            int num_occurences;

            do
            {
                Console.WriteLine("\nMoi ban nhap vao mot chuoi: ");
                data = Console.ReadLine();
                Console.WriteLine("Hay nhap vao mot ki tu: ");
                c = Console.ReadLine();
                if (c.Length > 1)
                    Console.WriteLine("Du lieu khong hop le, vui long nhap lai!");
            } while (c.Length > 1);
            
            num_occurences = CountOccurences(data,c);
            Console.WriteLine("So lan ki tu " + c + " xuat hien la: " + num_occurences);
        }
        private int CountOccurences(string str,string c)
        {
            int count = 0;
            for (int i = 0; i<str.Length; i++)
            {
                if (str[i] == c[0])
                    count++;
            }
            return count;
        }
    }
}
