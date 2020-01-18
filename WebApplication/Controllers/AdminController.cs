using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Business.Models;
using System;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILoginService _loginService;
        public AdminController(IStudentService studentService, ILoginService loginService)
        {
            _studentService = studentService;
            _loginService = loginService;
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitStudentAccount(IFormCollection form)
        {
            string firstName = form["firstNameInputUser"];
            string lastName = form["lastNameInputUser"];
            string gender = form["genderInputUser"];
            string dateOfBirth = form["dateOfBirthInputUser"];
            string email = form["emailInputUser"];
            string address1 = form["address1InputUser"];
            string city = form["cityInputUser"];
            string country = form["countryInputUser"];
            string postCode = form["postCodeInputUser"];
            string fullAddress = address1 + " , " + city + " , "
                                 + country + " , " + postCode;
            MockDatabase mockDatabase = new MockDatabase();
            mockDatabase.InsertStudentIntoTheDatabase(fullAddress);

            //var randomPassword = _studentService.CreateRandomPassword(6, true);
            // Create a default password by hashing the first name
            var defaultPassword = _loginService.SHA512ComputeHash(firstName);

            // Service logic
            var newStudent = new StudentFormModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = defaultPassword,
                // gender ???
                DOB = Convert.ToDateTime(dateOfBirth),
                Address = fullAddress
                
            };

            // Create a new student
            _studentService.CreateNewStudent(newStudent);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteStudent()
        {
            return View();
        }
    }
}