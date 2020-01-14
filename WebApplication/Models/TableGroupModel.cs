namespace WebApplication.Models
{
    public class TableGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //each TableGroup should belong to the a single 
        //class
        public string ClassName{ get; set; }
    }
}