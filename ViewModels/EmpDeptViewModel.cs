using System.ComponentModel.DataAnnotations.Schema;
using MVC_Core.Models;

namespace MVC_Core.ViewModels
{
    public class EmpDeptViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }
    }
}
