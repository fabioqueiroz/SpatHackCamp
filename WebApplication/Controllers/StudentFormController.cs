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
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"]= HttpContext.Session.GetString("userType");

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