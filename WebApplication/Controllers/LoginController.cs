using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using WebApplication.Helper;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILoginService _loginService;
        public LoginController(IStudentService studentService, ILoginService loginService)
        {
            _studentService = studentService;
            _loginService = loginService;
        }

        // GET       
        public IActionResult Index(string error)
        {
            ViewData["loginError"] = error;

            ViewData["userLoggedIn"] = !string.IsNullOrEmpty(HttpContext.Session.GetString("username"));

            return View();
        }

        // ****** Remove the comments of the method below so you don't need to care about a db connection ******
        //****** and comment out the other version below this one that's using live data so you don't get confused ******

        //[HttpPost]
        //public IActionResult AttemptLogin(string usernameLogin,string passwordLogin)
        //{
        //    if (usernameLogin.Equals("ricards@gmail.com") || usernameLogin.Equals("t@test.com"))
        //    {
        //        HttpContext.Session.SetString("username", usernameLogin);
        //        HttpContext.Session.SetString("userType", "admin");
        //        HttpContext.Session.SetInt32("userId", 1);

        //        return RedirectToAction("Index", "Home");

        //    }

        //    if (usernameLogin.Equals("fabio@gmail.com"))
        //    {
        //        HttpContext.Session.SetString("username", usernameLogin);
        //        HttpContext.Session.SetString("userType", "teacher");
        //        HttpContext.Session.SetInt32("userId", 2);
        //        return RedirectToAction("Index", "Home");
        //    }

        //    if (AreLoginDetailsCorrect(usernameLogin, passwordLogin))
        //    {
        //        HttpContext.Session.SetString("username", usernameLogin);
        //        HttpContext.Session.SetString("userType", "student");
        //        HttpContext.Session.SetInt32("userId", 3);
        //        return RedirectToAction("Index", "Home");
        //    }


        //    return RedirectToAction("Index",new {error = "Sorry but your login details are not valid ..."});

        //}

        [HttpPost]
        public IActionResult AttemptLogin(string usernameLogin, string passwordLogin)
        {
            // Determine which level of access the user has
            var userId = _loginService.LoginValidation(usernameLogin, passwordLogin); 

            if (userId == 1)
            {
                HttpContext.Session.SetString("username", usernameLogin);
                HttpContext.Session.SetString("userType", "admin");
                HttpContext.Session.SetInt32("userId", 1);

                // Store the whole that represents the entity in the session
                var loggedUser = _loginService.GetAdminByEmail(usernameLogin);
                HttpContext.Session.SetObjectAsJson("LoggedUser", loggedUser);

                return RedirectToAction("Index", "Home");
            }

            if (userId == 2)
            {
                HttpContext.Session.SetString("username", usernameLogin);
                HttpContext.Session.SetString("userType", "teacher");
                HttpContext.Session.SetInt32("userId", 2);

                var loggedUser = _loginService.GetTeacherByEmail(usernameLogin);
                HttpContext.Session.SetObjectAsJson("LoggedUser", loggedUser);

                return RedirectToAction("Index", "Home");
            }

            if (userId == 3)
            {
                HttpContext.Session.SetString("username", usernameLogin);
                HttpContext.Session.SetString("userType", "student");
                HttpContext.Session.SetInt32("userId", 3);

                var loggedUser = _studentService.GetStudentByEmail(usernameLogin);
                HttpContext.Session.SetObjectAsJson("LoggedUser", loggedUser);

                return RedirectToAction("Index", "Home");
            }


            return RedirectToAction("Index", new { error = "Sorry but your login details are not valid ..." });

        }

        //use this method to check if the login details are valid 
        private bool AreLoginDetailsCorrect(string username,string password)
        {
            
            Dictionary<string,string> accounts = new Dictionary<string, string>();
            accounts.Add("avramandreitiberiu@gmail.com","andrei1239");
            accounts.Add("andreiavram2008@yahoo.com","andrei1239");

            foreach (var entry in accounts)
            {
                string usermaneDB = entry.Key;
                string passwordDB = entry.Value;
                if (usermaneDB.Equals(username) && passwordDB.Equals(password))
                {
                    return true;
                }
            }

            return false;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("userType");
            return RedirectToAction("Index");
        }
    }
}