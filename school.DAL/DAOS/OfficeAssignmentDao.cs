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
    public class OfficeAssignmentDao : IOfficeAssignmentDao
    {
        private readonly SchoolDbContext schoolDb;

        public OfficeAssignmentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public OfficeAssignmentModel GetOfficeAssignmentById(int officeAssignmentId)
        {
            OfficeAssignmentModel model = new OfficeAssignmentModel();
            try
            {
                OfficeAssignment? officeAssignment = schoolDb.OfficeAssignment.Find(officeAssignmentId);

                if (officeAssignment is null)
                    throw new OfficeAssignmentDaoException("El OfficeAssignment no se encuentra registrado.");



                model.InstructorId = officeAssignment.InstructorId;
                model.Location = string.Concat(officeAssignment.Location, " ");
                model.Timestamp = officeAssignment.Timestamp;


            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
            return model;
        }
        
        public List<OfficeAssignmentModel> GetOfficeAssignments()
        {
            List<OfficeAssignmentModel> officeAssignments = new List<OfficeAssignmentModel>();
            try
            {
                ///LINQ QUERY
                var query = from of in this.schoolDb.OfficeAssignment
                            select new OfficeAssignmentModel()
                            {
                                
                                InstructorId = of.InstructorId,
                                Location = string.Concat(of.Location, " "),
                                Timestamp = of.Timestamp
                                
                            };

                officeAssignments = query.ToList();

            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
            return officeAssignments;
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
        public void SaveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                if (officeAssignment is null)
                    throw new OfficeAssignmentDaoException("la clase debe de ser instaciada.");


                this.schoolDb.OfficeAssignment.Add(officeAssignment);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoException(ex.Message);
            }
        }
        
        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                OfficeAssignment? officeAssignmentToUpdate = this.schoolDb.OfficeAssignment.Find(officeAssignment.InstructorId);

                if (officeAssignmentToUpdate is null)
                    throw new OfficeAssignmentDaoException("El OfficeAssignment no se encuentra registrado.");


                
                officeAssignmentToUpdate.InstructorId = officeAssignment.InstructorId;
                officeAssignmentToUpdate.Location = officeAssignment.Location;
                officeAssignmentToUpdate.Timestamp = officeAssignment.Timestamp;

                this.schoolDb.OfficeAssignment.Update(officeAssignmentToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new OfficeAssignmentDaoException(ex.Message);
            }
        }
        
    }
}
