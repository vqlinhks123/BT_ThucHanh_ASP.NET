using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.DataObject;

namespace VuQuangLinh_BT_Buoi10.Implement
{
    internal class ImplementBooking
    {
        internal Customer Customer { get; set; }
        internal Room Room { get; set; }
        internal DateTime BookingDay { get; set; }
        internal DateTime RetrieveDay { get; set; }
        internal bool PaymentStatus { get; set; }
        public ImplementBooking(Customer customer, Room room, DateTime bookingDay, DateTime retrieveDay)
        {
            Customer = customer;
            Room = room;
            BookingDay = bookingDay;
            RetrieveDay = retrieveDay;
        }
        internal double calculatorTotalMoney()
        {
            TimeSpan interval = RetrieveDay - BookingDay;
            return Room.PriceByType() * interval.Days; 
        }
        public string DisplayBookingInfo()
        {
            return $"Tên khách hàng: {Customer.Name}, Số điện thoại: {Customer.PhoneNumber}, Loại phòng: {Room.ReturnTypeRoom()}, Số phòng: {Room.ID}, Đơn giá: {Room.PriceByType()}, Ngày đặt phòng: {BookingDay}, Ngày trả phòng: {RetrieveDay}, Tổng tiền: {calculatorTotalMoney()}";
        }
    }
}
