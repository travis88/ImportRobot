using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Linq;
using ImportRobot.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ImportRobot.Services;
using NLog.Extensions.Logging;

namespace ImportRobot
{
    class Program
    {
        public static IConfiguration Configuration;
        public static IServiceCollection services;

        static void Main(string[] args)
        {
            // коллекция служб
            services = new ServiceCollection();
            var serviceProvider = ConfigureServices(services);

            var runner = serviceProvider.GetRequiredService<Runner>();
            runner.DoAction("Action1");
        }

        private static IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // читаем файл конфигурации
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            // runner is the custom class
            services.AddTransient<Runner>();

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((build) => build.SetMinimumLevel(LogLevel.Trace));
            
            var serviceProvider = services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            // configure NLog
            loggerFactory.AddNLog(new NLogProviderOptions { CaptureMessageTemplates = true, CaptureMessageProperties =true });
            loggerFactory.ConfigureNLog(Directory.GetCurrentDirectory() + "/" + "nlog.config"); 

            return serviceProvider;
        }
    }
}
