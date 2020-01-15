using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.General.Business.Models
{
    // This class maps the actual Student class in the table (Rubrics.Data class)
    public class StudentFormModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public int Score { get; set; }
    }
}
