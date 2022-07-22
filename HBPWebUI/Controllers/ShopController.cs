using HBPUI.Library.Models;
using HBPWebUI.Extensions;
using HBPWebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        private readonly IBasketHelper _basketHelper;

        public ShopController(ILogger<ShopController> logger, IBasketHelper basketHelper)
        {
            _logger = logger;
            _basketHelper = basketHelper;
        }

        public IActionResult Basket()
        {
            BasketModel basket = _basketHelper.GetSessionBasket(HttpContext);

            return View(basket);
        }
    }
}
