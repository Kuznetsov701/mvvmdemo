using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MVVM.Demo5.Pages;
using System.Threading.Tasks;

namespace MVVM.Demo5
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<CounterViewModel>();
            builder.Services.AddTransient<FetchDataViewModel>();

            await builder.Build().RunAsync();
        }
    }
}