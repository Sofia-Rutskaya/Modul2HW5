using System;
using Modul2HW5.Configs;
using Modul2HW5.Services;
using Modul2HW5.Services.Additional;

using Microsoft.Extensions.DependencyInjection;

namespace Modul2HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, Logger>()
                .AddSingleton<IFileService, FileService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            start.Run();
        }
    }
}
