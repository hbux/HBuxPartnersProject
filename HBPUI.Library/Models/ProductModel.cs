﻿using System;
using System.Collections.Generic;
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
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
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
                return Photos[0];
            }
        }
    }
}
