using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi10.DataObject
{
    public class Customer
    {
        internal string Name { get; set; }
        internal string PhoneNumber { get; set; }
        internal DateTime Birthday { get; set; }
        internal long Identity { get; set; }

        public Customer(string name, string phone, DateTime birthday, long identity)
        {
            Name = name;
            PhoneNumber = phone;
            Birthday = birthday;
            Identity = identity;
        }
        public string Display()
        {
            return $"Tên khách hàng: {Name}, Số điện thoại: {PhoneNumber}, Ngày sinh: {Birthday}, CCCD: {Identity}";
        }
    }
}
