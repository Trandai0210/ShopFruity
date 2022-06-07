using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return Redirect("/Home/Login");
            }
            return View();
        }
    }
}
