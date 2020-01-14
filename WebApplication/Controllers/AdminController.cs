using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult CreateStudent()
        {
            return View();
        }

        public IActionResult SubmitStudentAccount()
        {
            return RedirectToAction("");
        }
    }
}