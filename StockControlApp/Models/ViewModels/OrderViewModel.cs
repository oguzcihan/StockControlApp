using Microsoft.AspNetCore.Mvc.Rendering;
using StockControl.Entity.Concrete;

namespace StockControlApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public String EmployeeName { get; set; }
        public int OrderAmount { get; set; }
        public int ProductId { get; set; }
        
    }
}
