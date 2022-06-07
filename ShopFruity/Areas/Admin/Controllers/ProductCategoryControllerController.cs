using Microsoft.AspNetCore.Mvc;
using ShopFruity.Model.Entities;
using ShopFruity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }
        public IActionResult Index()
        {
            return View(_productCategoryService.GetAllProductCategory().ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productCategory.CreatedDate = DateTime.Now;
                    _productCategoryService.InsertProductCategory(productCategory);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(productCategory);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_productCategoryService.GetProductCategory(id));
        }
        [HttpPost]
        public IActionResult Edit(ProductCategory productCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productCategory.UpdateDate = DateTime.Now;
                    _productCategoryService.UpdateProductCategory(productCategory);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(productCategory);
        }
    }
}
