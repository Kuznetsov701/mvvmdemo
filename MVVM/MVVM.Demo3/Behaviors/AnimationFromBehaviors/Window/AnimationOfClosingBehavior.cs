using System.Windows;

namespace MVVM.Demo3
{
    public class AnimationOfClosingBehavior : BaseAnimationFromBehavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Closing += AssociatedObject_Closing;
        }

        private async void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            await BeginAnimation();

            AssociatedObject.Closing -= AssociatedObject_Closing;

            AssociatedObject.Close();
        }
    }
}
