using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW5
{
    public class BusinessException : Exception
    {
        public BusinessException(string msg)
            : base(msg)
        {
        }

        public static BusinessException SkippedLogic(string message = null)
        {
            return new BusinessException(message);
        }
    }
}
