using DialogProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVVM.Demo4
{
    class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddWindowDialogProvider(x => x.AddMap<MainWindowViewModel, MainWindow>());
            services.AddTransient<IEmployeeDataSourse, EmployeeDataSourse>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<MainWindow>();
        }
    }
}
