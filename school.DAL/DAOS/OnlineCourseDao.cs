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
    public class OnlineCourseDao : IOnlineCourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public OnlineCourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public OnlineCourseModel GetOnlineCourseById(int onlineCourseId)
        {
            OnlineCourseModel model = new OnlineCourseModel();
            try
            {
                OnlineCourse? onlineCourse = schoolDb.OnlineCourse.Find(onlineCourseId);

                if (onlineCourse is null)
                    throw new OnlineCourseDaoException("El curso online no se encuentra registrado.");

                model.CourseID = onlineCourse.CourseID;
                model.URL = string.Concat(onlineCourse.URL, " ");


            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
            return model;
        }

        public List<OnlineCourseModel> GetOnlineCourses()
        {
            List<OnlineCourseModel> onlineCourses = new List<OnlineCourseModel>();
            try
            {
                ///LINQ QUERY
                var query = from olc in this.schoolDb.OnlineCourse
                            select new OnlineCourseModel()
                            {

                                CourseID = olc.CourseID,
                                URL = string.Concat(olc.URL, " "),
                            };

                onlineCourses = query.ToList();

            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
            return onlineCourses;
        }
        /*
        public void RemoveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                OfficeAssignment? officeAssignmentToRemove = this.schoolDb.OfficeAssignments.Find(officeAssignment.InstructorId);

                if (officeAssignmentToRemove is null)
                    throw new StudentDaoException("El officeAssignment no se encuentra registrado.");


                officeAssignmentToRemove.Deleted = officeAssignment.Deleted;
                officeAssignmentToRemove.DeletedDate = officeAssignment.DeletedDate;
                officeAssignmentToRemove.UserDeleted = officeAssignment.UserDeleted;

                this.schoolDb.OfficeAssignments.Update(officeAssignmentToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new OfficeAssignmentDaoException(ex.Message);
            }
        }
        */
        public void SaveOnlineCourse(OnlineCourse onlineCourse)
        {
            try
            {
                if (onlineCourse is null)
                    throw new OnlineCourseDaoException("la clase debe de ser instaciada.");


                this.schoolDb.OnlineCourse.Add(onlineCourse);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoException(ex.Message);
            }
        }
        
        public void UpdateOnlineCourse(OnlineCourse onlineCourse)
        {
            try
            {
                OnlineCourse? onlineCourseToUpdate = this.schoolDb.OnlineCourse.Find(onlineCourse.CourseID);

                if (onlineCourseToUpdate is null)
                    throw new OnlineCourseDaoException("El Curso Online no se encuentra registrado.");


                onlineCourseToUpdate.CourseID = onlineCourse.CourseID;
                onlineCourseToUpdate.URL = onlineCourse.URL;


                this.schoolDb.OnlineCourse.Update(onlineCourseToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new OnlineCourseDaoException(ex.Message);
            }
        }
        
    }
}
