using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFruity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return Redirect("/Home/Login");
            }
            return View(_productService.GetAllProduct().ToList());
        }

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return Redirect("/Home/Login");
            }
            return View(_productService.GetProduct(id));
        }
    }
}
