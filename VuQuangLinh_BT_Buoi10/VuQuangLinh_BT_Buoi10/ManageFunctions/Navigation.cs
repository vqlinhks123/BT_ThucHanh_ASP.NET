using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.Implement;

namespace VuQuangLinh_BT_Buoi10.ManageFunctions
{
    internal class Navigation
    {
        ManageBookingAndPayment manageBooking = new ManageBookingAndPayment();
        ImplementIRoom manageRoom = new ImplementIRoom();
        // Menu quản lí phòng
        public void MenuManageRoom()
        {
            Console.WriteLine("\n-----Quản Lý Danh Sách Phòng (tổng 15 phòng)-----");
            Console.WriteLine("1. Thêm phòng");
            Console.WriteLine("2. Xóa phòng");
            Console.WriteLine("3. Kiểm tra danh sách các phòng");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }

        // Menu quản lí đặt phòng
        public void MenuManageBooking()
        {
            Console.WriteLine("\n-----Quản Lý Đặt Phòng-----");
            Console.WriteLine("1. Thêm thông tin đặt phòng");
            Console.WriteLine("2. Hủy đặt phòng");
            Console.WriteLine("3. Xem danh sách thông tin đặt phòng");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }

        // Quản lí danh sách phòng
        public void ManageRoomFunction()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuManageRoom();
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
                            manageRoom.AddRoom();
                            break;
                        case 2:
                            manageRoom.RemoveRoom();    
                            break;
                        case 3:
                            manageRoom.CheckListRoom();  
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }

        // Quản lí thông tin đặt phòng
        public void ManageBookingFunction()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuManageBooking();
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
                            manageBooking.AddBooking();
                            break;
                        case 2:
                            manageBooking.RemoveBooking();
                            break;
                        case 3:
                            manageBooking.DisplayListBooking();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }

        // Thanh toán
        public void Payment()
        {

        }

        // Hủy đặt phòng
        public void DiscardBooking()
        {

        }

        // Xem lịch sử đặt phòng
        public void ViewBookingHistory()
        {

        }
    }
}
