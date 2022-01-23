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

namespace Lab2._6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    class WeatherControl : DependencyObject
    {
        private string windDir;
        private byte windSpeed;

        public string WindDir
        {
            get { return windDir; }
            set { windDir = value; }
        }
        public byte WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                if (value >= 0)
                    windSpeed = value;
                else
                    windSpeed = 0;
            }
        }
        public sbyte Temp
        {
            get => (sbyte)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public static readonly DependencyProperty TempProperty;

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(sbyte),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            if (SByte.TryParse((string)value, out sbyte result))
                return true;
            else
                return false;
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            sbyte v = (sbyte)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }
         public enum PrecipitationOptions
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 4,
        }
    }
}
