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
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductService _productService;
        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
            _orderDetailService = orderDetailService;
        }
        public IActionResult Index()
        {
            return View(_orderService.GetAllOrder().ToList());
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Order order = _orderService.GetOrder(id);
            ShopFruityDBContext context = new ShopFruityDBContext();
            List<OrderDetail> orderDetails = context.OrderDetails.Where(o => o.OrderId == id).ToList();
            var tuple = new Tuple<Order, List<OrderDetail>>(order, orderDetails);
            return View(tuple);
        }

        public IActionResult Accept(int id)
        {
            ShopFruityDBContext context = new ShopFruityDBContext();
            Order order = _orderService.GetOrder(id);
            order.Status = true;
            _orderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }
    }
}
