using HBPUI.Library.Models;

namespace HBPWebUI.Helpers
{
    public interface IBasketHelper
    {
        BasketModel GetSessionBasket(HttpContext context);
        void SetSessionBasket(HttpContext context, BasketModel basket);
    }
}