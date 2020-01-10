using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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


        public IActionResult Privacy()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (HttpContext.Session.GetString("username")==null)
            {
                return RedirectToAction("Index", "Login");
            }
            string username = HttpContext.Session.GetString("username").ToString();
            string studentType = HttpContext.Session.GetString("userType");
            ViewData["userType"] = studentType;
            ViewData["username"] = username;

            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}