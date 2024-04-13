using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi7
{
    public class CheckInput
    {
        public bool ContainsNumber(string input)
        {
            if (input.Any(char.IsDigit))
            {
                Console.WriteLine("Không được chứa chữ số!");
                return true;
            }
            else
                return false;
        }
        public bool CheckContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            if (specialCharRegex.IsMatch(input))
            {
                Console.WriteLine("Không được chứa kí tự đặc biệt!");
                return true;
            }
            else
                return false;
        }
        public bool CheckIsNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Không được để trống hay chỉ chứa khoảng trắng!");
                return true;
            }
            else
                return false;
        }
        public bool ContainsLetter(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    Console.WriteLine("Không được chứa kí tự chữ!");
                    return true;
                }                      
            }
            return false;
        }
    }
}
