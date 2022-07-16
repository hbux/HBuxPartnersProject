using HBPApi.Library.Models;
using System.Collections.Generic;

namespace HBPApi.Library.Helpers
{
    public interface ICategoryHelper
    {
        List<NestedCategoryModel> CreateNestedCategories(List<CategoryModel> ulCategories);
    }
}