using System;
using System.Collections.Generic;
using System.Text;

namespace HBPUI.Library.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { private get; set; }
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
    }
}
