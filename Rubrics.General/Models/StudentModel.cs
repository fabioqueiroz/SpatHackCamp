using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.General.Business.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Score { get; set; }
    }
}
