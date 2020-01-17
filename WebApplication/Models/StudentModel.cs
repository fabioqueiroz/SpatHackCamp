using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentId { get; set; }

        public string Email { get; set; }
        
        public string DateOfBirth { get; set; }
        public TableGroupModel TableGroup { get; set; }
        
        public Dictionary<int, List<RubricModel>> MarkingSheet { get; set; }
    }
}