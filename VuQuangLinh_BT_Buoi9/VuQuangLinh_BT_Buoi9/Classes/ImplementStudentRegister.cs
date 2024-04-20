using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    internal class ImplementStudentRegister : IStudentRegister
    {
        Dictionary<Student, List<Course>> registerCourse;
        public ImplementStudentRegister(int size)
        {
            registerCourse = new Dictionary<Student, List<Course>>(size);
        }
        public void DeleteStudent(Student student)
        {
            registerCourse.Remove(student);
        }
        public void AddCourse(List<Course> listCourses, Course course)
        {
            listCourses.Add(course);
        }
        public void DeleteCourse(List<Course> listCourses, string courseName)
        {
            listCourses.Remove(listCourses.FirstOrDefault(c => c.Name  == courseName));
        }
        public void RegisterCourses(Student student, List<Course> courses)
        {
            registerCourse.Add(student, courses);
        }
    }
}
