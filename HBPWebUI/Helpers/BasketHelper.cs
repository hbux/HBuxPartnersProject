using HBPUI.Library.Models;
using HBPWebUI.Extensions;

namespace HBPWebUI.Helpers
{
    public class BasketHelper : IBasketHelper
    {
        public BasketModel GetSessionBasket(HttpContext context)
        {
            BasketModel basket = context.Session.Get<BasketModel>();

            if (basket == null)
            {
                return new BasketModel();
            }

            return basket;
        }

        public void SetSessionBasket(HttpContext context, BasketModel basket)
        {
            context.Session.Set<BasketModel>(basket);
        }
    }
}
