﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ClassId { get; set; }
    }
}
