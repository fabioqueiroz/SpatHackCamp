using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rubrics.Data;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        // The index page for the Student Controller
        //should display all relevant information about a student
        public IActionResult Index(int id)
        {
            //change the type from Student in db to normal student
            ViewData["Student"] = _studentService.GetStudentById(id);
            
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"] = HttpContext.Session.GetString("userType");
            return View();
        }

        public IActionResult PastRounds()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"] = HttpContext.Session.GetString("userType");

            //insert the data into the ViewData object 
            //and send it to the view
            //insert static data for now
            int[] grades = new[] {30, 80, 76};
            List<RoundModel> pastRounds = new List<RoundModel>();
            pastRounds.Add(new RoundModel() {ModuleName = "Maths", Active = false, Deadline = "12/1/2020"});
            pastRounds.Add(new RoundModel() {ModuleName = "Romanian", Active = false, Deadline = "10/1/2020"});
            pastRounds.Add(new RoundModel() {ModuleName = "History", Active = false, Deadline = "5/12/2019"});
            ViewData["Grades"] = grades;
            ViewData["PastRounds"] = pastRounds;
            return View();
        }

        public IActionResult Profile()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"] = HttpContext.Session.GetString("userType");
            MockDatabase mockDatabase = new MockDatabase();
            ViewData["student"] = mockDatabase.GetUserProfileFromId(HttpContext.Session.GetInt32("userId"));
            return View();
        }

        [HttpPost]
        public IActionResult SubmitPasswordChange(string passwordField)
        {
            string newPassword = passwordField;
            return RedirectToAction("Profile", "Student");
        }
    }
}