using HBPUI.Library.Models;

namespace HBPWebUI.Models
{
    public class ProductViewModel
    {
        private ProductModel _product;

        public ProductModel Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }
    }
}
