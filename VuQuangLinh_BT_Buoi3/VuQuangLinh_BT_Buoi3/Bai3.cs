using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi3
{
    internal class Bai3
    {
        public void Execute(int[] array)
        {
            int[] temp_array = array;
            Bai1 bai1 = new Bai1();

            QuickSortIncrease(temp_array, 0, temp_array.Length - 1); //sap xep tang dan
            Console.WriteLine("Mang tang dan sau khi sap xep la: ");
            bai1.PrintArray(temp_array);

            QuickSortDecrease(temp_array, 0, temp_array.Length - 1); //sap xep giam dan
            Console.WriteLine("Mang giam dan sau khi sap xep la: ");
            bai1.PrintArray(temp_array);
        }

        private void QuickSortIncrease(int[] array, int low, int high) //ham sap xep tang dan
        {
            if (low < high)
            {
                int index = PartitionIncrease(ref array, low, high); //index la phan tu chia mang lam 2 mang con trai va phai
                QuickSortIncrease(array, low, index-1);
                QuickSortIncrease(array, index+1, high);
            }
        }

        private void QuickSortDecrease(int[] array, int low, int high) //ham sap xep giam dan
        {
            if (low < high)
            {
                int index = PartitionDecrease(ref array, low, high); //index la phan tu chia mang lam 2 mang con trai va phai
                QuickSortDecrease(array, low, index - 1);
                QuickSortDecrease(array, index + 1, high);
            }
        }
        private int PartitionIncrease(ref int[] array, int low, int high) //ham phan doan tang dan
        { 
            int pivot = array[high];
            int left = low;
            int right = high - 1;
            while (true)
            {
                while (left <= right && array[left] < pivot)
                    left++;
                while (right >= left && array[right] > pivot)
                    right--;
                if (left >= right)
                    break;
                Swap(ref array[left],ref array[right]);
                left++;
                right--;
            }
            Swap(ref array[left],ref array[high]);
            return left;
        }
        private int PartitionDecrease(ref int[] array, int low, int high) //ham phan doan giam dan
        {
            int pivot = array[high];
            int left = low;
            int right = high - 1;
            while (true)
            {
                while (left <= right && array[left] > pivot)
                    left++;
                while (right >= left && array[right] < pivot)
                    right--;
                if (left >= right)
                    break;
                Swap(ref array[left], ref array[right]);
                left++;
                right--;
            }
            Swap(ref array[left], ref array[high]);
            return left;
        }
        private void Swap(ref int num1,ref int num2)
        {
            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }
}
