using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        /// <summary>
        /// Yapılan işlem başarılı mı?
        /// </summary>
        bool Success { get; }
        /// <summary>
        /// Yapılan işlem mesajı
        /// </summary>
        string Message { get; }
    }
}
