using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul2HW5.Configs;

namespace Modul2HW5.Services.Additional
{
    public interface IFileService
    {
        public void SaveInFile();
        public void CloseFile();
        public void InitDirectory(Config config);
    }
}
