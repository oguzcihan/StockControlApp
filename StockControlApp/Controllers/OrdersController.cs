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
        public IActionResult OrderProduct()
        {
            var orderViewModel = new OrderViewModel();
            var products = orderService.GetProductList();
            ViewBag.ListProductName = new SelectList(products, "Id", "ProductName");
            return View(orderViewModel);
        }
        [HttpPost]
        public IActionResult OrderProduct(OrderViewModel orderViewModel)
        {
            try
            {
                Order order = new Order();
                if (ModelState.IsValid)
                {
                    order.EmployeeName = orderViewModel.EmployeeName;
                    order.OrderAmount=orderViewModel.OrderAmount;
                    order.ProductId = orderViewModel.ProductId;
                    var result = orderService.Add(order);
                    if (result.Success)
                    {
                        TempData["addOrderSuccess"] = result.Message;
                        return RedirectToAction("ListProduct","Product");
                    }
                    else if(result.Success==false)
                    {
                        TempData["productOverAmount"] = result.Message;
                        return RedirectToAction("OrderProduct");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
