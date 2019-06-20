using DataContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MVVM.Demo1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ItemsSourse = new List<Employee>() {
                new Employee { LastName = "Денисов", FirstName = "Платон", MiddleName = "Антонинович", DateOfBirthday = new DateTime(1987, 5, 12) },
                new Employee { LastName = "Орехов", FirstName = "Ян", MiddleName = "Проклович", DateOfBirthday = new DateTime(1992, 3, 24) },
                new Employee { LastName = "Тарасов", FirstName = "Юлий", MiddleName = "Викторович", DateOfBirthday = new DateTime(1979, 11, 16) },
                new Employee { LastName = "Мельников", FirstName = "Агафон", MiddleName = "Кимович", DateOfBirthday = new DateTime(1992, 6, 23) },
                new Employee { LastName = "Смирнов", FirstName = "Любомир", MiddleName = "Тимофеевич", DateOfBirthday = new DateTime(1989, 12, 11) },
                new Employee { LastName = "Панфилов", FirstName = "Кирилл", MiddleName = "Робертович", DateOfBirthday = new DateTime(1976, 4, 2) },
                new Employee { LastName = "Дьячков", FirstName = "Всеволод", MiddleName = "Альвианович", DateOfBirthday = new DateTime(1998, 7, 24) },
                new Employee { LastName = "Щербаков", FirstName = "Рудольф", MiddleName = "Митрофанович", DateOfBirthday = new DateTime(1995, 4, 27) },
                new Employee { LastName = "Галкин", FirstName = "Ефим", MiddleName = "Викторович", DateOfBirthday = new DateTime(1986, 9, 11) },
                new Employee { LastName = "Куликов", FirstName = "Константин", MiddleName = "Протасьевич", DateOfBirthday = new DateTime(1984, 2, 25) },
                new Employee { LastName = "Фёдоров", FirstName = "Игнатий", MiddleName = "Викторович", DateOfBirthday = new DateTime(1996, 3, 22) },
                new Employee { LastName = "Котов", FirstName = "Ярослав", MiddleName = "Христофорович", DateOfBirthday = new DateTime(1991, 4, 6) },
                new Employee { LastName = "Андреев", FirstName = "Захар", MiddleName = "Антонинович", DateOfBirthday = new DateTime(1987, 4, 1) },
                new Employee { LastName = "Афанасьев", FirstName = "Флор", MiddleName = "Артёмович", DateOfBirthday = new DateTime(1988, 7, 19) },
                new Employee { LastName = "Галкин", FirstName = "Любомир", MiddleName = "Богданович", DateOfBirthday = new DateTime(1984, 10, 21) },
                new Employee { LastName = "Владимиров", FirstName = "Любовь", MiddleName = "Георгьевич", DateOfBirthday = new DateTime(1988, 9, 28) },
                new Employee { LastName = "Якушев", FirstName = "Ибрагил", MiddleName = "Степанович", DateOfBirthday = new DateTime(1981, 8, 5) },
                new Employee { LastName = "Копылов", FirstName = "Филипп", MiddleName = "Георгиевич", DateOfBirthday = new DateTime(1993, 8, 29) },
                new Employee { LastName = "Коновалов", FirstName = "Флор", MiddleName = "Созонович", DateOfBirthday = new DateTime(1992, 7, 6) },
                new Employee { LastName = "Комиссаров", FirstName = "Власий", MiddleName = "Геласьевич", DateOfBirthday = new DateTime(1989, 2, 20) },
                new Employee { LastName = "Маслова", FirstName = "Любовь", MiddleName = "Федосеевна", DateOfBirthday = new DateTime(1992, 6, 23) },
                new Employee { LastName = "Баранова", FirstName = "Лира", MiddleName = "Дмитрьевна", DateOfBirthday = new DateTime(1989, 12, 11) },
                new Employee { LastName = "Матвеева", FirstName = "Елена", MiddleName = "Дамировна", DateOfBirthday = new DateTime(1976, 4, 2) },
                new Employee { LastName = "Лаврентьева", FirstName = "Аделина", MiddleName = "Егоровна", DateOfBirthday = new DateTime(1998, 7, 24) },

            };
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
                    FilteredSourse = ItemsSourse.Where(x => x.FirstName.ToLower().Contains(Filter.ToLower())
                    || x.MiddleName.ToLower().Contains(Filter.ToLower())
                    || x.LastName.ToLower().Contains(Filter.ToLower())
                    || x.DateOfBirthday.ToShortDateString().Contains(Filter)).ToList();
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
