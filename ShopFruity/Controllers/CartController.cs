using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopFruity.Model.Entities;
using ShopFruity.Models;
using ShopFruity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFruity.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public CartController(IProductService productService, IUserService userService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _userService = userService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return Redirect("/Home/Login");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            List<CartItem> carts = null;
            if (HttpContext.Session.Get<List<CartItem>>("Cart") == null)
            {
                carts = new List<CartItem>();
                carts.Add(new CartItem { ProductOrder = _productService.GetProduct(id), Quantity = 1 });
            }
            else
            {
                carts = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("Cart");
                CartItem product = carts.SingleOrDefault(x => x.ProductOrder.ProductId == id);
                if (product != null)//đã có sản phẩm cần add trong giỏ hàng
                    product.Quantity++;
                else
                    carts.Add(new CartItem { ProductOrder = _productService.GetProduct(id), Quantity = 1 });
            }
            //Cập nhật lại session
            HttpContext.Session.Set<List<CartItem>>("Cart", carts);
            //Trả về tổng số lượng hàng hóa cần mua
            return Json(new { total = carts.Sum(x => x.Quantity) });
        }
        [HttpGet]
        public IActionResult ShoppingCart()
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                return Redirect("/Home/Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Order()
        {
            if(HttpContext.Session.Get<List<CartItem>>("Cart") == null)
            {
                return Redirect("/Home/Login");
            }
            List<CartItem> carts = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("Cart");
            return View(carts);
        }
        [HttpPost]
        public IActionResult Order(string hoten, string diachi, string email, string dienthoai, string ghichu)
        {
            Order order = new Order();
            order.OrderId = _orderService.GetAllOrder().Max(o => o.OrderId) + 1;
            order.UserId = HttpContext.Session.GetString("UserID") == null ? 1 : int.Parse(HttpContext.Session.GetString("UserID"));
            order.CustomerMessage = ghichu;
            order.CreatedDate = DateTime.Now;
            //Lệnh thêm Order vào trong database
            _orderService.InsertOrder(order);
            //Lưu chi tiết đơn đặt hàng
            List<CartItem> carts = (List<CartItem>)HttpContext.Session.Get<List<CartItem>>("Cart");
            int OrderDetailId = _orderDetailService.GetAllOrderDetail().Max(o => o.OrderDetailId);
            foreach (var item in carts)
            {
                OrderDetailId++;
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderDetailId = OrderDetailId;
                orderDetail.OrderId = order.OrderId;
                orderDetail.ProductId = item.ProductOrder.ProductId;
                orderDetail.Quantity = item.Quantity;
                _orderDetailService.InsertOrderDetail(orderDetail);
            }

            HttpContext.Session.Set<List<CartItem>>("Cart", null);
            return Redirect("/Cart/OrderConfirm");
        }

        public IActionResult OrderConfirm()
        {
            return View();
        }
    }
}
