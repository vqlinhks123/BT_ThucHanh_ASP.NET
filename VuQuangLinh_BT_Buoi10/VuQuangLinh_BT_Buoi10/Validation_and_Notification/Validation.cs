using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi10.Validation_and_Notification
{
    internal class Validation
    {
        public bool ContainsNumber(string input)
        {
            if (input.Any(char.IsDigit))
                return true;
            else
                return false;
        }
        public bool CheckContainSpecialChar(string input)
        {
            Regex specialCharRegex = new Regex(@"[~`!@#$%^&*()+=|\\{}':;,.<>?/""-]");
            if (specialCharRegex.IsMatch(input))
                return true;
            else
                return false;
        }
        public bool CheckIsNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return true;
            else
                return false;
        }
        public bool ContainsLetter(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                    return true;
            }
            return false;
        }
        public bool CheckPrice(double input)
        {
            if (input <= 0)
                return false;
            else
                return true;
        }
        public bool CheckDay(DateTime input)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - input;
            if (interval.Days >= 0)
                return true;
            else
                return false;
        }
        public bool CheckBirthday(DateTime input)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - input;
            if (interval.Days > 0)
            {
                if (now.Year - input.Year >= 16)
                    return true;
                else
                    return false;
            }    
            else
                return false;
        }
        public bool CheckRetrieveDay(DateTime input)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - input;
            if (interval.Days < 0)
                return true;
            else
                return false;
        }
        public bool CheckFullRoom(int input)
        {
            if (input == 15)
                return true;
            else return false;
        }
        public bool CheckIDRoom(int input)
        {
            if (input <= 0 || input > 15)
                return false;
            else return true;
        }
    }
}
