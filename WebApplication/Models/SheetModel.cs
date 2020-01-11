using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace WebApplication.Models
{
    public class Sheet
    {
        private List<Rubric> rubrics;
        private List<Student> students;
        private Student studentMarked;

        public List<Rubric> Rubrics { get; set; }

        public List<Student> Students { get; set; }

        public Student StudentMarked { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }
}