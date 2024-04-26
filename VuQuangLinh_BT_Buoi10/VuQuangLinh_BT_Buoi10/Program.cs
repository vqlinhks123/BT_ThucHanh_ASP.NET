using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.ManageFunctions;

namespace VuQuangLinh_BT_Buoi10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Navigation navigation = new Navigation();
            bool flag = false;
            int choice;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n-----Lựa chọn chức năng dưới đây-----");
                Console.WriteLine("1. Quản lý danh sách phòng và loại phòng");
                Console.WriteLine("2. Quản lý thông tin đặt phòng của khách hàng");
                Console.WriteLine("3. Thực hiện thanh toán");
                Console.WriteLine("4. Xem lịch sử đặt phòng của khách hàng");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Dữ liệu nhập vào phải là số nguyên và không được bỏ trống!");
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            navigation.ManageRoomFunction();                        
                            break;
                        case 2:
                            navigation.ManageBookingFunction();
                            break;
                        case 3:
                            navigation.ManagePayment();
                            break;
                        case 4:
                            navigation.ViewBookingHistory();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
            Console.ReadKey();
        }
    }
}
