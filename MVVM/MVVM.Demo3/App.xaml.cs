using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Demo3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IEmployeeDataSourse employeeDataSourse = new EmployeeDataSourse();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(employeeDataSourse);

            Window window = new Window() { Content = mainWindowViewModel };
            window.Show();
            Window window2 = new Window() { Content = mainWindowViewModel };
            window2.Show();
        }
    }
}
