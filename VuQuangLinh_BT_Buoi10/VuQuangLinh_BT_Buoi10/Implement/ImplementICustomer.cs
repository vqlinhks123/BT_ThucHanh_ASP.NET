using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi10.Interfaces;
using VuQuangLinh_BT_Buoi10.DataObject;
using VuQuangLinh_BT_Buoi10.Validation_and_Notification;

namespace VuQuangLinh_BT_Buoi10.Implement
{
    internal class ImplementICustomer : ICustomer
    {
        Notification notify = new Notification();
        Validation validate = new Validation();
        List<Customer> listCustomers = new List<Customer>();
        public void Add(Customer customer)
        {
            listCustomers.Add(customer);
        }
        public void Remove(int Identity) 
        {
            Customer expiredCustomer = listCustomers.FirstOrDefault(c => c.Identity == Identity);
            listCustomers.Remove(expiredCustomer);
        }
        public void ModifyCustomerInfo()
        {

        }
        // Nhập thông tin khách hàng
        public Customer InputCustomer()
        {
            string Name;
            string PhoneNumber;
            string birthday;
            DateTime BirthDay = new DateTime();
            long Identity = 0;
            bool valid = false;

            // Nhập tên khách hàng
            do
            {
                Console.Write("Nhập tên khách hàng: ");
                Name = Console.ReadLine();
                if (validate.CheckContainSpecialChar(Name) || validate.CheckIsNullOrWhiteSpace(Name) || validate.ContainsNumber(Name))
                {
                    valid = false;
                    notify.returnMsg = "Tên nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
                else valid = true;
            } while (!valid);

            // Nhập số điện thoại
            do
            {
                Console.Write("Nhập số điện thoại: ");
                PhoneNumber = Console.ReadLine();
                if (validate.CheckContainSpecialChar(PhoneNumber) || validate.CheckIsNullOrWhiteSpace(PhoneNumber) || validate.ContainsLetter(PhoneNumber))
                {
                    valid = false;
                    notify.returnMsg = "SĐT nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
                else valid = true;
            } while (!valid);

            // Nhập ngày sinh
            do
            {
                Console.Write("Nhập ngày sinh (dd/mm/yyyy): ");
                birthday = Console.ReadLine();
                try
                {
                    BirthDay = DateTime.ParseExact(birthday, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (validate.CheckBirthday(BirthDay))
                        valid = true;
                    else
                    {
                        valid = false;
                        notify.returnMsg = "Tuổi không được nhỏ hơn 16!";
                        Console.WriteLine(notify.returnMsg);
                    }
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Định dạng ngày sinh nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Nhập số CCCD
            do
            {
                Console.Write("Nhập số CCCD: ");
                try
                {
                    Identity = long.Parse(Console.ReadLine());
                    valid = true;
                }
                catch
                {
                    valid = false;
                    notify.returnMsg = "Số CCCD nhập vào không hợp lệ!";
                    Console.WriteLine(notify.returnMsg);
                }
            } while (!valid);

            // Khởi tạo khách hàng
            Customer new_customer = new Customer(Name, PhoneNumber, BirthDay, Identity);
            return new_customer;
        }
    }
}
