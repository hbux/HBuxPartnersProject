using System;
using System.Collections.Generic;
using System.Text;

namespace HBPUI.Library.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public int Level { get; set; }
    }
}
