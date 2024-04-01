using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai7
    {
        public void Execute(int[] array)
        {
            int sum_of_even = 0;
            int sum_of_odd = 0;
            SumOfEvenOrOddNumber(array, ref sum_of_even, ref sum_of_odd);
            Console.WriteLine("Tong cua cac so chan trong mang la: " + sum_of_even);
            Console.WriteLine("Tong cua cac so le trong mang la: " + sum_of_odd);
        }

        private void SumOfEvenOrOddNumber(int[] array, ref int sum_of_even, ref int sum_of_odd)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    sum_of_even += array[i];
                else
                    sum_of_odd += array[i];
            }
        }
    }
}
