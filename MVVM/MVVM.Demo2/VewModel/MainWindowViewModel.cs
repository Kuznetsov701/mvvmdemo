using DataContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MVVM.Demo2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IEmployeeDataSourse employeeDataSourse;

        public MainWindowViewModel(IEmployeeDataSourse employeeDataSourse)
        {
            this.employeeDataSourse = employeeDataSourse;

            ItemsSourse = employeeDataSourse.Get();
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

        protected virtual void OnPropertyChanged(string propertyName)
        {
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


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool OnPropertyChanged<T>(ref T self, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(self, value))
                return false;

            self = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
