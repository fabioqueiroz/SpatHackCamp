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
        public IActionResult SubmitRound(IFormCollection form)
        {
            //take round details and all of the names
            //loop through the form until you get all the data
            Round round = new Round();
            round.ModuleName = form["moduleName"];
            List<Sheet> markingSheets = new List<Sheet>();
            Sheet sheet = new Sheet();
            sheet.Length = Int32.Parse(form["tableLength"]);
            sheet.Width = Int32.Parse(form["tableWidth"]);
            markingSheets.Add(sheet);
            round.markingSheets = markingSheets;
            round.Deadline = form["roundDeadline"];
            List<Rubric> currentRubrics = new List<Rubric>();
            for (var i = 1; i <= sheet.Width; i++)
            {
                for (var j = 1; j <= sheet.Length; j++)
                {
                    var inputName = "row" + i + "col" + j;
                    currentRubrics.Add(new Rubric() {Name = form[inputName], Grade = j});
                }
            }

            Random random = new Random();
            round.roundID = random.Next(0,101000);
            sheet.Rubrics = currentRubrics;
            //open file stream
            using (StreamWriter file = System.IO.File.AppendText(@"D:\data.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, round);
                file.Write(Environment.NewLine);
            }

            //redirect home afterwards
            return RedirectToAction("Index", "Home");
        }
    }
}