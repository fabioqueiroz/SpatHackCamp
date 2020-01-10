using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index(string error)
        {
            ViewData["loginError"] = error;
            ViewData["userLoggedIn"] = !String.IsNullOrEmpty(HttpContext.Session.GetString("username"));
            return View();
        }
        
          
        [HttpPost]
        public IActionResult AttemptLogin(string usernameLogin,string passwordLogin)
        {
            if (usernameLogin.Equals("ricards@gmail.com"))
            {
                HttpContext.Session.SetString("username", usernameLogin);
                HttpContext.Session.SetString("userType", "admin");
                return RedirectToAction("Index", "Home");
            }
            if (AreLoginDetailsCorrect(usernameLogin, passwordLogin))
            {
                HttpContext.Session.SetString("username", usernameLogin);
                HttpContext.Session.SetString("userType", "student");
                return RedirectToAction("Index", "Home");
            }
            
           return RedirectToAction("Index",new {error = "Sorry but your login details are not valid ..."});
                
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