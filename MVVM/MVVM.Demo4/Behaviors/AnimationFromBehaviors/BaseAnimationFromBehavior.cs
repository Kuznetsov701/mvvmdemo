using Microsoft.Xaml.Behaviors;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace MVVM.Demo4
{
    public class BaseAnimationFromBehavior<T> : Behavior<T> where T : FrameworkElement
    {
        private Storyboard _storyboard;

        public Animations Animations { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();

            _storyboard = new Storyboard();
            _storyboard.Children = new TimelineCollection(Animations);
        }

        protected virtual async Task BeginAnimation()
        {
            _storyboard.Begin(AssociatedObject);
            await Task.Delay(Animations.Max(x => x.Duration.TimeSpan));
        }
    }
    
    public class Animations : List<AnimationTimeline> { }
}
