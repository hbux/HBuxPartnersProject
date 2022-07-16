using HBPUI.Library.Models;

namespace HBPWebUI.Models
{
    public class IndexViewModel
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
