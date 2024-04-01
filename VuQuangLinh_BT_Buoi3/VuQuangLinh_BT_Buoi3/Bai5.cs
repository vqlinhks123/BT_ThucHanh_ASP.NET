using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai5
    {
        public void Execute(int[] array)
        {
            bool controller;
            Console.WriteLine("Cac so Amstrong trong mang la: ");
            foreach (int item in array)
            {
                controller = CheckAmstrongNumber(item);
                if (controller == true)
                    Console.Write(item + " ");
            }
        }
        private int NumDigit(int num)
        {
            int count = 0;
            while (num != 0)
            {
                num /= 10;
                count++;
            }    
            return count;
        }
        private bool CheckAmstrongNumber(int num)
        {
            int surplus, exponent;
            int num_to_check = num;
            double result = 0;
            exponent = NumDigit(num_to_check);
            while (num_to_check != 0)
            {
                surplus = num_to_check % 10;
                result += Math.Pow(surplus,exponent);
                num_to_check /= 10;
            }

            if (result == num)
                return true;
            else 
                return false;
        }
    }
}
