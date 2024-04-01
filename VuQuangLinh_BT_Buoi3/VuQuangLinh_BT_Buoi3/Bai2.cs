using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai2
    {
        public void Execute(int[] array)
        {
            int[] even_array, odd_array;
            EvenAndOddArray(array, out even_array,out odd_array);

            Bai1 bai1 = new Bai1();
            Console.WriteLine("Mang gom cac so chan la: ");
            bai1.PrintArray(even_array);
            Console.WriteLine("Mang gom cac so le la: ");
            bai1.PrintArray(odd_array);
        }

        //Ham tach cac phan tu vao 2 mang chan va le
        private void EvenAndOddArray(int[] array, out int[] even_array, out int[] odd_array)
        {
            int even_length = 0, odd_length = 0;
            int even_index = 0, odd_index = 0;
            //Dem so luong phan tu chan va le
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] != 0)
                    even_length++;
                else
                    odd_length++;
            }

            even_array = new int[even_length];
            odd_array = new int[odd_length];

            //Chia cac phan tu chan va le vao 2 mang phu hop
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    even_array[even_index] = array[i];
                    even_index++;
                }
                else
                {
                    odd_array[odd_index] = array[i];
                    odd_index++;
                }
            }
        }
    }
}
