using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TeacherController : Controller
    {
        /**
         * As a teacher I should be able to
         * see all the members of the group with which
         * a particular student is in
         */
        public IActionResult GroupMembers(int selectedGroup)
        {
            //get the students from the same group with 
            //the logged in student
            //the data we need from them is :
            MockDatabase mockDatabase = new MockDatabase();
            ViewData["GroupMembers"] = mockDatabase.GetStudentsFromGroupId(selectedGroup);
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"]= HttpContext.Session.GetString("userType");
            return View();
        }

        public IActionResult SelectGroup()
        {
            MockDatabase mockDatabase = new MockDatabase();
            ViewData["Groups"] =
                mockDatabase.GetGroupsForTeacher(HttpContext.Session.GetInt32("userId"));
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"]= HttpContext.Session.GetString("userType");
            return View();
        }
    }
}