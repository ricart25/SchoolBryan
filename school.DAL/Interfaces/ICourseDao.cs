using school.BR.Entidades;
using school.BR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Interfaces
{
    public interface ICourseDao
    {
        void SaveCourse(Course course);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);
        List<CourseModel> GetCourses();
        CourseModel GetCourseById(int courseId);
        object GetDepartments();
    }
}
