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
        private byte[] _buffer;

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

            ClearDirect(directory);

            config.Logger.FileName = $"{_date.Hour}.{_date.Minute}.{_date.Second} {_date.Day}.{_date.Month}.{_date.Year}";

            _newFile = new FileStream($"{directory}\\{config.Logger.FileName}{config.Logger.FileExtensions}", FileMode.Append);
        }

        void IFileService.SaveInFile(string message)
        {
            _buffer = System.Text.Encoding.Default.GetBytes($"{message} {Environment.NewLine}");
            _newFile.Write(_buffer, 0, _buffer.Length);
        }

        void IFileService.CloseFile()
        {
            _newFile.Close();
        }

        private void ClearDirect(DirectoryInfo directory)
        {
            _files = Directory.GetFiles($"{directory}");
            if (_files.Length >= 3)
            {
                foreach (var fileFirst in directory.EnumerateFiles())
                {
                    foreach (var fileSecond in directory.EnumerateFiles())
                    {
                        if (fileFirst.CreationTime < fileSecond.CreationTime)
                        {
                            _files = Directory.GetFiles($"{directory}");
                            if (_files.Length < 3)
                            {
                                break;
                            }

                            fileFirst.Delete();
                        }
                    }
                }
            }
        }
    }
}
