using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modul2HW5.Configs;
using Modul2HW5.Services.Additional;

namespace Modul2HW5.Services
{
    public class FileService : IFileService
    {
        private readonly Config _config;
        private readonly DateTime _date;
        private string[] _files;
        private FileStream _newFile;

        // private byte[] _buffer;
        public FileService(Config config)
        {
            _config = config;
            _date = DateTime.UtcNow;
        }

        void IFileService.InitDirectory(Config config)
        {
            var directory = new DirectoryInfo($"{config.Logger.DirectoryPath}\\{config.Logger.DirectoryName}");
            if (!directory.Exists)
            {
                directory.Create();
            }

            _files = Directory.GetFiles($"{directory}");
            config.Logger.FileName = $"{_date.Hour}.{_date.Minute}.{_date.Second} {_date.Day}.{_date.Month}.{_date.Year}";

            _newFile = new FileStream($"{directory}\\{config.Logger.FileName}{config.Logger.FileExtensions}", FileMode.Append);

            // var file1 = new FileStream($"{directory}\\{config.Logger.FileName}4444{config.Logger.FileExtensions}", FileMode.Append);
            // var file1 = new FileStream($"{directory}\\{config.Logger.FileName}-1-{config.Logger.FileExtensions}", FileMode.OpenOrCreate);
            // _buffer = System.Text.Encoding.Default.GetBytes("HAHAHAHAHA");
            // запись массива байтов в файл
            // file.Write(_buffer, 0, _buffer.Length);
            // _buffer = System.Text.Encoding.Default.GetBytes("OLOLOLO");
            // file1.Write(_buffer, 0, _buffer.Length);
            // file.Close();
        }

        void IFileService.SaveInFile()
        {
        }

        void IFileService.CloseFile()
        {
            _newFile.Close();
        }
    }
}
