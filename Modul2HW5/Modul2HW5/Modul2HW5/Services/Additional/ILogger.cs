using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul2HW5.Configs;

namespace Modul2HW5.Services
{
    public interface ILogger
    {
        public void LogInfo(string message);

        public void LogError(string message);

        public void LogWarning(string message);

        public void SetConfig(Config config);

        public void EndWork();
    }
}
