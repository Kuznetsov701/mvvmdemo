namespace MVVM.Demo5.Pages
{
    public class CounterViewModel : ObservableObject
    {
        private int _CurrentCount = 0;
        public int CurrentCount
        {
            get => _CurrentCount;
            set => OnPropertyChanged(ref _CurrentCount, value);
        }

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}