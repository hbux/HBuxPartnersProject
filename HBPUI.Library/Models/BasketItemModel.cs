using System;
using System.Collections.Generic;
using System.Text;

namespace HBPUI.Library.Models
{
    public class BasketItemModel
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int QuantityInBasket { get; set; }
    }
}
