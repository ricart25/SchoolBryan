using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.BR.Interfaces;
using school.BR.Entidades;
using school.web.Models;

namespace school.web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorDao instructorDao;
        public InstructorController(IInstructorDao instructorDao)
        {
           this.instructorDao = instructorDao;
        }
        // GET: InstructorController
        public ActionResult Index()
        {
            var instructors = this.instructorDao.GetInstructors().Select(ins => new Models.InstructorListModel()
            {
                CreationDate = ins.CreationDate,
                HireDate = ins.HireDate,
                HireDateDisplay = ins.HireDateDisplay,
                Id = ins.Id,
                Name = ins.Name,
            }).ToList();
            return View(instructors);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            var instructorModel = this.instructorDao.GetInstructorById(id);
            InstructorListModel instructor = new InstructorListModel()
            {
                HireDate = instructorModel.HireDate,
                Id = instructorModel.Id,
                Name = instructorModel.Name,
                CreationDate = instructorModel.CreationDate,
            };
            return View(instructor);
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorViewModel instructorView)
        {
            try
            {
                Instructor instructorToAdd = new Instructor()
                {
                    FirstName = instructorView.FirstName,
                    LastName = instructorView.LastName,
                    HireDate = instructorView.HireDate,
                    CreationDate = DateTime.Now,
                    CreationUser = 1
                };

                this.instructorDao.SaveInstructor(instructorToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            var instructorModel = this.instructorDao.GetInstructorById(id);
            InstructorViewModel instructorViewModel = new InstructorViewModel()
            {
                HireDate = instructorModel.HireDate,
                FirstName = instructorModel.FirstName,
                LastName = instructorModel.LastName,
                Id = instructorModel.Id,
            };
            return View(instructorViewModel);
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorViewModel instructorView)
        {
            try
            {
                Instructor instructorToUpdate = new Instructor
                {
                    Id = instructorView.Id,
                    FirstName = instructorView.FirstName,
                    LastName = instructorView.LastName,
                    HireDate = instructorView.HireDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1
                };

                this.instructorDao.UpdateInstructor(instructorToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        
        }
    }
}
