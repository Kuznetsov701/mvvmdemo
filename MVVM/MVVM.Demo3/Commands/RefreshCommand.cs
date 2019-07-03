using System;
using System.Windows.Input;

namespace MVVM.Demo3
{
    public class RefreshCommand : ICommand
    {
        IMainWindowViewModel viewModel;

        public RefreshCommand(IMainWindowViewModel viewModel) =>
            this.viewModel = viewModel;

        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value; 
            remove => CommandManager.RequerySuggested -= value; 
        }

        public bool CanExecute(object parameter) => 
            viewModel.EmployeeDataSourse != null;

        public async void Execute(object parameter) => 
            viewModel.ItemsSourse = await viewModel.EmployeeDataSourse.GetAsync();
    }
}
