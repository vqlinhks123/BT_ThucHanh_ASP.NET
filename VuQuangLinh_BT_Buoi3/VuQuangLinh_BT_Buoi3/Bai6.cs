using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai6
    {
        public void Execute(int[] array)
        {
            Console.WriteLine("Cac so nguyen to co trong mang la: ");
            PrintPrimeNumber(array);
            int sum_of_prime_number = SumOfPrimeNumber(array);
            Console.WriteLine("\nTong cua cac so nguyen to co trong mang la: " + sum_of_prime_number);
        }
        private void PrintPrimeNumber(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (CheckPrimeNumber(array[i]) == true)
                    Console.Write(array[i] + " ");
            }
        }
        private int SumOfPrimeNumber(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length ;i++)
            {
                if (CheckPrimeNumber(array[i]) == true)
                    sum += array[i];
            }
            return sum;
        }
        private bool CheckPrimeNumber(int num)
        {
            if (num < 2)
                return false;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}
