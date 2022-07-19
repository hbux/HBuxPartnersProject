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
        public List<CategoriesViewModel> CreateNestedCategories(List<CategoryModel> ulCategories)
        {
            List<CategoriesViewModel> nestedCategories = new List<CategoriesViewModel>();

            List<CategoryModel> superordinates = ulCategories.FindAll(x => x.Level == 0);

            foreach (CategoryModel superordinate in superordinates)
            {
                CategoriesViewModel nestedCategory = new CategoriesViewModel();
                nestedCategory.Superordinate = superordinate;

                List<CategoryModel> basics = ulCategories.FindAll(x => x.Level == 1).Where(x => x.ParentId == superordinate.Id).ToList();
                
                foreach (CategoryModel basic in basics)
                {
                    List<CategoryModel> subordintes = new List<CategoryModel>();

                    foreach (CategoryModel subcategory in ulCategories.Where(x => x.ParentId == basic.Id))
                    {
                        subordintes.Add(subcategory);
                    }

                    nestedCategory.Subordinates.Add(basic.Title, subordintes);
                }

                nestedCategories.Add(nestedCategory);
            }

            return nestedCategories;
        }
    }
}
