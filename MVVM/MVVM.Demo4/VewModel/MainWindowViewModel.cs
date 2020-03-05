using DataContract;
using DialogProvider;
using MVVM.Demo4.Utilty;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace MVVM.Demo4
{
    public class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        public IEmployeeDataSourse EmployeeDataSourse { get; }

        public MainWindowViewModel(IEmployeeDataSourse employeeDataSourse, IDialogProvider dialogProvider)
        {
            dialogProvider.Show(this);
            this.EmployeeDataSourse = employeeDataSourse;
            RefreshCommand = new RefreshCommand(this);
        }

        private string _Filter;
        public string Filter
        {
            get => _Filter;
            set => OnPropertyChanged(ref _Filter, value);
        }
        
        private List<Employee> _FilteredSourse;
        public List<Employee> FilteredSourse
        {
            get => _FilteredSourse;
            set => OnPropertyChanged(ref _FilteredSourse, value);
        }
        
        private List<Employee> _ItemsSourse;
        public List<Employee> ItemsSourse
        {
            get => _ItemsSourse;
            set => OnPropertyChanged(ref _ItemsSourse, value);
        }

        private ICommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get => _RefreshCommand;
            set => OnPropertyChanged(ref _RefreshCommand, value);
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Filter))
            {
                if (!string.IsNullOrWhiteSpace(Filter))
                    FilteredSourse = ItemsSourse.Where(x => x.ToString().ToLower().Contains(Filter.ToLower())).ToList();
                else
                    FilteredSourse = ItemsSourse;
            }

            if (propertyName == nameof(ItemsSourse))
            {
                FilteredSourse = ItemsSourse;
                Filter = null;
            }
        }
    }
}
