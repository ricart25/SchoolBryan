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
    public class OnsiteCourseDao : IOnsiteCourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public OnsiteCourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public OnsiteCourseModel GetOnsiteCourseById(int onsiteCourseId)
        {
            OnsiteCourseModel model = new OnsiteCourseModel();
            try
            {
                OnsiteCourse? onsiteCourse = schoolDb.OnsiteCourse.Find(onsiteCourseId);

                if (onsiteCourse is null)
                    throw new OnsiteCourseDaoException("El curso no se encuentra registrado.");

                model.CourseID = onsiteCourse.CourseID;
                model.Location = string.Concat(onsiteCourse.Location, " ");
                model.Days = string.Concat(onsiteCourse.Days, " ");
                model.Time = onsiteCourse.Time;


            }
            catch (Exception ex)
            {
                throw new OnsiteCourseDaoException(ex.Message);
            }
            return model;
        }

        public List<OnsiteCourseModel> GetOnsiteCourses()
        {
            List<OnsiteCourseModel> onsiteCourses = new List<OnsiteCourseModel>();
            try
            {
                ///LINQ QUERY
                var query = from osc in this.schoolDb.OnsiteCourse
                            select new OnsiteCourseModel()
                            {

                                CourseID = osc.CourseID,
                                Location = string.Concat(osc.Location, " "),
                                Days = string.Concat(osc.Days, " "),
                                Time = osc.Time,
                            };

                onsiteCourses = query.ToList();

            }
            catch (Exception ex)
            {
                throw new OnsiteCourseDaoException(ex.Message);
            }
            return onsiteCourses;
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
        public void SaveOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            try
            {
                if (onsiteCourse is null)
                    throw new OnsiteCourseDaoException("la clase debe de ser instaciada.");


                this.schoolDb.OnsiteCourse.Add(onsiteCourse);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OnsiteCourseDaoException(ex.Message);
            }
        }
       
        public void UpdateOnsiteCourse(OnsiteCourse onsiteCourse)
        {
            try
            {
                OnsiteCourse? onsiteCourseToUpdate = this.schoolDb.OnsiteCourse.Find(onsiteCourse.CourseID);

                if (onsiteCourseToUpdate is null)
                    throw new OnsiteCourseDaoException("El Curso Presencial no se encuentra registrado.");


                onsiteCourseToUpdate.CourseID = onsiteCourse.CourseID;
                onsiteCourseToUpdate.Days = onsiteCourse.Days;
                onsiteCourseToUpdate.Time = onsiteCourse.Time;
                onsiteCourseToUpdate.Location = onsiteCourse.Location;
              
               
                this.schoolDb.OnsiteCourse.Update(onsiteCourseToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new OnsiteCourseDaoException(ex.Message);
            }
        }
        
    }
}