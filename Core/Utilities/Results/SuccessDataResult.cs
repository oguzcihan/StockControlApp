using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        /// <summary>
        /// Sonuç başarılı ise işlem mesajı gönderilir.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }
    }
}
