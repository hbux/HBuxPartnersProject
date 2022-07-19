using HBPUI.Library.Models;
using HBPWebUI.Models;
using System.Collections.Generic;

namespace HBPWebUI.Helpers
{
    public interface ICategoryHelper
    {
        List<CategoriesViewModel> CreateNestedCategories(List<CategoryModel> ulCategories);
    }
}