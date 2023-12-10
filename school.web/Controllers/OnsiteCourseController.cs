using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.BR.Context;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class OnsiteCourseController : Controller
    {
        private readonly SchoolDbContext _context;



        private readonly IOnsiteCourseDao onsiteCourseDao;
        public OnsiteCourseController(IOnsiteCourseDao onsiteCourseDao)
        {
            this.onsiteCourseDao = onsiteCourseDao;
        }
        // GET: OnsiteCourseController
        public ActionResult Index()
        {
            var onsiteCourses = this.onsiteCourseDao.GetOnsiteCourses().Select(osc => new Models.OnsiteCourseListModel()
            {
                CourseID = osc.CourseID,
                Location = osc.Location,
                Days = osc.Days,
                Time = osc.Time,
            }).ToList();
            return View(onsiteCourses);
        }

        // GET: OnsiteCourseController/Details/5
        public ActionResult Details(int id)
        {
            var onsiteCourseModel = this.onsiteCourseDao.GetOnsiteCourseById(id);
            OnsiteCourseListModel onsiteCourse = new OnsiteCourseListModel()
            {
                CourseID = onsiteCourseModel.CourseID,
                Location = onsiteCourseModel.Location,
                Days = onsiteCourseModel.Days,
                Time = onsiteCourseModel.Time
            };
            return View(onsiteCourse);
        }

        // GET: OnsiteCourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnsiteCourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OnsiteCourseViewModel onsiteCourseView)
        {
            try
            {
                OnsiteCourse onsiteCourseToAdd = new OnsiteCourse()
                {

                    CourseID = onsiteCourseView.CourseID,
                    Location = onsiteCourseView.Location,
                    Days = onsiteCourseView.Days,
                    Time = onsiteCourseView.Time
                };

                this.onsiteCourseDao.SaveOnsiteCourse(onsiteCourseToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OnsiteCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var onsiteCourseModel = this.onsiteCourseDao.GetOnsiteCourseById(id);
            OnsiteCourseViewModel onsiteCourseViewModel = new OnsiteCourseViewModel()
            {
                CourseID = onsiteCourseModel.CourseID,
                Location = onsiteCourseModel.Location,
                Days = onsiteCourseModel.Days,
                Time = onsiteCourseModel.Time
            };
            return View(onsiteCourseViewModel);
        }

        // POST: OnsiteCourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OnsiteCourseViewModel onsiteCourseView)
        {
            try
            {
                OnsiteCourse onsiteCourseToUpdate = new OnsiteCourse
                {
                    CourseID = onsiteCourseView.CourseID,
                    Location = onsiteCourseView.Location,
                    Time = onsiteCourseView.Time,
                    Days = onsiteCourseView.Days
                };

                this.onsiteCourseDao.UpdateOnsiteCourse(onsiteCourseToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
