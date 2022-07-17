using HBPUI.Library.Models;

namespace HBPWebUI.Models
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public List<ProductModel> Products { get; set; }
        public bool ShowNoProductsFound => Products.Count == 0;
    }
}
