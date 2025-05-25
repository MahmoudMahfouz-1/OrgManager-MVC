using Microsoft.AspNetCore.Mvc;

namespace MVC_Core.Controllers
{
    public class StateController : Controller
    {
        // Stores the data at Client Side 
        public IActionResult SetCookie()
        {
            HttpContext.Response.Cookies.Append("Name", "Mahmoud");
            HttpContext.Response.Cookies.Append("Age", "24");

            return Content("Cookies Saved");
        }

        public IActionResult GetCookie()
        {
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"Hello {name} Age: {age}");
        }



    }
}
