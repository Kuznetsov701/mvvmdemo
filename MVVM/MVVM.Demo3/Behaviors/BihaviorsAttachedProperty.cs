using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MVVM.Demo3
{
    public class Behaviors : List<Behavior> { }

    public static class BihaviorsAttachedProperty
    {
        public static readonly DependencyProperty BehaviorsProperty =
            DependencyProperty.RegisterAttached("Behaviors", typeof(Behaviors), typeof(BihaviorsAttachedProperty), new PropertyMetadata(OnBehaviorsPropertyChanged));

        public static void SetBehaviors(DependencyObject obj, Behaviors value)
        {
            if (obj == null)
                throw new ArgumentNullException();
            obj.SetValue(BehaviorsProperty, value);
        }

        public static Behaviors GetBehaviors(DependencyObject obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            return (Behaviors)obj.GetValue(BehaviorsProperty);
        }

        private static void OnBehaviorsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
                return;

            var behaviors = Interaction.GetBehaviors(d);

            foreach (var behavior in e.NewValue as Behaviors)
                behaviors.Add(behavior);

            //if(e.OldValue != null)
            //    foreach (var behavior in e.OldValue as Behaviors)
            //        behaviors.Remove(behavior);
        }
    }
}
