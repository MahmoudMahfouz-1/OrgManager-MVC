using Microsoft.EntityFrameworkCore;
using MVC_Core.Models;

namespace MVC_Core.Reposatoires
{
    public class EmployeeReposatory : IEmployeeReposatory
    {
        ApplicationDbContext context;
        public EmployeeReposatory(ApplicationDbContext context)
        {
            this.context = context;
        }
        // CRUD Operations 
        public List<Employee> GetAll()
        {
            var employeeList = context.Employee.ToList();
            return employeeList;
        }
        public Employee GetById(int id)
        {
            var employee = context.Employee.FirstOrDefault(x => x.Id == id);
            return employee;
        }
        public void createOne(Employee employee)
        {
            context.Employee.Add(employee);
        }

        public void updateOne(Employee employee)
        {
            context.Employee.Update(employee);
        }

        public void deleteOne(int id)
        {
            var employee = GetById(id);
            context.Employee.Remove(employee);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public List<Employee> GetEmpWithDeptId()
        {
            var emps = context.Employee.Include(e => e.Department).ToList();
            return emps;
        }
    }
}
