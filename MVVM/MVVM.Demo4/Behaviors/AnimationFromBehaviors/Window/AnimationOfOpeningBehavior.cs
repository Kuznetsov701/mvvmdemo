using System.Windows;

namespace MVVM.Demo4
{
    public class AnimationOfOpeningBehavior : BaseAnimationFromBehavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private async void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            await BeginAnimation();
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}
