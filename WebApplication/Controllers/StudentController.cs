using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        // The index page for the Student Controller
        //should display all relevant information about a student
        public IActionResult Index(int id)
        {
            MockDatabase mockDatabase = new MockDatabase();
            ViewData["Student"] = mockDatabase.GetStudentDetailsFromId(id);
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
    }
}