﻿using Microsoft.EntityFrameworkCore;
using school.BR.Entidades;

namespace school.BR.Context
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignment { get; set; }

        public DbSet<OnlineCourse> OnlineCourse { get; set; }

        public DbSet<OnsiteCourse> OnsiteCourse { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentGrade> StudentGrade { get; set; }
    }
}
