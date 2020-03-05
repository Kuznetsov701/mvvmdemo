using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVM.Demo4
{
    public static class ButtonProperty
    {
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonProperty));

        public static void SetCornerRadius(Button obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        public static CornerRadius GetCornerRadius(Button obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }
    }
}
