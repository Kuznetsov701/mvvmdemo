using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DialogProvider
{
    public static class DialogProviderServiceExtension
    {
        public static void AddWindowDialogProvider(this IServiceCollection serviceDescriptors, Action<IDialogProvider> configuration)
        {
            serviceDescriptors.AddSingleton<IDialogProvider>(x => {
                var dp = new WindowDialogProvider<Window>(x);
                configuration(dp);
                return dp;
            });
        }
    }
}
