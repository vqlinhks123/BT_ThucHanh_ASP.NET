using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi2
{
    internal class Bai6
    {
        public void Execute()
        {
            string password;
            bool checkPass;
            do
            {
                Console.WriteLine("\nNhap vao mat khau cua ban (6-12 ki tu va phai co ki tu @): ");
                password = Console.ReadLine();
                checkPass = CheckPassword(password);
                if (checkPass == false)
                    Console.WriteLine("Mat khau nhap vao khong hop le, vui long nhap lai!");
                else
                    Console.WriteLine("OK, mat khau hop le!");
            } while (checkPass != true);          
            Console.ReadKey(); 
        }

        private bool CheckPassword(string pwd)
        {
            //if (pwd == null)
            //{
            //    Console.WriteLine("Ban chua nhap mat khau");
            //    return false;
            //}
            bool checkAtSign = false;
            int temp = 0;          
            do
            {
                if (pwd[temp] == '@')
                    checkAtSign = true;
                temp++;
            } while (temp<pwd.Length);

            if (pwd.Length < 6)
            {
                Console.WriteLine("Mat khau cua ban qua ngan!");    
                return false;
            }
            else if (pwd.Length > 12)
            {
                Console.WriteLine("Mat khau cua ban qua dai!");
                return false;
            }
            else if (checkAtSign == false)
            {
                Console.WriteLine("Ban chua co ki tu @");
                return false;
            }
            else
                return true;
        }
    }
}
