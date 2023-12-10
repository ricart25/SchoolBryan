using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.BR.Daos;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly IOfficeAssignmentDao officeAssignmentDao;
        public OfficeAssignmentController(IOfficeAssignmentDao officeAssignmentDao)
        {
            this.officeAssignmentDao = officeAssignmentDao;
        }
        // GET: OfficeAssignmentController
        public ActionResult Index()
        {
            var officeAssignments = this.officeAssignmentDao.GetOfficeAssignments().Select(of => new Models.OfficeAssignmentListModel()
            {
                Location = of.Location,
                InstructorId = of.InstructorId,
            }).ToList();
            return View(officeAssignments);
        }

        // GET: OfficeAssignmentController/Details/5
        public ActionResult Details(int id)
        {
            var officeAssignmentModel = this.officeAssignmentDao.GetOfficeAssignmentById(id);
            OfficeAssignmentListModel officeAssignment = new OfficeAssignmentListModel()
            {
                Location = officeAssignmentModel.Location,
                InstructorId = officeAssignmentModel.InstructorId,
            };
            return View(officeAssignment);
        }

        // GET: OfficeAssignmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficeAssignmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeAssignmentViewModel officeAssignmentView)
        {
            try
            {
                

                OfficeAssignment officeAssignmentToAdd = new OfficeAssignment()
                {
                    Location = officeAssignmentView.Location,
                    InstructorId = officeAssignmentView.InstructorId,
                    Timestamp = officeAssignmentView.Timestamp
                };

                this.officeAssignmentDao.SaveOfficeAssignment(officeAssignmentToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfficeAssignmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var officeAssignmentModel = this.officeAssignmentDao.GetOfficeAssignmentById(id);
            OfficeAssignmentViewModel officeAssignmentViewModel = new OfficeAssignmentViewModel()
            {
                Location = officeAssignmentModel.Location,
                InstructorId = officeAssignmentModel.InstructorId,
                Timestamp = officeAssignmentModel.Timestamp
            };
            return View(officeAssignmentViewModel);
        }

        // POST: OfficeAssignmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeAssignmentViewModel officeAssignmentView)
        {
            try
            {
                OfficeAssignment officeAssignmentToUpdate = new OfficeAssignment
                {
                    Location = officeAssignmentView.Location,
                    InstructorId = officeAssignmentView.InstructorId,
                    Timestamp = officeAssignmentView.Timestamp
                    
                };

                this.officeAssignmentDao.UpdateOfficeAssignment(officeAssignmentToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
