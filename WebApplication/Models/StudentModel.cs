using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public Dictionary<int, List<Rubric>> MarkingSheet { get; set; }
    }
}