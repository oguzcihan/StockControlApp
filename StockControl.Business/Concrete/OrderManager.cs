using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using StockControl.Business.Abstract;
using StockControl.Business.Constants;
using StockControl.Data.Concrete.EntityFramework.Context;
using StockControl.Entity.Concrete;

namespace StockControl.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly StockDataContext stockDataContext;
        public OrderManager(StockDataContext _stockDataContext)
        {
            stockDataContext = _stockDataContext;
        }
        /// <summary>
        /// Order için ekleme işlemi
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IResult Add(Order order)
        {
            try
            {
                int localAmount;
                var product = stockDataContext.Products.Where(a => a.Id == order.ProductId).ToList();
                //Any() kaynak dizi herhangi bir eleman içeriyorsa true döner
                if (product.Any())
                {
                    foreach (var item in product)
                    {
                        if (item.Amount != 0)
                        {
                            localAmount = item.Amount - order.OrderAmount;
                            if (localAmount == 0)
                            {
                                return new SuccessResult(false, Messages.ProductOverAmount);
                            }
                            else if (localAmount < 0)
                            {
                                return new SuccessResult(false, Messages.ProductOverAmount);
                            }

                            item.Amount = localAmount;
                        }
                        else
                        {
                            return new SuccessResult(false, Messages.ProductOverAmount);
                        }

                    }
                }

                stockDataContext.Orders.Add(order);
                stockDataContext.SaveChanges();
                return new SuccessResult(true, Messages.ProductOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Hata");
            }
           
        }
        /// <summary>
        /// Order için silme işlemi
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IResult Delete(Order order)
        {
            stockDataContext.Orders.Remove(order);
            stockDataContext.SaveChanges();
            return new SuccessResult(true, Messages.OrderDelete);
        }
        /// <summary>
        /// Order listesi döndürüldü
        /// </summary>
        /// <returns></returns>
        public IDataResult<List<Order>> GetList()
        {
            //Include ile ikinci bir tabloya geçiş yapıldı.
            //Daha fazla tabloya deçiş yapmak için ise ThenInclude() kullanılır.
            return new SuccessDataResult<List<Order>>(stockDataContext.Orders
                .Include(i => i.Product).ToList());
        }

        public List<Product> GetProductList()
        {
            return new List<Product>(stockDataContext.Products.ToList());
        }

        public List<Product> GetByIdOrder(int productId)
        {
            return new List<Product>(stockDataContext.Products.Where(i=>i.Id==productId).ToList());
        }
    }
}
