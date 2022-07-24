using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using StockControl.Business.Abstract;
using StockControl.Business.Constants;
using StockControl.Data.Concrete.EntityFramework.Context;
using StockControl.Entity.Concrete;

namespace StockControl.Business.Concrete
{
    public class OrderManager:IOrderService
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
            stockDataContext.Orders.Add(order);
            stockDataContext.SaveChanges();
            return new SuccessResult(Messages.ProductOrder);
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
            return new SuccessResult(Messages.OrderDelete);
        }
        /// <summary>
        /// Order listesi döndürüldü
        /// </summary>
        /// <returns></returns>
        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(stockDataContext.Orders.ToList());
        }

        public List<Product> GetProductList()
        {
            return new List<Product>(stockDataContext.Products.ToList());
        }
    }
}
