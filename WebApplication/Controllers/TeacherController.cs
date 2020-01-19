using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using WebApplication.Helper;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITableGroupService _tableGroupService;
        private readonly IStudentService _studentService;
        public TeacherController(ITableGroupService tableGroupService, IStudentService studentService)
        {
            _tableGroupService = tableGroupService;
            _studentService = studentService;
        }
        /**
         * As a teacher I should be able to
         * see all the members of the group with which
         * a particular student is in
         */
        public IActionResult GroupMembers(int selectedGroup)
        {
            //get the students from the same group with 
            //the logged in student
            //the data we need from them is :
            MockDatabase mockDatabase = new MockDatabase();
            ViewData["GroupMembers"] = mockDatabase.GetStudentsFromGroupId(selectedGroup);
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"] = HttpContext.Session.GetString("userType");
            return View();
        }

        public IActionResult SelectGroup()
        {
            MockDatabase mockDatabase = new MockDatabase();
            ViewData["Groups"] =
                mockDatabase.GetGroupsForTeacher(HttpContext.Session.GetInt32("userId"));
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"] = HttpContext.Session.GetString("userType");
            return View();
        }


        public async Task<IActionResult> CreateTableGroup()
        {
            var displayStudents = new List<StudentModel>();

            MockDatabase mockDatabase = new MockDatabase();
            ViewData["studentsNotInGroup"] =
                mockDatabase.GetStudentsWithoutGroupForTeacherId(HttpContext.Session.GetInt32("userId"));

            var sessionUser = HttpContext.Session.GetObjectFromJson<TeacherModel>("LoggedUser");
            var teacherClassId = Convert.ToInt32(sessionUser.ClassId);

            // get students by class
            var students = await _studentService.AllStudentsInTheClass(teacherClassId);
            foreach (var item in students)
            {
                displayStudents.Add(new StudentModel {StudentId = item.Id, FirstName = item.FirstName, LastName = item.LastName });
            }
            // Uncomment to populate with real data
            //ViewData["studentsNotInGroup"] = displayStudents;

            return View();
        }

        [HttpPost]
        public IActionResult SubmitTableGroup(IFormCollection form)
        {           
            //get the number of students in a group
            int numberOfStudents = Int32.Parse(form["numberOfStudents"]);
            int[] ids = new int[numberOfStudents];
            //get the students ids from the form
            for (int index = 1; index <= numberOfStudents; index++)
            {
                //start the id-s array from 0 
                ids[index - 1] = Int32.Parse(form["selectedStudent" + index]);
            }

            //insert the data into the mock database
            MockDatabase mockDatabase = new MockDatabase();
            mockDatabase.CreateGroup(ids);

            // Send to service and persist in the db
            // Retrieve the session user
            var sessionUser = HttpContext.Session.GetObjectFromJson<TeacherModel>("LoggedUser");
            var teacherId = Convert.ToInt32(sessionUser.Id);

            string groupName = form["groupNameInput"];

            if (!string.IsNullOrEmpty(groupName))
            {
                var newTableGroup = new TableGroupInDb
                {
                    Name = groupName,
                    TeacherId = teacherId
                };

                // Create a table group
                _tableGroupService.CreateNewTableGroup(newTableGroup);

                

                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Index", new { error = "Please insert the name of the group." });
        }
    }
}