using Microsoft.AspNetCore.Mvc.Rendering;
using StockControl.Entity.Concrete;

namespace StockControlApp.Models.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public SelectList ProductSelectList { get; set; }
    }
}
