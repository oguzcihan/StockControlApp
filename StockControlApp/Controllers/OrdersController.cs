using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockControl.Business.Abstract;
using StockControl.Entity.Concrete;
using StockControlApp.Models;
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
        public IActionResult OrderProduct(int? id)
        {
            try
            {
                if (id != null)
                {
                    var entity = orderService.GetByIdOrder((int)id);
                    var model = new OrderViewModel();
                    foreach (var itemProduct in entity)
                    {
                        model.ProductId = itemProduct.Id;
                        model.ProductName = itemProduct.ProductName;
                    }

                    return View(model);
                }
                else
                {
                    var orderViewModel = new OrderViewModel();
                    var products = orderService.GetProductList();
                    ViewBag.ListProductName = new SelectList(products, "Id", "ProductName");
                    return View(orderViewModel);
                }
            }
            catch (Exception e)
            {
                return View();
            }
           
            
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
                        return RedirectToAction("ListOrder");
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
        [HttpGet]
        public IActionResult ListOrder()
        {
            var orderViewModel=new OrderListViewModel();
            var result = orderService.GetList();
            if (result.Success)
            {
                orderViewModel.OrdersList = result.Data;
                return View(orderViewModel);
            }
            return View(result.Message);
        }

        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                var result = orderService.Delete(order);
                if (result.Success)
                {
                    TempData["deleteOrderSuccess"] = result.Message;
                }
                return RedirectToAction("ListOrder");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Hata");
            }
           
        }
    }
}
