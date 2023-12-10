using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.BR.Context;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class OnlineCourseController : Controller
    {
        private readonly SchoolDbContext _context;

        private readonly IOnlineCourseDao onlineCourseDao;
        public OnlineCourseController(IOnlineCourseDao onlineCourseDao)
        {
            this.onlineCourseDao = onlineCourseDao;
        }
        // GET: OnlineCourseController
        public ActionResult Index()
        {
            var onlineCourses = this.onlineCourseDao.GetOnlineCourses().Select(olc => new Models.OnlineCourseListModel()
            {
                CourseID = olc.CourseID,
                URL = olc.URL
                
            }).ToList();
            return View(onlineCourses);
        }

        // GET: OnlineCourseController/Details/5
        public ActionResult Details(int id)
        {
            var onlineCourseModel = this.onlineCourseDao.GetOnlineCourseById(id);
            OnlineCourseListModel onlineCourse = new OnlineCourseListModel()
            {
                CourseID = onlineCourseModel.CourseID,
                URL = onlineCourseModel.URL
            };
            return View(onlineCourse);
        }

        // GET: OnlineCourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlineCourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OnlineCourseViewModel onlineCourseView)
        {
            try
            {
                OnlineCourse onlineCourseToAdd = new OnlineCourse()
                {
                    CourseID = onlineCourseView.CourseID,
                    URL = onlineCourseView.URL
                 
                };

                this.onlineCourseDao.SaveOnlineCourse(onlineCourseToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OnlineCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var onlineCourseModel = this.onlineCourseDao.GetOnlineCourseById(id);
            OnlineCourseViewModel onlineCourseViewModel = new OnlineCourseViewModel()
            {
                CourseID = onlineCourseModel.CourseID,
                URL = onlineCourseModel.URL
            };
            return View(onlineCourseViewModel);
        }

        // POST: OnlineCourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OnlineCourseViewModel onlineCourseView)
        {
            try
            {
                OnlineCourse onlineCourseToUpdate = new OnlineCourse
                {
                    CourseID    = onlineCourseView.CourseID,
                    URL = onlineCourseView.URL
                };

                this.onlineCourseDao.UpdateOnlineCourse(onlineCourseToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
