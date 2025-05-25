using System.ComponentModel.DataAnnotations;

namespace MVC_Core.ViewModels
{
    public class LoginUserViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
