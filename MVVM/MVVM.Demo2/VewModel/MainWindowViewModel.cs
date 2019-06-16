using System.ComponentModel;

namespace MVVM.Demo2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region double LeftNum        
        private double _LeftNum;
        public double LeftNum
        {
            get
            {
                return _LeftNum;
            }
            set
            {
                if (_LeftNum == value)
                    return;
                _LeftNum = value;
                OnPropertyChanged(nameof(LeftNum));
            }
        }
        #endregion

        #region double RightNum        
        private double _RightNum;
        public double RightNum
        {
            get
            {
                return _RightNum;
            }
            set
            {
                if (_RightNum == value)
                    return;
                _RightNum = value;
                OnPropertyChanged(nameof(RightNum));
            }
        }
        #endregion

        #region double Result        
        private double _Result;
        public double Result
        {
            get
            {
                return _Result;
            }
            private set
            {
                if (_Result == value)
                    return;
                _Result = value;
                OnPropertyChanged(nameof(Result));
            }
        }
        #endregion

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(LeftNum) || propertyName == nameof(RightNum))
                Result = LeftNum + RightNum;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
