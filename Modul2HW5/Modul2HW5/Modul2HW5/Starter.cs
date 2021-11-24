using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using Newtonsoft.Json;
using Modul2HW5.Configs;
using Modul2HW5.Services;

namespace Modul2HW5
{
    public class Starter
    {
        private readonly Random _rand;
        private readonly Logger _log = Logger.Instance;
        private readonly Actions _actions;
        private readonly DateTime _date;
        private string[] _files;
        public Starter()
        {
            _rand = new Random();
            _actions = new Actions();
            _date = DateTime.UtcNow;
        }

        public void Run()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);

            var directory = new DirectoryInfo($"{config.Logger.DirectoryPath}\\{config.Logger.DirectoryName}");
            if (!directory.Exists)
            {
                directory.Create();
            }

            _files = Directory.GetFiles($"{directory}");
            config.Logger.FileName = $"{_date.Hour}.{_date.Minute}.{_date.Second} {_date.Year}.{_date.Month}.{_date.Day}";

            using (var file = new FileStream($"{directory}\\{config.Logger.FileName}{config.Logger.FileExtensions}", FileMode.Append))
            {
                // var file1 = new FileStream($"{directory}\\{config.Logger.FileName}-1-{config.Logger.FileExtensions}", FileMode.OpenOrCreate);
                byte[] array = System.Text.Encoding.Default.GetBytes("HAHAHAHAHA");

                // запись массива байтов в файл
                file.Write(array, 0, array.Length);
                array = System.Text.Encoding.Default.GetBytes("OLOLOLO");
                file.Write(array, 0, array.Length);
            }

            for (var i = 0; i < 100; i++)
            {
                try
                {
                    switch (_rand.Next(1, 4))
                    {
                        case 1:
                            _actions.Method_1();
                            break;
                        case 2:
                            _actions.Method_2();
                            break;
                        case 3:
                            _actions.Method_3();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _log.LogWarning($"Action got this custom Exception : {ex}");
                }
                catch (Exception ex)
                {
                    _log.LogError($"Action failed by reason: {ex}");
                }
            }
        }
    }
}
