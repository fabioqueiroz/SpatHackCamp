using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentFormController : Controller
    {
        // GET
        public IActionResult CompleteForm(int id)
        {
            ViewData["sheetId"] = id;
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

        [HttpPost]
        public IActionResult SubmitForm(IFormCollection form )
        {
            //get the marking sheet and then insert the appropriate value 
            //the teacher should be responsible for creating the actual marking sheet
            return RedirectToAction("Index", "Home");
        }

    }
}