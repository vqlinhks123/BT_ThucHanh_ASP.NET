using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.DataObject;
using VuQuangLinh_BT_Buoi10.Implement;
using VuQuangLinh_BT_Buoi10.Validation_and_Notification;

namespace VuQuangLinh_BT_Buoi10.ManageFunctions
{
    internal class ManageRoomsAndBooking
    {
        Notification notify = new Notification();
        Validation validate = new Validation();
        List<ImplementBooking> listBooking = new List<ImplementBooking>();
        ImplementIRoom manageRoom = new ImplementIRoom();
        ImplementICustomer manageCustomer = new ImplementICustomer();

        // Nhập thông tin đặt phòng
        public ImplementBooking InputBookingData()
        {
            Customer new_customer = manageCustomer.InputCustomer();
            Room new_room = manageRoom.InputRoomToBook();
            string booking_day;
            DateTime BookingDay = new DateTime();
            string retrieve_day; ;
            DateTime RetrieveDay = new DateTime();
            bool valid = false;

            // Nhập ngày nhận phòng
            do
            {
                Console.Write("Nhập ngày nhận phòng (dd/mm/yyyy): ");
                booking_day = Console.ReadLine();
                try
                {
                    BookingDay = DateTime.ParseExact(booking_day, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (validate.CheckBookingOrRetrieveDay(BookingDay))
                        valid = true;
                    else
                    {
                        valid = false;
                        notify.returnMsg = "Ngày nhận phòng không nhỏ hơn thời gian hiện tại!";
                        Console.WriteLine(notify.returnMsg);
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Định dạng ngày không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Nhập ngày trả phòng
            do
            {
                Console.Write("Nhập ngày trả phòng (dd/mm/yyyy): ");
                retrieve_day = Console.ReadLine();
                try
                {
                    RetrieveDay = DateTime.ParseExact(retrieve_day, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (validate.CheckBookingOrRetrieveDay(RetrieveDay))
                    {
                        TimeSpan interval = RetrieveDay - BookingDay;
                        if (interval.Days >= 0)
                            valid = true;
                        else
                        {
                            valid = false;
                            notify.returnMsg = "Ngày trả phòng không nhỏ hơn ngày nhận phòng!";
                            Console.WriteLine(notify.returnMsg);
                        }
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Định dạng ngày không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Khởi tạo thông tin đặt phòng
            ImplementBooking booking = new ImplementBooking(new_customer, new_room, BookingDay, RetrieveDay);
            // Update lại trạng thái phòng đã đặt
            manageRoom.UpdateRoomStatus(new_room.ID,false);
            return booking;
        }

        public void AddBooking()
        {
            ImplementBooking new_booking = InputBookingData();
            listBooking.Add(new_booking);
            notify.returnMsg = "Đặt phòng thành công!";
            Console.WriteLine(notify.returnMsg);
        }
        public void RemoveBooking()
        {
            string Name, PhoneNumber; 
            
            // Nhập tên KH hủy đặt phòng
            Console.Write("Nhập tên khách hàng muốn hủy đặt phòng: ");
            Name = Console.ReadLine();
            if (validate.CheckContainSpecialChar(Name) || validate.CheckIsNullOrWhiteSpace(Name) || validate.ContainsNumber(Name))
            {
                notify.returnMsg = "Tên nhập vào không hợp lệ!";
                Console.WriteLine(notify.returnMsg);
            }

            // Nhập số điện thoại KH hủy đặt phòng
            Console.Write("Nhập số điện thoại KH hủy đặt phòng: ");
            PhoneNumber = Console.ReadLine();
            if (validate.CheckContainSpecialChar(PhoneNumber) || validate.CheckIsNullOrWhiteSpace(PhoneNumber) || validate.ContainsLetter(PhoneNumber))
            {
                notify.returnMsg = "SĐT nhập vào không hợp lệ!";
                Console.WriteLine(notify.returnMsg);
            }

            ImplementBooking temp = listBooking.FirstOrDefault(b => b.Customer.Name == Name && b.Customer.PhoneNumber == PhoneNumber);
            manageRoom.UpdateRoomStatus(temp.Room.ID, true); // Cập nhật lại trạng thái phòng
            listBooking.Remove(temp);          
            notify.returnMsg = "Hủy đặt phòng thành công!";
            Console.WriteLine(notify.returnMsg);
        }
        public void DisplayListBooking()
        {
            foreach (var booking in listBooking)
            {
                Console.WriteLine(booking.DisplayBookingInfo());
            }
        }

        public void AddRoom()
        {
            manageRoom.AddRoom();
        }
        public void RemoveRoom()
        {
            manageRoom.RemoveRoom();
        }
        public void CheckListRoom()
        {
            manageRoom.CheckListRoom();
        }
    }
}
