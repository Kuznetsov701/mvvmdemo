using Xunit;

namespace MVVM.Demo3.Tests
{
    public class QuadraticEquationViewModelTest
    {
        [Theory]
        [InlineData(1, 3, -4, -4, 1)]
        [InlineData(1, 1, 4, null, null)]
        [InlineData(1, 2, 1, -1, -1)]
        [InlineData(0, 1, 1, -1, null)]
        public void SolveTest(double a, double b, double c, double? x1, double? x2)
        {
            QuadraticEquationViewModel viewModel = new QuadraticEquationViewModel(){ A = a, B = b, C = c };
            Assert.True((x1 == viewModel.X1 || x1 == viewModel.X2) && (x2 == viewModel.X1 || x2 == viewModel.X2));
        }

        [Fact]
        public void APropertyChanged()
        {
            bool changed = false;
            QuadraticEquationViewModel viewModel = new QuadraticEquationViewModel();
            viewModel.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(viewModel.A))
                    changed = true;
            };

            viewModel.A = 1;

            Assert.True(changed);
        }

        [Fact]
        public void BPropertyChanged()
        {
            bool changed = false;
            QuadraticEquationViewModel viewModel = new QuadraticEquationViewModel();
            viewModel.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(viewModel.B))
                    changed = true;
            };

            viewModel.B = 1;

            Assert.True(changed);
        }

        [Fact]
        public void CPropertyChanged()
        {
            bool changed = false;
            QuadraticEquationViewModel viewModel = new QuadraticEquationViewModel();
            viewModel.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(viewModel.C))
                    changed = true;
            };

            viewModel.C = 1;

            Assert.True(changed);
        }
    }
}
