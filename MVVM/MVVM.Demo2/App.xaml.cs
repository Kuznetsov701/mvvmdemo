using System.Windows;

namespace MVVM.Demo2
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

            MainWindow window = new MainWindow() { DataContext= mainWindowViewModel };
            window.Show();
        }
    }
}
