using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HBPUI.Library.Models;
using HBPWebUI.Models;

namespace HBPWebUI.Helpers
{
    public class CategoryHelper : ICategoryHelper
    {
        /// <summary>
        /// Creates an ordered list of categories. 
        /// </summary>
        /// <param name="ulCategories">An unordered list of all categories</param>
        /// <returns>A list of ordered categories</returns>
        public List<CategoryViewModel> CreateNestedCategories(List<CategoryModel> ulCategories)
        {
            List<CategoryViewModel> nestedCategories = new List<CategoryViewModel>();

            List<CategoryModel> superordinates = ulCategories.FindAll(x => x.Level == 0);

            foreach (CategoryModel superordinate in superordinates)
            {
                CategoryViewModel nestedCategory = new CategoryViewModel();
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
