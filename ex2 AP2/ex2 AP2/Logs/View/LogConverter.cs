using ImageService.ImageService.Logging;
using ImageService.ImageService.Logging.Modal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ex2_AP2.Logs.View
{
    class LogConventer : IValueConverter {
        public static readonly IValueConverter Instance = new LogConventer();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Brush))
                throw new InvalidOperationException("Must convert to a brush!");
            if (value.ToString().Equals(MessageTypeEnum.FAIL.ToString()))
            {
                return Brushes.Red;
            } else if (value.ToString().Equals(MessageTypeEnum.INFO.ToString()))
            {
                return Brushes.Green;
            }
            else if (value.ToString().Equals(MessageTypeEnum.WARNING.ToString()))
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.Transparent ;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
