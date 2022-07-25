using Microsoft.AspNetCore.Mvc;
using StockControl.Business.Abstract;
using StockControl.Entity.Concrete;
using StockControlApp.Models.ViewModels;

namespace StockControlApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel productView)
        {
            /*
             * ViewModel kullanılma sebebi sadece gösterim için bir class kullanmaktır. Hem güvenlik hem de SOLID prensibidir.
             */
            try
            {
                Product product = new Product();
                if (ModelState.IsValid)
                {
                    product.ProductName = productView.ProductName;
                    product.Price = productView.Price;
                    product.Amount = productView.Amount;
                    var result = productService.Add(product);
                    if (result.Success)
                    {
                        TempData["addProductSuccess"] = result.Message;
                        return RedirectToAction("ListProduct");
                    }

                }
                else
                {
                    //exception
                }
            }
            catch (Exception e)
            {
                return View("AddProduct", productView);
            }
            return BadRequest("Hatalı İşlem");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var entity = productService.GetById((int)id);
                var model = new ProductViewModel()
                {
                    ProductName = entity.Data.ProductName,
                    Price = entity.Data.Price,
                    Amount = entity.Data.Amount,

                };
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Hata");
            }
            
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                var result = productService.Update(product);
                if (result.Success)
                {
                    TempData["updateProductSuccess"] = result.Message;
                    return RedirectToAction("ListProduct");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Hata:"+e);
            }
            return BadRequest("Hatalı İşlem");
        }

        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                var result = productService.Delete(product);
                if (result.Success)
                {
                    TempData["deleteProductSuccess"] = result.Message;
                }
                return RedirectToAction("ListProduct");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Hata");
            }
            
        }

        [HttpGet]
        public IActionResult ListProduct()
        {
            //Listele methodu
            var viewModel=new ProductListViewModel();
            var result = productService.GetList();
            if (result.Success)
            {
                viewModel.Products = result.Data;
                return View(viewModel);
            }

            return View(result.Message);


        }
    }
}
