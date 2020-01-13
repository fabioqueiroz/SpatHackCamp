using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SelectGroup()
        {
            return View();
        }
    }
}