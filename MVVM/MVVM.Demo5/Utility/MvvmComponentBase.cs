using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace MVVM.Demo5
{
    public abstract class MvvmComponentBase<T> : ComponentBase where T : INotifyPropertyChanged
    {
        [Inject]
        [Parameter]
        public T ViewModel { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ViewModel.PropertyChanged += (s, e) => StateHasChanged();
        }
    }
}
