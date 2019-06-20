using MVVM.Demo3.Utilty;
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

    public class CalculatorViewModel : ObservableObject
    {     
        private double _LeftNum;
        public double LeftNum
        {
            get =>_LeftNum;
            set => base.OnPropertyChanged(ref _LeftNum, value);
        }
    
        private double _RightNum;
        public double RightNum
        {
            get => _RightNum;
            set => base.OnPropertyChanged(ref _RightNum, value);
        }
     
        private double? _Result;
        public double? Result
        {
            get => _Result;
            set => base.OnPropertyChanged(ref _Result, value);
        }
      
        private Operation _Operation;
        public Operation Operation
        {
            get => _Operation;
            set => base.OnPropertyChanged(ref _Operation, value);
        }
       
        private string _OperationString;
        public string OperationString
        {
            get => _OperationString;
            set => base.OnPropertyChanged(ref _OperationString, value);
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(LeftNum) || propertyName == nameof(RightNum))
                Result = Calc();

            if (propertyName == nameof(Operation))
                OperationString = Operation.AsSymbol();
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
    }
}
