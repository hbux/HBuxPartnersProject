using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBPUI.Library.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
        public bool IsInStock
        {
            get
            {
                if (QuantityInStock > 0)
                {
                    return true;
                }

                return false;
            }
        }
        public PhotoModel Thumbnail
        {
            get
            {
                return Photos.FirstOrDefault();
            }
        }

        public string ShortName
        {
            get
            {
                if (Name.Length > 25)
                {
                    return $"{Name.Substring(0, 25).Trim()}...";
                }

                return Name;
            }
        }
    }
}
