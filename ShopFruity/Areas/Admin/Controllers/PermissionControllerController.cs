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
    public class PermissionController : Controller
    {
        private readonly IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        public IActionResult Index()
        {
            var result = _permissionService.GetAllPermission().ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Permission permission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _permissionService.InsertPermission(permission);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(permission);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Permission permission = _permissionService.GetPermission(id);
            return View(permission);
        }

        [HttpPost]
        public IActionResult Edit(Permission permission)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _permissionService.UpdatePermission(permission);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(permission);
        }

        public IActionResult Delete(int id)
        {
            _permissionService.DeletePermission(id);
            return RedirectToAction("Index");
        }
    }
}
