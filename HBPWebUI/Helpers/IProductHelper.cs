using HBPUI.Library.Models;
using HBPWebUI.Models;
using System.Collections.Generic;

namespace HBPWebUI.Helpers
{
    public interface IProductHelper
    {
        ProductViewModel TranslateProduct(ProductModel product);
        List<ProductViewModel> TranslateProducts(List<ProductModel> products);
    }
}