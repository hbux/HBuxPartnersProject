using HBPUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBPWebUI.Models
{
    public class CategoryViewModel
    {
        public CategoryModel Superordinate { get; set; }
        public Dictionary<string, List<CategoryModel>> Subordinates { get; set; }
            = new Dictionary<string, List<CategoryModel>>();
    }
}
