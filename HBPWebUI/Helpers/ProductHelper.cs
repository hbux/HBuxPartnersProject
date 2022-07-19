using HBPUI.Library.Models;
using HBPWebUI.Models;
using System.Collections.Generic;

namespace HBPWebUI.Helpers
{
    public class ProductHelper : IProductHelper
    {
        public List<ProductViewModel> TranslateProducts(List<ProductModel> products)
        {
            List<ProductViewModel> translatedProducts = new List<ProductViewModel>();

            products.ForEach(x => translatedProducts.Add(TranslateProduct(x)));

            return translatedProducts;
        }

        public ProductViewModel TranslateProduct(ProductModel product)
        {
            return new ProductViewModel
            {
                Product = product
            };
        }
    }
}
