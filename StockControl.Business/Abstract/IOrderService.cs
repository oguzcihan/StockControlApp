using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using StockControl.Entity.Concrete;

namespace StockControl.Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(Order order);
        IDataResult<List<Order>> GetList();
        List<Product> GetProductList();
    }
}
