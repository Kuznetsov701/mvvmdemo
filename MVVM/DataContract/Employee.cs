using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataContract
{
    public class Employee : INotifyPropertyChanged, IDataErrorInfo//, INotifyDataErrorInfo
    {
        #region int Id        
        private int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        #endregion
        #region string FirstName        
        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (_FirstName == value)
                    return;
                _FirstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        #endregion
        #region string MiddleName        
        private string _MiddleName;
        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                if (_MiddleName == value)
                    return;
                _MiddleName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MiddleName)));
            }
        }
        #endregion
        #region string LastName        
        private string _LastName;
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (_LastName == value)
                    return;
                _LastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
        #endregion
        #region DateTime DateOfBirthday        
        private DateTime _DateOfBirthday;
        public DateTime DateOfBirthday
        {
            get
            {
                return _DateOfBirthday;
            }
            set
            {
                if (_DateOfBirthday == value)
                    return;
                _DateOfBirthday = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateOfBirthday)));
            }
        }
        #endregion
        #region int IdJob        
        private int _IdJob;
        public int IdJob
        {
            get
            {
                return _IdJob;
            }
            set
            {
                if (_IdJob == value)
                    return;
                _IdJob = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IdJob)));
            }
        }
        #endregion
        #region Job Job        
        private Job _Job;
        public Job Job
        {
            get
            {
                return _Job;
            }
            set
            {
                if (_Job == value)
                    return;
                _Job = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Job)));
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        public string Error => "";

        public string this[string columnName]
        {
            get {
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                            return "Имя не может быть пустым";
                        break;
                    case nameof(MiddleName):
                        if (string.IsNullOrWhiteSpace(MiddleName))
                            return "Отчество не может быть пустым";
                        break;
                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                            return "Фамилия не может быть пустым";
                        break;
                    case nameof(DateOfBirthday):
                        if (DateTime.Now.Year - DateOfBirthday.Year > 80)
                            return "Превышена минимально допустимая дата рождения сотрудника";
                        else if (DateTime.Now.Year - DateOfBirthday.Year < 18)
                            return "Превышена максимально допустимая дата рождения сотрудника";
                        break;
                }
                return null;
            }
        }

        public override string ToString()
        {
            return $"{ LastName } { FirstName } { MiddleName }, { DateOfBirthday.ToShortDateString() }";
        }

        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public bool HasErrors => throw new NotImplementedException();

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
