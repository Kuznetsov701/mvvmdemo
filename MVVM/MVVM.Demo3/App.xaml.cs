using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            ImageSource imageSource = new BitmapImage(new Uri(@"pack://application:,,,/images/mainicon.png"));

            Window window = new Window() { Content = mainWindowViewModel, Title = "2154", Icon = imageSource };
            window.Show();
            Window window2 = new Window() { Content = mainWindowViewModel, Title = "215qwr4", Icon = imageSource };
            window2.Show();
        }
    }
}
