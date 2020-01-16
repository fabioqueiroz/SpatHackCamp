using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
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
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteStudent(string error)
        {
            return View();
        }

        public IActionResult SubmitDeleteAction(string studentEmailField)
        {
            MockDatabase mockDatabase = new MockDatabase();
            bool studentFound =  mockDatabase.DeleteStudentByEmail(studentEmailField);
            if (studentFound)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("DeleteStudent", "Admin",new {error= "The email has not been found in the database"});
        }
    }
}