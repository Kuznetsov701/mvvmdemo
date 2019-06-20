using MVVM.Demo3.Utilty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM.Demo3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Items = new MyDic();
            Items["a1"] = 5;
            Items["a1"] = 8;
            Items["a2"] = "da";
        }

        #region MyDic Items = null
        public MyDic Items
        {
            get { return (MyDic)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                nameof(Items),
                typeof(MyDic),
                typeof(MainWindow),
                new PropertyMetadata(null));
        #endregion
    }

    public class MyDic : ObservableObject
    {
        Dictionary<string, object> Data = new Dictionary<string, object>();

        public object this[string key]
        {
            get {
                if (Data.ContainsKey(key))
                    return Data[key];
                else
                    return null;
            }
            set {
                if (Data.ContainsKey(key))
                {
                    object o = Data[key];
                    if (OnPropertyChanged(ref o, value, $"Item[{ key }]"))
                        Data[key] = o;
                }
                else
                {
                    object o = null;
                    if (OnPropertyChanged(ref o, value, $"Item[{ key }]"))
                        Data.Add(key, o);
                }
            }
        }
    }
}
