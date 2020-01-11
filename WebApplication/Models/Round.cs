using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Round
    {
        public List<Sheet> markingSheets { get; set; }
        public string Deadline { get; set; }
        public string ModuleName { get; set; }
        public int roundID { get; set; }
        public bool active { get; set; }
    }
}