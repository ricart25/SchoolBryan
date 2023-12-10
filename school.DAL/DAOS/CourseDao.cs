using Microsoft.EntityFrameworkCore;
using school.BR.Context;
using school.BR.Entidades;
using school.BR.Exceptions;
using school.BR.Interfaces;
using school.BR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school.BR.Daos
{
    public class CourseDao : ICourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public CourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public IEnumerable<Department> GetDepartments()
        {
            return schoolDb.Departments.ToList(); // Suponiendo que tienes una entidad Department mapeada en tu DbContext
        }
        public CourseModel GetCourseById(int courseID)
        {
            CourseModel model = new CourseModel();
            try
            {
                Course? course = schoolDb.Course.Find(courseID);

                if (course is null)
                    throw new CourseDaoException("El curso no se encuentra registrado.");


                model.Credits = course.Credits;
                model.DepartmentID = course.DepartmentID;
                model.CourseID = course.CourseID;
                model.Title = string.Concat(course.Title, " ");


            }
            catch (Exception ex)
            {
                throw new CourseDaoException(ex.Message);
            }
            return model;
        }

        public List<CourseModel> GetCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            try
            {
                ///LINQ QUERY
                var query = from cou in this.schoolDb.Course
                            where cou.Deleted == false
                            select new CourseModel()
                            {
                               
                                CourseID = cou.CourseID,
                                Title = string.Concat(cou.Title, " "),
                                DepartmentID = cou.DepartmentID,
                                Credits = cou.Credits,
                            };

                courses = query.ToList();

            }
            catch (Exception ex)
            {
                throw new CourseDaoException(ex.Message);
            }
            return courses;
        }

        public void RemoveCourse(Course course)
        {
            try
            {
                Course? courseToRemove = this.schoolDb.Course.Find(course.CourseID);

                if (courseToRemove is null)
                    throw new CourseDaoException("El Curso no se encuentra registrado.");


                courseToRemove.Deleted = course.Deleted;
                courseToRemove.DeletedDate = course.DeletedDate;
                courseToRemove.UserDeleted = course.UserDeleted;

                this.schoolDb.Course.Update(courseToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new CourseDaoException(ex.Message);
            }
        }

        public void SaveCourse(Course course)
        {
            try
            {
                if (course is null)
                    throw new CourseDaoException("la clase debe de ser instaciada.");


                this.schoolDb.Course.Add(course);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CourseDaoException(ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                Course? courseToUpdate = this.schoolDb.Course.Find(course.CourseID);

                if (courseToUpdate is null)
                    throw new CourseDaoException("El curso no se encuentra registrado.");


                courseToUpdate.DepartmentID = course.DepartmentID;
                courseToUpdate.Credits = course.Credits;
                courseToUpdate.CourseID = course.CourseID;
                courseToUpdate.Title = course.Title;


                this.schoolDb.Course.Update(courseToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new CourseDaoException(ex.Message);
            }
        }

        object ICourseDao.GetDepartments()
        {
            throw new NotImplementedException();
        }
    }
}
