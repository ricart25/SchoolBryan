﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentDao studentDao;
        public StudentController(IStudentDao studentDao) 
        {
            this.studentDao = studentDao;
        }
        // GET: StudentController
        public ActionResult Index()
        { 
            var students = this.studentDao.GetStudents().Select(cd => new Models.StudentListModel() 
            { 
                CreationDate = cd.CreationDateDisplay,
                EnrollmentDate = cd.EnrollmentDate,
                EnrollmentDateDisplay = cd.EnrollmentDateDisplay,
                Id = cd.Id,
                Name = cd.Name, 
            }).ToList();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var studentModel = this.studentDao.GetStudentById(id);
            StudentListModel student = new StudentListModel() 
            { 
                EnrollmentDate = studentModel.EnrollmentDate,
                Id = studentModel.Id,
                Name = studentModel.Name
            };
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentView)
        {
            try
            {
                Student studentToAdd = new Student() 
                { 
                 FirstName = studentView.FirstName,
                 LastName = studentView.LastName,
                 EnrollmentDate = studentView.EnrollmentDate,
                 CreationDate = DateTime.Now,
                 CreationUser = 1
                };

                this.studentDao.SaveStudent(studentToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var studentModel = this.studentDao.GetStudentById(id);
            StudentViewModel studentViewModel = new StudentViewModel() 
            {
             EnrollmentDate = studentModel.EnrollmentDate,
             FirstName = studentModel.FirstName,
             LastName = studentModel.LastName,
             Id = studentModel.Id,
            };
            return View(studentViewModel);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentView)
        {
            try
            {
                Student studentToUpdate = new Student
                {
                    Id = studentView.Id,
                    FirstName = studentView.FirstName,
                    LastName = studentView.LastName,
                    EnrollmentDate = studentView.EnrollmentDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1
                };

                this.studentDao.UpdateStudent(studentToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
