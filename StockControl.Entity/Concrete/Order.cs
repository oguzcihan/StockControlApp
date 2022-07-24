using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockControl.Entity.Abstract;

namespace StockControl.Entity.Concrete
{
    [Table("Order")]
    public class Order:IEntity
    {
        public int Id { get; set; }
        public String EmployeeName { get; set; }
        public int OrderAmount { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
    }
}
