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
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            return View(_postService.GetAllPost().ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.CreatedDate = DateTime.Now;
                    post.ViewCount = 0;
                    _postService.InsertPost(post);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(post);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_postService.GetPost(id));
        }
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.UpdateDate = DateTime.Now;
                    _postService.UpdatePost(post);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(post);
        }

        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}
