using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Business.Constants
{
    /// <summary>
    /// Sabit olan tüm mesajların olduğu sınıf
    /// </summary>
    static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductOrder = "Ürün çıkışı yapıldı lütfen ürün listesinden adet alanını kontrol ediniz!";
        public static string OrderDelete = "Çıkışı yapılan ürün silindi";
        public static string ProductOverAmount = "Girilen ürün adedi mevcut ürün adedinden fazladır. Lütfen daha düşük bir miktar giriniz!";
    }
}
