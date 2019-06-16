using Xunit;

namespace MVVM.Demo2
{
    public class MainWindowViewModelTest
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public MainWindowViewModelTest()
        {
            mainWindowViewModel = new MainWindowViewModel();
        }
        
        [Theory]
        [InlineData(2.0, 2.0, 4.0)]
        [InlineData(3.0, -5.0, -2.0)]
        [InlineData(22.0, -102.0, -80.0)]
        [InlineData(57.0, 72.0, 129.0)]
        public void TestResult(double a, double b, double result)
        {
            mainWindowViewModel.LeftNum = a;
            mainWindowViewModel.RightNum = b;
            Assert.Equal(mainWindowViewModel.Result, result);
        }

        [Fact]
        public void TestLeftNumPropertyChanged()
        {
            bool changed = false;
            mainWindowViewModel.PropertyChanged += (x, e) => {
                if (e.PropertyName == nameof(mainWindowViewModel.LeftNum))
                    changed = true;
            };
            mainWindowViewModel.LeftNum = 2.0;
            Assert.True(changed);
        }

        [Fact]
        public void TestRightNumPropertyChanged()
        {
            bool changed = false;
            mainWindowViewModel.PropertyChanged += (x, e) => {
                if (e.PropertyName == nameof(mainWindowViewModel.RightNum))
                    changed = true;
            };
            mainWindowViewModel.RightNum = 2.0;
            Assert.True(changed);
        }

        [Fact]
        public void TestResultPropertyChanged()
        {
            bool changed = false;
            mainWindowViewModel.PropertyChanged += (x, e) => {
                if (e.PropertyName == nameof(mainWindowViewModel.Result))
                    changed = true;
            };
            mainWindowViewModel.LeftNum = 2.0;
            Assert.True(changed);
            changed = false;

            mainWindowViewModel.RightNum = 2.0;
            Assert.True(changed);
        }
    }
}
