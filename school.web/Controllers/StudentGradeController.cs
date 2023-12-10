using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class StudentGradeController : Controller
    {
        private readonly IStudentGradeDao studentGradeDao;
        public StudentGradeController(IStudentGradeDao studentGradeDao)
        {
            this.studentGradeDao = studentGradeDao;
        }
        // GET: StudentGradeController
        public ActionResult Index()
        {
            var studentGrades = this.studentGradeDao.GetStudentGrades().Select(SG => new Models.StudentGradeListModel()
            {
                EnrollmentId = SG.EnrollmentId,
                CourseId = SG.CourseId,
                StudentId = SG.StudentId,
                Grade = SG.Grade,
            }).ToList();
            return View(studentGrades);
        }

        // GET: StudentGradeController/Details/5
        public ActionResult Details(int id)
        {
            var studentGradeModel = this.studentGradeDao.GetStudentGradeById(id);
            StudentGradeListModel studentGrade = new StudentGradeListModel()
            {
                EnrollmentId = studentGradeModel.EnrollmentId,
                StudentId = studentGradeModel.StudentId,
                CourseId = studentGradeModel.CourseId,
                Grade = studentGradeModel.Grade,
            };
            return View(studentGrade);
        }

        // GET: StudentGradeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentGradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentGradeViewModel studentGradeView)
        {
            try
            {
                StudentGrade studentGradeToAdd = new StudentGrade()
                {
                    
                    CourseId = studentGradeView.CourseId,
                   StudentId =studentGradeView.StudentId,
                    Grade = studentGradeView.Grade
                };

                this.studentGradeDao.SaveStudentGrade(studentGradeToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGradeController/Edit/5
        public ActionResult Edit(int id)
        {
            var studentGradeModel = this.studentGradeDao.GetStudentGradeById(id);
            StudentGradeViewModel studentGradeViewModel = new StudentGradeViewModel()
            {
                EnrollmentId = studentGradeModel.EnrollmentId,
                CourseId = studentGradeModel.CourseId,
                StudentId = studentGradeModel.StudentId,
                Grade = studentGradeModel.Grade,
            };
            return View(studentGradeViewModel);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentGradeViewModel studentGradeView)
        {
            try
            {
                StudentGrade studentGradeToUpdate = new StudentGrade
                {
                    EnrollmentId = studentGradeView.EnrollmentId,
                    CourseId = studentGradeView.CourseId,
                    StudentId = studentGradeView.StudentId,
                    Grade = studentGradeView.Grade,
                };

                this.studentGradeDao.UpdateStudentGrade(studentGradeToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
