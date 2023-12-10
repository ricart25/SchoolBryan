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

namespace school.BR.DAOS
{
    public class InstructorDao : IInstructorDao
    {
        private readonly SchoolDbContext schoolDb;

        public InstructorDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public InstructorModel GetInstructorById(int instructorId)
        {
            InstructorModel model = new InstructorModel();
            try
            {
                Instructor? instructor = schoolDb.Instructors.Find(instructorId);

                if (instructor is null)
                    throw new InstructorDaoException("El instructor no se encuentra registrado.");

                model.FirstName = instructor.FirstName;
                model.LastName = instructor.LastName;
                model.HireDate = instructor.HireDate.Value;
                model.HireDate = instructor.HireDate.Value;
                model.Id = instructor.Id;
                


            }
            catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
            return model;
        }

        public List<InstructorModel> GetInstructors()
        {
            List<InstructorModel> instructors = new List<InstructorModel>();
            try
            {
                ///LINQ QUERY
                var query = from ins in this.schoolDb.Instructors
                            where ins.Deleted == false
                            select new InstructorModel()
                            {
                                CreationDate = ins.HireDate.Value,
                                HireDate = ins.HireDate.Value,
                                Id = ins.Id,
                                FirstName = ins.FirstName,
                                LastName = ins.LastName,
                            };

                instructors = query.ToList();

            }
            catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
            return instructors;
        }

        public void RemoveInstructor(Instructor instructor)
        {
            try
            {
                Instructor? instructorToRemove = this.schoolDb.Instructors.Find(instructor.Id);

                if (instructorToRemove is null)
                    throw new InstructorDaoException("El Instructor no se encuentra registrado.");


                instructorToRemove.Deleted = instructor.Deleted;
                instructorToRemove.DeletedDate = instructor.DeletedDate;
                instructorToRemove.UserDeleted = instructor.UserDeleted;

                this.schoolDb.Instructors.Update(instructorToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new InstructorDaoException(ex.Message);
            }
        }

        public void SaveInstructor(Instructor instructor)
        {
            try
            {
                if (instructor is null)
                    throw new InstructorDaoException("la clase debe de ser instaciada.");


                this.schoolDb.Instructors.Add(instructor);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InstructorDaoException(ex.Message);
            }
        }

        public void UpdateInstructor(Instructor instructor)
        {
            try
            {
                Instructor? instructorToUpdate = this.schoolDb.Instructors.Find(instructor.Id);

                if (instructorToUpdate is null)
                    throw new InstructorDaoException("El instructor no se encuentra registrado.");


                instructorToUpdate.ModifyDate = instructor.ModifyDate;
                instructorToUpdate.UserMod = instructor.UserMod;
                instructorToUpdate.Id = instructor.Id;
                instructorToUpdate.LastName = instructor.LastName;
                instructorToUpdate.FirstName = instructor.FirstName;
                instructorToUpdate.HireDate = instructor.HireDate.Value;


                this.schoolDb.Instructors.Update(instructorToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new InstructorDaoException(ex.Message);
            }
        }
    }
}
