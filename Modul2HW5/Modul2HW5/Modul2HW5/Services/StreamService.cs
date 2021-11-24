using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul2HW5.Services.Additional;

namespace Modul2HW5.Services
{
    public class StreamService
    {
        private string _path;
        private IFileService _fileService;

        public StreamService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void SetStream(string path)
        {
            _path = path;
        }
    }
}
