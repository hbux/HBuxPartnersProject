using HBPUI.Library.Models;

namespace HBPWebUI.Models
{
    public class ProductViewModel
    {
        private List<ProductModel> _products;

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
