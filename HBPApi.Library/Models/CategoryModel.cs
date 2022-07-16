using System;
using System.Collections.Generic;
using System.Text;

namespace HBPApi.Library.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
