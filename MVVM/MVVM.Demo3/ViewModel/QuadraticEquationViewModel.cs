using System;
using System.ComponentModel;

namespace MVVM.Demo3
{
    public class QuadraticEquationViewModel : INotifyPropertyChanged
    {
        #region double A        
        private double _A;
        public double A
        {
            get
            {
                return _A;
            }
            set
            {
                if (_A == value)
                    return;
                _A = value;
                OnPropertyChanged(nameof(A));
            }
        }
        #endregion

        #region double B        
        private double _B;
        public double B
        {
            get
            {
                return _B;
            }
            set
            {
                if (_B == value)
                    return;
                _B = value;
                OnPropertyChanged(nameof(B));
            }
        }
        #endregion

        #region double C        
        private double _C;
        public double C
        {
            get
            {
                return _C;
            }
            set
            {
                if (_C == value)
                    return;
                _C = value;
                OnPropertyChanged(nameof(C));
            }
        }
        #endregion

        #region double X1        
        private double? _X1;
        public double? X1
        {
            get
            {
                return _X1;
            }
            protected set
            {
                if (_X1 == value)
                    return;
                _X1 = value;
                OnPropertyChanged(nameof(X1));
            }
        }
        #endregion

        #region double X2        
        private double? _X2;
        public double? X2
        {
            get
            {
                return _X2;
            }
            protected set
            {
                if (_X2 == value)
                    return;
                _X2 = value;
                OnPropertyChanged(nameof(X2));
            }
        }
        #endregion

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName.In(nameof(A), nameof(B), nameof(C)))
                Solve();
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Solve()
        {
            double discriminant = B * B - 4 * A * C;
            if (discriminant < 0)
            {
                X1 = null;
                X2 = null;
            }
            else
            {
                X1 = A != 0 ? (-B + Math.Sqrt(discriminant)) / (2 * A) : B != 0 ? C / B * -1 as double? : null;
                X2 = A != 0 ? (-B - Math.Sqrt(discriminant)) / (2 * A) as double? : null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
