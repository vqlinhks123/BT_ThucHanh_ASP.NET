using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    internal class ImplementStudentRegister : IStudentRegister
    {
        Dictionary<Student, Course> registerCourse = new Dictionary<Student, Course>();
        public void RegisterCourse(Student student, Course course)
        {
            registerCourse.Add(student, course);
        }
        public double calculatorTuitionAfterDiscount(Course course, DateTime openingDay, DateTime registerDay)
        {
            TimeSpan timeSpan = openingDay - registerDay;
            if (timeSpan.Days >= 30)
                return course.Tuition - course.Tuition*0.15;
            if (timeSpan.Days >= 10)
                return course.Tuition - course.Tuition * 0.1;
            return course.Tuition;
        }
        public string DisplayRegistered()
        {
            return $"Họ tên: {}";
        }
        public void ArrangeByTuitionDecrease()
        {

        }
    }
}
