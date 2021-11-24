using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul2HW5.Services
{
    public class Actions
    {
        private readonly Logger _logger;

        public Actions()
        {
            _logger = Logger.Instance;
        }

        public bool Method_1()
        {
            _logger.LogInfo($"Start method: {nameof(Method_1)}");
            return true;
        }

        public bool Method_2()
        {
            throw BusinessException.SkippedLogic("Skipped logic in method");
        }

        public bool Method_3()
        {
            throw new Exception("I broke a logic");
        }
    }
}
