using HBPUI.Library.Models;

namespace HBPWebUI.Models
{
    public class ItemViewModel
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
