using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi10.DataObject
{
    public class Room
    {
        internal int ID {  get; set; }
        internal int Type { get; set; }
        internal bool Status { get; set; }
        internal double PriceByType()
        {
            if (Type == 1)
                return 1000000;
            else if (Type == 2)
                return 680000;
            else if (Type == 3)
                return 550000;
            else if (Type == 4)
                return 400000;
            else 
                return 200000;
        }
        internal string ReturnTypeRoom()
        {
            if (Type == 1)
                return $"Phòng VIP";
            else if (Type == 2)
                return $"Phòng 4 giường";
            else if (Type == 3)
                return $"Phòng 3 giường";
            else if (Type == 4)
                return $"Phòng giường đôi";
            else if (Type == 5)
                return $"Phòng giường đơn";
            else return $"Không có loại phòng này";
        }
        internal string ReturnStatus()
        {
            if (Status == false)
                return $"Đã được đặt";
            else return $"Còn trống";
        }
        public Room () { }
        public Room (int id, int type, bool status)
        {
            ID = id;
            Type = type;
            Status = status;
        }
        public string Display()
        {
            return $"Số phòng: {ID}, Loại phòng: {ReturnTypeRoom()}, Giá: {PriceByType()}, Trạng thái: {ReturnStatus()}";
        }
    }
}
