using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuQuangLinh_BT_Buoi9.Classes
{
    public interface IStudentRegister
    {
        void AddCourse(List<Course> listCourses, Course course);
        void DeleteCourse(List<Course> listCourses, string courseName);
        void RegisterCourses(Student student, List<Course> courses);
    }
}
