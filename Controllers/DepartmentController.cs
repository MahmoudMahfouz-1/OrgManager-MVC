using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Core.Models;
using MVC_Core.Reposatoires;

namespace MVC_Core.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentReposatory deptRepo;

        public DepartmentController(IDepartmentReposatory deptRepo)
        {
            this.deptRepo = deptRepo;
        }

        [Authorize]
        public IActionResult Details()
        {
            var Depts = deptRepo.GetAll();
            return View("Details", Depts);
        }

        public IActionResult AddDepartment()
        {
            return View("AddDepartment");
        }
        [HttpPost]
        public IActionResult Save(Department newDept)
        {
            if (newDept.Name != null && newDept.ManagerName != null)
            {
                deptRepo.createOne(newDept);
                deptRepo.SaveChanges();
                return RedirectToAction("Details");

            }
            return RedirectToAction("AddDepartment");
        }
    }
}
