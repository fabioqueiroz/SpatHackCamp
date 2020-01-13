using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class PendingItemsController : Controller
    {
        // GET
        //this method should not be used as it makes
        //no sense on this page
        public IActionResult Index()
        {
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
        
        //GET
        public IActionResult CurrentItems(int id)
        {
            if (HttpContext.Session.GetString("username")==null)
            {
                return RedirectToAction("Index", "Login");
            }
            string username = HttpContext.Session.GetString("username").ToString();
            string studentType = HttpContext.Session.GetString("userType");
            ViewData["userType"] = studentType;
            ViewData["username"] = username;
            
            return View(id);
        }
        
    }
}