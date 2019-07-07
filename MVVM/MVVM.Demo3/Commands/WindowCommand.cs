using System;
using System.Windows;
using System.Windows.Input;

namespace MVVM.Demo3
{
    public static class WindowCommand
    {
        public static CloseCommand Close => new CloseCommand();
        public static MinimazeCommand Minimaze => new MinimazeCommand();
    }

    public class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => parameter is Window;

        public void Execute(object parameter) => (parameter as Window).Close();
    }

    public class MinimazeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => parameter is Window;

        public void Execute(object parameter) => (parameter as Window).WindowState = WindowState.Minimized;
    }
}
