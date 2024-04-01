using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai1
    {
        public void Execute(out int[] array)
        {
            string data;
            int length;
            bool check_data = false, flag = false;
            //Nhap kich thuoc cua mang
            do
            {
                Console.WriteLine("\nNhap vao so phan tu cua mang: ");
                data = Console.ReadLine();
                check_data = Int32.TryParse(data, out length);
                if (length < 1 || check_data == false)
                    Console.WriteLine("Du lieu nhap vao khong hop le, hay nhap lai!");
                else
                    flag = true;
            } while (flag != true);
            //Nhap mang
            InputArray(out array, length);
            //In ra mang
            Console.WriteLine("\nMang vua nhap la: ");
            PrintArray(array);
        }

        //Ham nhap mang
        private void InputArray(out int[] array, int length)
        {
            array = new int[length];
            string data;
            bool check_input;
            for (int i = 0; i < length; i++)
            {
                do
                {
                    Console.Write("Nhap phan tu thu " + (i + 1) + ": ");
                    try
                    {
                        check_input = true;
                        array[i] = Int32.Parse(Console.ReadLine());
                    }
                    catch (FormatException e1)
                    {
                        Console.Error.WriteLine("Du lieu nhap vao chua dung! " + e1.Message);
                        check_input = false;
                    }
                } while (!check_input);                            
            }    
        }

        //Ham in ra mang
        public void PrintArray(int[] array)
        {
            foreach (int item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}
