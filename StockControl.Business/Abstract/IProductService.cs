using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using StockControl.Entity.Concrete;

namespace StockControl.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        /// <summary>
        /// Product türünde ürün güncelleme işlemi yapılır
        /// </summary>
        /// <param name="product"></param>
        IResult Update(Product product);
        /// <summary>
        /// Product türünde ürün silme işlemi yapılır
        /// </summary>
        /// <param name="product"></param>
        IResult Delete(Product product);
        IDataResult<List<Product>> GetList();
    }
}
