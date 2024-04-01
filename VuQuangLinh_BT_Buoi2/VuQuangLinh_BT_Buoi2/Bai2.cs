using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Bai2
    {
        public void Execute()
        {
            string data;
            Console.WriteLine("\nNhap vao mot chuoi tu ban phim: ");
            data = Console.ReadLine();
            data = ReverseString(data);
            Console.WriteLine("Chuoi sau khi dao nguoc la: " + data);
        }
        private string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            char temp;
            for (int i = 0; i < chars.Length/2; i++) 
            { 
                temp = chars[i];
                chars[i] = chars[chars.Length - i - 1];
                chars[chars.Length - i - 1] = temp;
            }
            str = new string(chars);
            return str;
        }
    }
}
