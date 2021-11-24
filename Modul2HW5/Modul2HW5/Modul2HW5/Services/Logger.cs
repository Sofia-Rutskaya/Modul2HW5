using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul2HW5.Configs;
using Modul2HW5.Services.Additional;

namespace Modul2HW5.Services
{
    public class Logger : ILogger
    {
        private static readonly Logger _instance = new Logger();
        private IFileService _fileService;

        static Logger()
        {
        }

        private Logger()
        {
        }

        public static Logger Instance => _instance;

        void ILogger.LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        void ILogger.LogError(string message)
        {
            Log(LogType.Error, message);
        }

        void ILogger.LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        void ILogger.SetConfig(Config config)
        {
            _fileService = new FileService(config);
            _fileService.InitDirectory(config);
        }

        void ILogger.EndWork()
        {
            _fileService.CloseFile();
        }

        private void Log(LogType type, string message)
        {
            var log = $"{DateTime.UtcNow}: {type.ToString()}: {message}";
            _fileService.SaveInFile(log);
        }
    }
}
