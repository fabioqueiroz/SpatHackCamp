using Microsoft.AspNetCore.Mvc;
using Rubrics.Data.Access;
using Rubrics.General.Business.Interfaces;
using Rubrics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Rubrics.Controllers
{
    [Route("test-data")]
    public class TestController : Controller
    {

        private ITestService _testService;
        private IStudentService _studentService;
        public TestController(ITestService testService, IStudentService studentService)
        {
            _testService = testService;
            _studentService = studentService;
        }

        // Using raw sql
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Test using LINQ
                var linqTest = _studentService.GetTestJoinsUsingLinq();

                // Test using Dapper
                var dapperTest = await _studentService.GetTestJoinsUsingDapper();

                // Query the db and store all data retrieved
                var students = _studentService.GetAllTheStudents();

                // Bind the data attibutes to a model used to display the data on the front
                var displayStudents = students.Select(x => new TestViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Score = x.Score

                }).ToList(); // This method converts all the data into a collection 

                return View(displayStudents);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}
