using MVC_Core.Models;

namespace MVC_Core.Reposatoires
{
    public interface IEmployeeReposatory
    {

        public List<Employee> GetAll();

        public Employee GetById(int id);

        public void createOne(Employee employee);


        public void updateOne(Employee employee);


        public void deleteOne(int id);


        public void SaveChanges();

        public List<Employee> GetEmpWithDeptId();

    }
}
