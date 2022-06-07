using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopFruity.Model.Entities;
using ShopFruity.Models;
using ShopFruity.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService, IUserService userService, IProductService productService)
        {
            _logger = logger;
            _accountService = accountService;
            _userService = userService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("UserId") == null)
            {
                return Redirect("/Home/Login");
            }
            List<Product> products = _productService.GetAllProduct().OrderByDescending(x => x.CreatedDate).Take(10).ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Account account = _accountService.GetAllAccount().SingleOrDefault(p => p.Username == username && p.Password == password);
            if(account != null)
            {
                HttpContext.Session.SetString("UserId", account.AccountId.ToString());
                Boolean isAdmin = account.PId == 1;
                if (isAdmin)
                    return Redirect("/Admin/Home");
                else
                    return RedirectToAction("Index");
            }
            ViewBag.message1 = "1";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string name, string address, string email, string phone)
        {
            if (ModelState.IsValid)
            {
                Boolean accountcheck = _accountService.GetAllAccount().SingleOrDefault(p => p.Username == username) == null;
                if (username == null || password == null || name == null || address == null || email == null || phone == null)
                {
                    ViewBag.message2 = "0";
                    return View();
                }
                if (accountcheck)
                {
                    int Id = _accountService.GetAllAccount().Max(a => a.AccountId) + 1;
                    Account account = new Account();
                    User user = new User();
                    account.AccountId = Id;
                    account.PId = 2;
                    account.Username = username;
                    account.Password = password;
                    account.CreatedDate = DateTime.Now;
                    account.UId = Id;

                    user.UserId = Id;
                    user.Name = name;
                    user.Address = address;
                    user.Email = email;
                    user.Phone = phone;

                    _userService.InsertUser(user);
                    _accountService.InsertAccount(account);
                    return RedirectToAction("Login");
                }
                ViewBag.message2 = "1";
                return View();
            }
            return View();
        }
    }
}
