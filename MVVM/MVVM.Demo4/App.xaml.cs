using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MVVM.Demo4
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ServiceCollection serviceDescriptors = new ServiceCollection();

            new Startup(null).ConfigureService(serviceDescriptors);

            ServiceProvider provider = serviceDescriptors.BuildServiceProvider();

            provider.GetRequiredService<MainWindowViewModel>();
            provider.GetRequiredService<MainWindowViewModel>();
        }
    }
}
