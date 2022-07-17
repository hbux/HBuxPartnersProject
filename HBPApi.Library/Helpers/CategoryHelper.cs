using HBPApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HBPApi.Library.Helpers
{
    public class CategoryHelper : ICategoryHelper
    {
        /// <summary>
        /// Creates an ordered list of categories. 
        /// </summary>
        /// <param name="ulCategories">An unordered list of all categories</param>
        /// <returns>A list of ordered categories</returns>
        public List<NestedCategoryModel> CreateNestedCategories(List<CategoryModel> ulCategories)
        {
            List<NestedCategoryModel> nestedCategories = new List<NestedCategoryModel>();

            List<CategoryModel> superordinates = ulCategories.FindAll(x => x.Level == 0);

            foreach (CategoryModel superordinate in superordinates)
            {
                NestedCategoryModel nestedCategory = new NestedCategoryModel();
                nestedCategory.Superordinate = superordinate;

                List<CategoryModel> basics = ulCategories.FindAll(x => x.Level == 1);
                
                foreach (CategoryModel basic in basics)
                {
                    List<CategoryModel> subordinates = ulCategories
                        .FindAll(x => x.Level == 2)
                        .Where(x => x.ParentId == basic.Id).ToList();

                    nestedCategory.Subordinates.Add(basic.Title, subordinates);
                }

                nestedCategories.Add(nestedCategory);
            }

            return nestedCategories;
        }
    }
}
