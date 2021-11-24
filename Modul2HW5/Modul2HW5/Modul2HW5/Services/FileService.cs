using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul2HW5.Configs;

namespace Modul2HW5.Services
{
    public class FileService
    {
        private readonly Config _config;
        public FileService(Config config)
        {
            _config = config;
        }

        public void SaveInFile()
        {
        }
    }
}
