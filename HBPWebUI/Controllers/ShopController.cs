using HBPUI.Library.Endpoint;
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
        private readonly IProductEndpoint _productEndpoint;

        public ShopController(ILogger<ShopController> logger, IBasketHelper basketHelper, IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _basketHelper = basketHelper;
            _productEndpoint = productEndpoint;
        }

        public IActionResult Basket()
        {
            BasketModel basket = _basketHelper.GetSessionBasket(HttpContext);

            return View(basket);
        }

        public IActionResult Remove(int name)
        {
            BasketModel basket = _basketHelper.GetSessionBasket(HttpContext);

            basket.BasketItems.Remove(basket.BasketItems.Find(x => x.Product.Id == name));
            _basketHelper.SetSessionBasket(HttpContext, basket);

            return View("Basket", basket);
        }

        public async Task<IActionResult> Increment(int name)
        {
            BasketModel basket = _basketHelper.GetSessionBasket(HttpContext);

            BasketItemModel currentBasketItem = basket.BasketItems.Find(x => x.Product.Id == name);
            ProductModel product = await _productEndpoint.GetProduct(currentBasketItem.Product.Id);

            if (currentBasketItem.QuantityInBasket + 1 > product.QuantityInStock)
            {
                // display message -> temp data or model state error
                return View("Basket", basket);
            }

            currentBasketItem.QuantityInBasket++;

            _basketHelper.SetSessionBasket(HttpContext, basket);

            return View("Basket", basket);
        }

        public async Task<IActionResult> Decrement(int name)
        {
            BasketModel basket = _basketHelper.GetSessionBasket(HttpContext);

            BasketItemModel currentBasketItem = basket.BasketItems.Find(x => x.Product.Id == name);
            ProductModel product = await _productEndpoint.GetProduct(currentBasketItem.Product.Id);

            if (currentBasketItem.QuantityInBasket - 1 <= 0)
            {
                // display message -> temp data or model state error
                return View("Basket", basket);
            }

            currentBasketItem.QuantityInBasket--;

            _basketHelper.SetSessionBasket(HttpContext, basket);

            return View("Basket", basket);
        }
    }
}
