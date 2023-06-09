﻿using HBPUI.Library.Endpoint;
using HBPUI.Library.Models;
using HBPWebUI.Helpers;
using HBPWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class BrowseController : Controller
    {
        private readonly ILogger<BrowseController> _logger;
        private readonly IBasketHelper _basketHelper;
        private readonly ICategoryHelper _categoryHelper;
        private readonly IProductHelper _productHelper;
        private readonly ICategoryEndpoint _categoryEndpoint;
        private readonly IProductEndpoint _productEndpoint;

        public BrowseController(ILogger<BrowseController> logger, IBasketHelper basketHelper, ICategoryHelper categoryHelper,
            IProductHelper productHelper, ICategoryEndpoint categoryEndpoint, 
            IProductEndpoint productEndpoint)
        {
            _logger = logger;
            _basketHelper = basketHelper;
            _categoryHelper = categoryHelper;
            _productHelper = productHelper;
            _categoryEndpoint = categoryEndpoint;
            _productEndpoint = productEndpoint;
        }

        public async Task<IActionResult> Index()
        {
            List<CategoriesViewModel> allCategories = 
                _categoryHelper.CreateNestedCategories(await _categoryEndpoint.GetAllCategories());

            return View(allCategories);
        }

        public async Task<IActionResult> Categories(string category, string subcategory, string type)
        {
            if ((string.IsNullOrEmpty(category) == false) && string.IsNullOrEmpty(subcategory) || 
                string.IsNullOrEmpty(type))
            {
                return View("Category", category);
            }

            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(subcategory) || 
                string.IsNullOrEmpty(type))
            {
                return View("Index");
            }

            ViewData["Category"] = category;
            ViewData["Subcategory"] = subcategory;
            ViewData["Type"] = type;

            List<ProductViewModel> categoryProducts = 
                _productHelper.TranslateProducts(await _productEndpoint.GetAllProducts(type));

            return View(categoryProducts);
        }

        public async Task<IActionResult> Category(string category)
        {
            Dictionary<string, List<CategoryModel>> subcategories = 
                await _categoryEndpoint.GetCategory(category);

            ViewData["Category"] = category;

            return View(subcategories);
        }

        public async Task<IActionResult> Product(int name)
        {
            ProductViewModel product = 
                _productHelper.TranslateProduct(await _productEndpoint.GetProduct(name));

            return View(product);
        }

        public async Task<IActionResult> AddToBasket(ProductViewModel model)
        {
            ProductViewModel display = 
                _productHelper.TranslateProduct(await _productEndpoint.GetProduct(model.Product.Id));

            if (display.Product.QuantityInStock < model.Quantity)
            {
                ModelState.AddModelError("Quantity", $"We're sorry, we only have {display.Product.QuantityInStock} available.");
                return View("Product", display);
            }

            if (ModelState.IsValid)
            {
                BasketModel basket = _basketHelper.GetSessionBasket(HttpContext);

                basket.AddToBasket(new BasketItemModel()
                {
                    Product = display.Product,
                    QuantityInBasket = model.Quantity
                });

                _basketHelper.SetSessionBasket(HttpContext, basket);

                TempData["SuccessMessage"] = $"Added x{ model.Quantity } to basket!";

                return RedirectToAction("Product", new { name = display.Product.Id });
            }

            return View("Product", display);
        }
    }
}
