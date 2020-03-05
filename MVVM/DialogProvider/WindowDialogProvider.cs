using System;
using System.Collections.Generic;
using System.Windows;

namespace DialogProvider
{
    public class WindowDialogProvider<T> : IDialogProvider where T : Window
    {
        IServiceProvider serviceProvider;

        public WindowDialogProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        Dictionary<Type, Type> map = new Dictionary<Type, Type>();

        public void Show<TViewModel>(TViewModel viewModel)
        {
            if (map.ContainsKey(typeof(TViewModel)))
            {
                T t = serviceProvider.GetService(map[typeof(TViewModel)]) as T;
                t.DataContext = viewModel;
                t.Show();
            }
            else
            {
                Window window = new Window();
                window.DataContext = viewModel;
                window.Show();
            }
        }

        public IDialogProvider AddMap<TViewModel, TWindow>()
        {
            map.Add(typeof(TViewModel), typeof(TWindow));
            return this;
        }
    }
}
