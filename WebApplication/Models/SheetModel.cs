using System.Collections.Generic;
using Microsoft.Extensions.Primitives;

namespace WebApplication.Models
{
    public class SheetModel
    {
        public List<RubricModel> Rubrics { get; set; }

        public List<StudentModel> Students { get; set; }

        public StudentModel StudentModelMarked { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }
}