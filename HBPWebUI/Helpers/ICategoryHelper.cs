using HBPUI.Library.Models;
using HBPWebUI.Models;
using System.Collections.Generic;

namespace HBPWebUI.Helpers
{
    public interface ICategoryHelper
    {
        List<CategoryViewModel> CreateNestedCategories(List<CategoryModel> ulCategories);
    }
}