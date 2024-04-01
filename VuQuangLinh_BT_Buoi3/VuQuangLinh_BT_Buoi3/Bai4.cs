using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai4
    {
        public void Execute(int[] array)
        {
            Console.WriteLine("Tong cua cac so chan trong mang la: " + SumOfEven(array));
            Console.WriteLine("Tong cua cac so le trong mang la: " + SumOfOdd(array));
        }

        private int SumOfEven(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                    result += array[i];
            }
            return result;
        }

        private int SumOfOdd(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                    result += array[i];
            }
            return result;
        }
    }
}
