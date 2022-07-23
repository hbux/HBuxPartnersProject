using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBPUI.Library.Models
{
    public class BasketModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public List<BasketItemModel> BasketItems { get; set; } = new List<BasketItemModel>();
        public int TotalItems
        {
            get
            {
                return BasketItems.Sum(x => x.QuantityInBasket);
            }
        }
        public decimal Subtotal
        {
            get
            {
                return BasketItems.Sum(x => x.Product.RetailPrice * x.QuantityInBasket);
            }
        }
        public bool ShowPriceWarning
        {
            get
            {
                return Subtotal > 1000;
            }
        }

        public void AddToBasket(BasketItemModel basketItem)
        {
            BasketItemModel existingItem = BasketItems.FirstOrDefault(x => x.Product.Id == basketItem.Product.Id);

            if (existingItem == null)
            {
                BasketItems.Add(basketItem);
            }
            else
            {
                BasketItems.Find(x => x == existingItem).QuantityInBasket += basketItem.QuantityInBasket;
            }
        }
    }
}
