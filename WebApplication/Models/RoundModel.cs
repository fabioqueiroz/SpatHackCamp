using System.Collections.Generic;

namespace WebApplication.Models
{
    public class RoundModel
    {
        public List<SheetModel> MarkingSheets { get; set; }
        public string Deadline { get; set; }
        public string ModuleName { get; set; }
        public int RoundId { get; set; }
        public bool Active { get; set; }
    }
}