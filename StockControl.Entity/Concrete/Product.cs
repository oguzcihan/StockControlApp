using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockControl.Entity.Abstract;

namespace StockControl.Entity.Concrete
{
    [Table("Product")]
    public class Product:IEntity
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public String ProductName { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
