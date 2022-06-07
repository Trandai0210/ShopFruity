using Microsoft.AspNetCore.Mvc;
using ShopFruity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Controllers
{
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

        public IActionResult Details(int id)
        {
            return View(_postService.GetPost(id));
        }
    }
}
