using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage = "Name must be atleast 3 letters")]
        [MaxLength(30,ErrorMessage ="Maximum Number of letters is 30 letters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"(Alex|Cairo)",ErrorMessage = "Address Must Be Cairo or Alex")]
        public string Address { get; set; }
        [Required]
        [MaxLength(4,ErrorMessage ="Number Must Be atleast 4 Digits")]
        public required string Number { get; set; }
        [ForeignKey("Department")]
        [Display(Name="Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}