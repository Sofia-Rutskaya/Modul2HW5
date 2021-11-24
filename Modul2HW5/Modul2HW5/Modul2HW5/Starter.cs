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
        private readonly ILogger _log;
        private readonly Actions _actions;

        public Starter()
        {
            _log = Logger.Instance;
            _rand = new Random();
            _actions = new Actions();
        }

        public void Run()
        {
            var configFile = File.ReadAllText("config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            _log.SetConfig(config);

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
                    _log.LogWarning($"Action got this custom Exception : {ex.Message}");
                }
                catch (Exception ex)
                {
                    _log.LogError($"Action failed by reason: {ex.Message}");
                }
            }

            _log.EndWork();
        }
    }
}
