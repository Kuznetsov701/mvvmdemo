using System.ComponentModel;

namespace MVVM.Demo3
{
    public enum Operation
    {
        Sum,
        Difference,
        Multiplication,
        Division
    }

    public class CalculatorViewModel : INotifyPropertyChanged
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
        private double? _Result;
        public double? Result
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

        #region Operation Operation        
        private Operation _Operation;
        public Operation Operation
        {
            get
            {
                return _Operation;
            }
            set
            {
                _Operation = value;
                OnPropertyChanged(nameof(Operation));
            }
        }
        #endregion

        #region string OperationString        
        private string _OperationString;
        public string OperationString
        {
            get
            {
                return _OperationString;
            }
            set
            {
                if (_OperationString == value)
                    return;
                _OperationString = value;
                OnPropertyChanged(nameof(OperationString));
            }
        }
        #endregion

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(LeftNum) || propertyName == nameof(RightNum))
                Result = Calc();

            if (propertyName == nameof(Operation))
                OperationString = Operation.AsSymbol();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double? Calc()
        {
            switch (this.Operation)
            {
                case Operation.Sum: return LeftNum + RightNum;
                case Operation.Multiplication: return LeftNum * RightNum;
                case Operation.Difference: return LeftNum - RightNum;
                case Operation.Division: return RightNum != 0 ? LeftNum / RightNum as double? : null;
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
