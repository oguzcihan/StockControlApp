using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using StockControl.Business.Abstract;
using StockControl.Business.Constants;
using StockControl.Data.Concrete.EntityFramework.Context;
using StockControl.Entity.Concrete;

namespace StockControl.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly StockDataContext stockDataContext;
        public ProductManager(StockDataContext _stockDataContext)
        {
            stockDataContext = _stockDataContext;
        }
        /// <summary>
        /// Product için id ye göre güncelleme yapmak adına yazılan method
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(stockDataContext.Products.FirstOrDefault(i => i.Id == productId));
        }
        /// <summary>
        /// Product eklemek için oluşturuldu
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IResult Add(Product product)
        {
            try
            {
                stockDataContext.Products.Add(product);
                stockDataContext.SaveChanges();
                return new SuccessResult(true, Messages.ProductAdded);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// Product güncelleme işlemii
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IResult Update(Product product)
        {
            stockDataContext.Entry(product).State = EntityState.Modified;
            stockDataContext.SaveChanges();
            return new SuccessResult(true, Messages.ProductUpdated);
        }
        /// <summary>
        /// Product silme işlemi
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IResult Delete(Product product)
        {
            stockDataContext.Remove(product);
            stockDataContext.SaveChanges();
            return new SuccessResult(true, Messages.ProductDeleted);
        }
        /// <summary>
        /// Tüm productları listelemek için kullanıldı
        /// </summary>
        /// <returns></returns>
        public IDataResult<List<Product>> GetList()
        {
            //return stockDataContext.Products.ToList();
            return new SuccessDataResult<List<Product>>(stockDataContext.Products.ToList());
        }
    }
}
