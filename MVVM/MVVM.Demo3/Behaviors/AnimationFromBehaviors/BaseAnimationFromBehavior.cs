using Microsoft.Xaml.Behaviors;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MVVM.Demo3
{
    public class BaseAnimationFromBehavior<T> : Behavior<T> where T : UIElement
    {
        public AnimationTimeline Animation { get; set; }
        public DependencyProperty Property { get; set; }

        protected virtual async Task BeginAnimation()
        {
            AssociatedObject.BeginAnimation(Property, Animation);
            await Task.Delay(Animation.Duration.TimeSpan);
        }
    }
}
