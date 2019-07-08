using System.Windows;
using System.Windows.Controls;

namespace MVVM.Demo3
{
    public class WindowProperty
    {
        public static readonly DependencyProperty HeaderTemplateProperty =
            DependencyProperty.RegisterAttached("HeaderTemplate", typeof(ControlTemplate), typeof(WindowProperty));

        public static void SetHeaderTemplate(Window window, ControlTemplate template) => window.SetValue(HeaderTemplateProperty, template);

        public static ControlTemplate GetHeaderTempalte(Window window) => (ControlTemplate)window.GetValue(HeaderTemplateProperty);


        public static readonly DependencyProperty IconTemplateProperty =
            DependencyProperty.RegisterAttached("IconTemplate", typeof(ControlTemplate), typeof(WindowProperty));

        public static void SetIconTemplate(Window window, ControlTemplate template) => window.SetValue(HeaderTemplateProperty, template);

        public static ControlTemplate GetIconTempalte(Window window) => (ControlTemplate)window.GetValue(HeaderTemplateProperty);
    }
}
