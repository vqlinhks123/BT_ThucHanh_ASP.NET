using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuQuangLinh_BT_Buoi9.Classes;
using VuQuangLinh_BT_Buoi9.ValidationAndNotification;

namespace VuQuangLinh_BT_Buoi9.RunExercises
{
    internal class Bai2
    {
        PushNotification notify = new PushNotification();
        ValidationData validate = new ValidationData();
        ImplementStudentRegister listRegister;
        internal void RunExercise2()
        {
            bool flag = false;
            int choice;
            do
            {
                MenuExercise2();
                if (!Int32.TryParse(Console.ReadLine(), out choice))
                {
                    notify.returnMsg = "Dữ liệu nhập vào phải là số và không được bỏ trống!";
                    Console.WriteLine(notify.returnMsg);
                }
                else
                {
                    switch (choice)
                    {
                        case 0: flag = true; break;
                        case 1:
                            if (listRegister == null)
                                break;
                            RegisterCourse();
                            Console.WriteLine();
                            break;
                        case 2:
                            if (listRegister == null)
                                break;
                            DisplayRegisteredCoursesByTuitionDecrease();
                            Console.WriteLine();
                            break;
                        default: Console.WriteLine("Dữ liệu nhập vào không hợp lệ, vui lòng nhập lại!"); break;
                    }
                }
            } while (!flag);
        }
        internal void MenuExercise2()
        {
            Console.WriteLine("\n-----Hệ Thống Đăng Ký Khóa Học-----");
            Console.WriteLine("1. Đăng ký khóa học");
            Console.WriteLine("2. Hiển thị danh sách học viên theo mức học phí giảm dần");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("Hãy nhập lựa chọn của bạn: ");
        }
        public Course ImportCourses()
        {
            string name;
            string description;
            double tuition = 0;
            string opening_day;
            DateTime openingDay = new DateTime();
            string register_day;
            DateTime registerDay = new DateTime();
            bool valid = false;

            // Nhập tên khóa học 
            do
            {
                Console.WriteLine("Nhập tên khóa học: ");
                name = Console.ReadLine();
                if (validate.CheckContainSpecialChar(name) || validate.CheckIsNullOrWhiteSpace(name))
                {
                    notify.returnMsg = "Tên khóa học nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }    
                else
                    valid = true;
            } while (!valid);

            // Nhập mô tả
            do
            {
                Console.WriteLine("Nhập mô tả khóa học: ");
                description = Console.ReadLine();
                if (validate.CheckContainSpecialChar(description) || validate.CheckIsNullOrWhiteSpace(description))
                {
                    notify.returnMsg = "Mô tả nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
                else
                    valid = true;
            } while (!valid);

            // Nhập học phí
            do
            {
                try
                {
                    Console.WriteLine("Nhập học phí: ");
                    tuition = Double.Parse(Console.ReadLine());
                    if (validate.CheckPrice(tuition))
                    {
                        notify.returnMsg = "Học phí nhập vào không hợp lệ";
                        Console.WriteLine(notify.returnMsg);
                        valid = false;
                    }
                    else
                        valid = true;
                }
                catch
                {
                    notify.returnMsg = "Học phí nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
            } while (!valid);

            // Nhập ngày khai giảng
            do
            {

                try
                {
                    Console.WriteLine("Nhập ngày khai giảng: ");
                    opening_day = Console.ReadLine();
                    openingDay = DateTime.ParseExact(opening_day, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (!validate.CheckOpeningDay(openingDay))
                    {
                        notify.returnMsg = "Ngày khai giảng nhập vào không được nhỏ hơn ngày hiện tại";
                        Console.WriteLine(notify.returnMsg);
                        valid = false;
                    }
                    else
                        valid = true;                 
                }
                catch
                {
                    notify.returnMsg = "Ngày khai giảng nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
            } while (!valid);

            // Nhập ngày đăng ký khóa học
            do
            {
                try
                {
                    Console.WriteLine("\nNhập ngày đăng ký khóa học: ");
                    register_day = Console.ReadLine();
                    registerDay = DateTime.ParseExact(register_day, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (!validate.CheckDay(registerDay))
                    {
                        notify.returnMsg = "Ngày đăng ký không được lớn hơn ngày hiện tại";
                        Console.WriteLine(notify.returnMsg);
                        valid = false;
                    }
                    else
                        valid = true;
                }
                catch
                {
                    notify.returnMsg = "Ngày đăng ký không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
            } while (!valid);
            Course new_course = new Course(name,description,tuition,openingDay,registerDay);
            return new_course;
        }
        public Student ImportStudent()
        {
            string fullName;
            string birthday;
            DateTime birthDay = new DateTime();
            bool valid = false;

            // Nhập họ tên học viên
            do
            {
                Console.WriteLine("Nhập họ tên học viên: ");
                fullName = Console.ReadLine();
                if (validate.CheckContainSpecialChar(fullName) || validate.CheckIsNullOrWhiteSpace(fullName) || validate.ContainsNumber(fullName))
                {
                    notify.returnMsg = "Họ tên nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
                else
                    valid = true;
            } while (!valid);

            // Nhập ngày sinh
            do
            {
                try
                {
                    Console.WriteLine("Nhập ngày sinh: ");
                    birthday = Console.ReadLine();
                    birthDay = DateTime.ParseExact(birthday, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None);
                    if (!validate.CheckDay(birthDay))
                    {
                        notify.returnMsg = "Ngày sinh nhập vào không được lớn hơn ngày hiện tại";
                        Console.WriteLine(notify.returnMsg);
                        valid = false;
                    }
                    else
                        valid = true;
                }
                catch
                {
                    notify.returnMsg = "Ngày sinh nhập vào không hợp lệ";
                    Console.WriteLine(notify.returnMsg);
                    valid = false;
                }
            } while (!valid);
            Student new_student = new Student(fullName,birthDay);
            return new_student;
        }
        public void RegisterCourse()
        {
            Console.WriteLine("\nNhập thông tin học viên: ");
            Student new_student = ImportStudent();
            Console.WriteLine("\nNhập thông tin khóa học: ");
            Course new_course = ImportCourses();

            // Thêm vào quản lí đăng kí khóa học
            listRegister.RegisterCourse(new_student,new_course);
        }
        public void DisplayRegisteredCoursesByTuitionDecrease()
        {

        }
    }
}
