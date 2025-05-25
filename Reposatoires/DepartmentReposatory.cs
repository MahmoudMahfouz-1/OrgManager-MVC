using MVC_Core.Models;

namespace MVC_Core.Reposatoires
{
    public class DepartmentReposatory : IDepartmentReposatory
    {
        ApplicationDbContext context;
        public DepartmentReposatory(ApplicationDbContext context)
        {
            this.context = context;
        }
        // CRUD Operations 
        public List<Department> GetAll()
        {
            var departmentList = context.Department.ToList();
            return departmentList;
        }
        public Department GetById(int id)
        {
            var department = context.Department.FirstOrDefault(x => x.Id == id);
            return department;
        }
        public void createOne(Department department)
        {
            context.Department.Add(department);
        }

        public void updateOne(Department department)
        {
            context.Department.Update(department);
        }

        public void deleteOne(int id)
        {
            var dept = GetById(id);
            context.Department.Remove(dept);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
