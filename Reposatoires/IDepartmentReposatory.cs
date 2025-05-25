using MVC_Core.Models;

namespace MVC_Core.Reposatoires
{
    public interface IDepartmentReposatory
    {
        public List<Department> GetAll();

        public Department GetById(int id);

        public void createOne(Department department);


        public void updateOne(Department department);


        public void deleteOne(int id);


        public void SaveChanges();

    }
}
