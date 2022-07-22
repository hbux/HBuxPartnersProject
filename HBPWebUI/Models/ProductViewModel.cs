using HBPUI.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HBPWebUI.Models
{
    public class ProductViewModel
    {
        [TempData]
        public string ErrorMessage { get; set; }

        [BindProperty]
        public ProductModel Product { get; set; }

        [BindProperty]
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; } = 1;
    }
}
