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
    public class DepartmentDao : IDepartmentDao
    {
        private readonly SchoolDbContext schoolDb;

        public DepartmentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public DepartmentModel GetDepartmentById(int DepartmentId)
        {
            DepartmentModel model = new DepartmentModel();
            try
            {
                Department? department = schoolDb.Departments.Find(DepartmentId);

                if (department is null)
                    throw new DepartmentDaoException("El Departamento no se encuentra registrado.");


                model.CreationDate = department.CreationDate;
                model.StartDate = department.StartDate;
                model.DepartmentId = department.DepartmentId;
                model.Name = department.Name;


            }
            catch (Exception ex)
            {
                throw new DepartmentDaoException(ex.Message);
            }
            return model;
        }

        public List<DepartmentModel> GetDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            try
            {
                ///LINQ QUERY
                var query = from DE in this.schoolDb.Departments
                            where DE.Deleted == false
                            select new DepartmentModel()
                            {
                                CreationDate = DE.CreationDate,
                                StartDate = DE.StartDate,
                                DepartmentId = DE.DepartmentId,
                                Name = DE.Name,
                            };

                departments = query.ToList();

            }
            catch (Exception ex)
            {
                throw new DepartmentDaoException(ex.Message);
            }
            return departments;
        }

        public void RemoveDepartment(Department department)
        {
            try
            {
                Department? departmentToRemove = this.schoolDb.Departments.Find(department.DepartmentId);

                if (departmentToRemove is null)
                    throw new DepartmentDaoException("El estudiante no se encuentra registrado.");


                departmentToRemove.Deleted = department.Deleted;
                departmentToRemove.DeletedDate = department.DeletedDate;
                departmentToRemove.UserDeleted = department.UserDeleted;

                this.schoolDb.Departments.Update(departmentToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new DepartmentDaoException(ex.Message);
            }
        }

        public void SaveDepartment(Department department)
        {
            try
            {
                if (department is null)
                    throw new DepartmentDaoException("la clase debe de ser instaciada.");


                this.schoolDb.Departments.Add(department);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DepartmentDaoException(ex.Message);
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                Department? departmentToUpdate = this.schoolDb.Departments.Find(department.DepartmentId);

                if (departmentToUpdate is null)
                    throw new DepartmentDaoException("El departamento no se encuentra registrado.");


                departmentToUpdate.ModifyDate = department.ModifyDate;
                departmentToUpdate.UserMod = department.UserMod;
                departmentToUpdate.DepartmentId = department.DepartmentId;
                departmentToUpdate.Name = department.Name;
                departmentToUpdate.StartDate = department.StartDate;


                this.schoolDb.Departments.Update(departmentToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new DepartmentDaoException(ex.Message);
            }
        }
    }
}
