using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    public class Student
    {
        protected string FullName { get; set; }
        protected DateTime BirthDay { get; set; }
        public Student (string fullName, DateTime birthDay)
        {
            FullName = fullName;
            BirthDay = birthDay;
        }
        public string Display()
        {
            return $"Họ và tên: {FullName}, Ngày sinh: {BirthDay}";
        }
    }
}
