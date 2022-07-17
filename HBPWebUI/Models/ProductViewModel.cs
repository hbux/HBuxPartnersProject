using HBPUI.Library.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HBPWebUI.Models
{
    public class ProductViewModel
    {
        [BindProperty]
        public ProductModel Product { get; set; }

        [BindProperty]
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; } = 1;
    }
}
