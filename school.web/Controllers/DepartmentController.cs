using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using school.BR.Entidades;
using school.BR.Interfaces;
using school.web.Models;

namespace school.web.Controllers
{
    public class DepartmentController : Controller

    {

        private readonly IDepartmentDao departmentDao;
        public DepartmentController(IDepartmentDao departmentDao)
        {
            this.departmentDao = departmentDao;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = this.departmentDao.GetDepartments().Select(DP => new Models.DepartmentListModel()
            {
                StartDate = DP.StartDate,
                Budget = DP.Budget,
                DepartmentId = DP.DepartmentId,
                Name = DP.Name,
            }).ToList();
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var departmentModel = this.departmentDao.GetDepartmentById(id);
            DepartmentListModel department = new DepartmentListModel()
            {
                StartDate = departmentModel.StartDate,
                Budget = departmentModel.Budget,
                DepartmentId = departmentModel.DepartmentId,
                Name = departmentModel.Name
            };
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel departmentView)
        {
            try
            {
                Department departmentToAdd = new Department()
                {
                    
                    Name = departmentView.Name,
                    Budget = departmentView.Budget,
                    StartDate = departmentView.StartDate,
                    CreationDate = DateTime.Now,
                    CreationUser = 1
                   
                };

                this.departmentDao.SaveDepartment(departmentToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int DepartmentId)
        {
            var departmentModel = this.departmentDao.GetDepartmentById(DepartmentId);
            DepartmentViewModel departmentViewModel = new DepartmentViewModel()
            {
                StartDate = departmentModel.StartDate,
                Name = departmentModel.Name,
                Budget = departmentModel.Budget,
                DepartmentId = departmentModel.DepartmentId,
            };
            return View(departmentViewModel);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel departmentView)
        {
            try
            {
                Department departmentToUpdate = new Department
                {
                    DepartmentId = departmentView.DepartmentId,
                    Name = departmentView.Name,
                    StartDate = departmentView.StartDate,
                    Budget = departmentView.Budget,
                    
                };

                this.departmentDao.UpdateDepartment(departmentToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
