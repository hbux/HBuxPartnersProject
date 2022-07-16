using System;
using System.Collections.Generic;
using System.Text;

namespace HBPApi.Library.Models
{
    public class NestedCategoryModel
    {
        public CategoryModel Superordinate { get; set; }
        public Dictionary<string, List<CategoryModel>> Subordinates { get; set; } 
            = new Dictionary<string, List<CategoryModel>>();
    }
}
