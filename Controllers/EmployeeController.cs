using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Core.Models;
using MVC_Core.Reposatoires;
using MVC_Core.ViewModels;

namespace MVC_Core.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeReposatory empRepo;
        private readonly IDepartmentReposatory DeptRepo;


        public EmployeeController(IEmployeeReposatory empRepo, IDepartmentReposatory DeptRepo)
        {
            this.empRepo = empRepo;
            this.DeptRepo = DeptRepo;
        }
        // Return all details of employees
        public IActionResult Details()
        {
            // May be a problem
            var emps = empRepo.GetEmpWithDeptId();
            return View("Details", emps);
        }

        public IActionResult Edit(int id)
        {
            var employee = empRepo.GetById(id);
            var Departments = DeptRepo.GetAll();
            // Constructing the EmpDeptViewModel
            EmpDeptViewModel empDeptModel = new EmpDeptViewModel();
            empDeptModel.Id = employee.Id;
            empDeptModel.Name = employee.Name;
            empDeptModel.Address = employee.Address;
            empDeptModel.Number = employee.Number;
            empDeptModel.DepartmentId = employee.DepartmentId;

            empDeptModel.Departments = Departments;




            if (employee != null)
            {
                return View("Edit", empDeptModel);
            }
            else
            {
                return Content("Employee Not Found");
            }
        }
        public IActionResult SaveEdit(int id, EmpDeptViewModel empFromReq)
        {
            Employee empFromDB = empRepo.GetById(id);
            if (empFromDB != null && ModelState.IsValid)
            {
                empFromDB.Name = empFromReq.Name;
                empFromDB.Address = empFromReq.Address;
                empFromDB.Number = empFromReq.Number;
                empFromDB.DepartmentId = empFromReq.DepartmentId;
                empRepo.SaveChanges();
                return RedirectToAction("Details");
            }
            else
                empFromReq.Departments = DeptRepo.GetAll();
            return View("Edit", empFromReq);
        }
        public IActionResult AddNewEmp()
        {
            ViewBag.DeptItems = DeptRepo.GetAll();
            return View("AddNewEmp");
        }

        public IActionResult SaveNewEmp(Employee EmpFromReq)
        {
            if (EmpFromReq != null && EmpFromReq.Name != null && EmpFromReq.Address != null && EmpFromReq.DepartmentId != null)
            {
                empRepo.createOne(EmpFromReq);
                empRepo.SaveChanges();
                return RedirectToAction("Details");
            }
            else
            {
                return RedirectToAction("AddNewEmp", EmpFromReq);
            }
        }
    }

}
