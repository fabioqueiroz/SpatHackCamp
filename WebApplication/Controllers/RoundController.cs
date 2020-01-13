using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RoundController : Controller
    {
        public IActionResult CreateRound()
        {
            if (HttpContext.Session.GetString("username") == null)
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
        public IActionResult SubmitRound(IFormCollection form)
        {
            //take round details and all of the names
            //loop through the form until you get all the data
            RoundModel roundModel = new RoundModel();
            roundModel.ModuleName = form["moduleName"];
            List<SheetModel> markingSheets = new List<SheetModel>();
            SheetModel sheetModel = new SheetModel();
            sheetModel.Length = Int32.Parse(form["tableLength"]);
            sheetModel.Width = Int32.Parse(form["tableWidth"]);
            markingSheets.Add(sheetModel);
            roundModel.MarkingSheets = markingSheets;
            roundModel.Deadline = form["roundDeadline"];
            List<RubricModel> currentRubrics = new List<RubricModel>();
            for (var i = 1; i <= sheetModel.Width; i++)
            {
                for (var j = 1; j <= sheetModel.Length; j++)
                {
                    var inputName = "row" + i + "col" + j;
                    currentRubrics.Add(new RubricModel() {Name = form[inputName], Grade = j});
                }
            }

            Random random = new Random();
            roundModel.RoundId = random.Next(0, 101000);
            sheetModel.Rubrics = currentRubrics;
            //open file stream
            using (StreamWriter file = System.IO.File.AppendText(@"D:\data.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, roundModel);
                file.Write(Environment.NewLine);
            }

            //redirect home afterwards
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SelectStudentsToSendRound(int id)
        {
            ViewData["rubricId"] = id;
            return View();
        }

        public IActionResult SelectRoundTemplate()
        {
            return View();
        }

        public IActionResult SendRoundToStudents(int id)
        {
            //read mock data from file and duplicate the round with the same id 
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");
            RoundModel roundModel = null;
            foreach (string line in lines)
            {
                if (JsonConvert.DeserializeObject<RoundModel>(line).RoundId == id)
                {
                    roundModel = JsonConvert.DeserializeObject<RoundModel>(line);
                }
            }
            
            roundModel.Active = true;
            using (StreamWriter file = System.IO.File.AppendText(@"D:\data.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, roundModel);
                file.Write(Environment.NewLine);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}