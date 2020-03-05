namespace DialogProvider
{
    public interface IDialogProvider
    {
        void Show<TViewModel>(TViewModel viewModel);
        IDialogProvider AddMap<TViewModel, TView>();
    }
}