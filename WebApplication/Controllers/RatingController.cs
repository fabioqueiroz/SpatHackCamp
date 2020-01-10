using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Rate(int id)
        {
            ViewData["id"] = id;
            if (HttpContext.Session.GetString("username")==null)
            {
                return RedirectToAction("Index", "Login");
            }
            string username = HttpContext.Session.GetString("username").ToString();
            string studentType = HttpContext.Session.GetString("userType");
            ViewData["userType"] = studentType;
            ViewData["username"] = username;

            return View();
        }
        
    }
}