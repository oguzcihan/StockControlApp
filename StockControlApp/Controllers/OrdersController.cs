using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockControl.Business.Abstract;
using StockControl.Entity.Concrete;
using StockControlApp.Models.ViewModels;

namespace StockControlApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService _orderService)
        {
            orderService = _orderService;
        }
        [HttpGet]
        public IActionResult OrderProduct(OrderViewModel orderViewModel)
        {
            var products = orderService.GetProductList();
            orderViewModel.ProductSelectList = new SelectList(products, "Id", "ProductName","Seçiniz");
            return View(orderViewModel);
        }
        [HttpPost]
        public IActionResult OrderProduct(Order order)
        {
            return View();
        }

        public IActionResult ListOrder()
        {
            return View();
        }

        public IActionResult DeleteOrder()
        {
            return RedirectToAction("ListOrder");
        }
    }
}
