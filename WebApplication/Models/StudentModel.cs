using System.Collections.Generic;

namespace WebApplication.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }
        
        private string email { get; set; }
        
        public Dictionary<int, List<RubricModel>> MarkingSheet { get; set; }
    }
}