using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    public class Course
    {
        public string Name { get; set;}
        public string Description { get; set;}
        public double Tuition { get; set;}
        public DateTime OpeningDay { get; set;}
        public Course(string name, string description, double tuition, DateTime openingDay)
        {
            Name = name;
            Description = description; 
            Tuition = tuition;
            OpeningDay = openingDay;
        }
        public string Display()
        {
            return $"Tên khóa học: {Name}, Mô tả: {Description}, Học phí: {Tuition}, Ngày khai giảng: {OpeningDay}";
        }
    }
}
