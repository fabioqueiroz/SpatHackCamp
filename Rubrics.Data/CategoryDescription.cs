using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data
{
    public class CategoryDescription
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int DescriptionId { get; set; }
        public Category Category { get; set; }
        public Description Description { get; set; }
    }
}
