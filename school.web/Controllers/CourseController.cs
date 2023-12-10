using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school.BR.Context;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolDbContext _context;

        

        private readonly ICourseDao courseDao;
        public CourseController(ICourseDao courseDao)
        {
            this.courseDao = courseDao;
        }
        // GET: CourseController
        public ActionResult Index()
        
        {

              var courses = this.courseDao.GetCourses().Select(co => new Models.CourseListModel()
              {
                  CourseID = co.CourseID,
                  Title = co.Title,
                  Credits = co.Credits,
                  DepartmentID = co.DepartmentID,
              }).ToList();
              return View(courses);
            
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
			var courseModel = this.courseDao.GetCourseById(id);
			CourseListModel course = new CourseListModel()
			{
				CourseID = courseModel.CourseID,
				DepartmentID = courseModel.DepartmentID,
				Credits = courseModel.Credits,
                Title = courseModel.Title
			};
			return View(course);
		}

        // GET: CourseController/Create
        public ActionResult Create()
        {
            /*var departments = this.courseDao.GetDepartments(); // Método para obtener departamentos desde la base de datos

            var viewModel = new CourseViewModel
            {
                Departments = (IEnumerable<Department>)departments // Asigna la lista de departamentos al ViewModel
            };*/

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseView)
        {
            try
            {
                Course courseToAdd = new Course()
                {
                    
                    DepartmentID = courseView.DepartmentID,
                    Credits = courseView.Credits,
                    Title = courseView.Title,
                    CreationDate = DateTime.Now,
                    CreationUser = 1
                };

                this.courseDao.SaveCourse(courseToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var courseModel = this.courseDao.GetCourseById(id);
            CourseViewModel courseViewModel = new CourseViewModel()
            {
                CourseID = courseModel.CourseID,
                DepartmentID = courseModel.DepartmentID,
                Credits = courseModel.Credits,
                Title = courseModel.Title
            };
            return View(courseViewModel);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel courseView)
        {
            try
            {
                Course courseToUpdate = new Course
                {
                    CourseID = courseView.CourseID,
                    DepartmentID = courseView.DepartmentID,
                    Credits = courseView.Credits,
                    Title = courseView.Title
                };

                this.courseDao.UpdateCourse(courseToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
