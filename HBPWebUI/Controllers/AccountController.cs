﻿using Microsoft.AspNetCore.Mvc;

namespace HBPWebUI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
