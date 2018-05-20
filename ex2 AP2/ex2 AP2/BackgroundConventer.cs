using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ex2_AP2
{
    /// <summary>
    /// a converter for the backgroud - if the client is connected then it would be green, otherwise 
    /// gray.
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    class BackgroundConventer : IValueConverter
    {
        public static readonly IValueConverter Instance = new BackgroundConventer();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush))
                throw new InvalidOperationException("Must convert to a brush!");
            bool connected = (bool)value;
            if (connected)
            {
                return Brushes.Green;
            }
            else
            {
                return Brushes.LightGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
