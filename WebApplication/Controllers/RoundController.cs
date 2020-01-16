using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rubrics.General.Models;
using WebApplication.Models;
using WebApplication.ViewModels;

namespace WebApplication.Controllers
{
    public class RoundController : Controller
    {
        public RoundController()
        {

        }
        public IActionResult CreateRound()
        {
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
        public IActionResult SubmitRound(IFormCollection form)
        {
            //take round details and all of the names
            //loop through the form until you get all the data
            RoundModel round = new RoundModel();
            round.ModuleName = form["moduleName"];
            List<SheetModel> markingSheets = new List<SheetModel>();
            SheetModel sheet = new SheetModel();
            sheet.Height = Int32.Parse(form["tableHeight"]);
            markingSheets.Add(sheet);
            round.MarkingSheets = markingSheets;
            round.Deadline = form["roundDeadline"];
            List<RubricModel> currentRubrics = new List<RubricModel>();
            for (var i = 1; i <=sheet.Height; i++)
            {
                for (var j = 1; j <= 5; j++)
                {
                    var inputName = "row" + i + "col" + j;
                    currentRubrics.Add(new RubricModel() {Name = form[inputName], Grade = j-1});
                }
            }

            Random random = new Random();
            round.RoundId = random.Next(0, 101000);
            sheet.Rubrics = currentRubrics;
            //open file stream
            using (StreamWriter file = System.IO.File.AppendText(@"D:\data.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, round);
                file.Write(Environment.NewLine);
            }

            List<CategoryModel> categories = new List<CategoryModel>();
            List<DescriptionModel> descriptions = new List<DescriptionModel>();
            // send to the service
            foreach (var array in currentRubrics)
            {
                var arr = array;

                if (array.Grade == 1 && !array.Name.Equals(""))
                {
                    categories.Add(new CategoryModel { Name = array.Name});
                }
                else
                {
                    if (!array.Name.Equals(""))
                    {
                        descriptions.Add(new DescriptionModel { Scale = (array.Grade - 1), Description = array.Name }); 
                    }
                }
            }
            //redirect home afterwards
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SelectStudentsToSendRound(int id)
        {
            ViewData["rubricId"] = id;
            
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"]= HttpContext.Session.GetString("userType");
            return View();
        }

        public IActionResult SelectRoundTemplate()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["userId"] = HttpContext.Session.GetInt32("userId");
            ViewData["username"] = HttpContext.Session.GetString("username").ToString();
            ViewData["userType"]= HttpContext.Session.GetString("userType");
            return View();
        }

        public IActionResult SendRoundToStudents(int id)
        {
            //read mock data from file and duplicate the round with the same id 
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");
            RoundModel round = null;
            foreach (string line in lines)
            {
                if (JsonConvert.DeserializeObject<RoundModel>(line).RoundId == id)
                {
                    round = JsonConvert.DeserializeObject<RoundModel>(line);
                }
            }
            
            round.Active = true;
            using (StreamWriter file = System.IO.File.AppendText(@"D:\data.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, round);
                file.Write(Environment.NewLine);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}