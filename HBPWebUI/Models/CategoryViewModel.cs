using HBPUI.Library.Models;

namespace HBPWebUI.Models
{
    public class CategoryViewModel
    {
        private string _categoryName;
        private List<ProductModel> _products;

        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
            }
        }

        public List<ProductModel> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }
    }
}
