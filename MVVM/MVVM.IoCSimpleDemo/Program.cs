using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoCSimpleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Конфигурация контейнера
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<ILogger, FileLogger>(x => new FileLogger("log.txt"));
            //services.AddScoped<ILogger, ConsoleLogger>();
            //services.AddTransient<SimpleLogic>();
            services.AddTransient<SimpleLogic>(x => new SimpleLogic(x.GetService<ILogger>()));

            var provider = services.BuildServiceProvider();
            #endregion

            SimpleLogic logic = provider.GetService<SimpleLogic>();
            SimpleLogic logic2 = provider.GetService<SimpleLogic>();
            Console.WriteLine("");
        }
    }
}
