using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaceTransport.Scripts.Converters
{
    public class TurnConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                if (!values[0].Equals(0) && !values[1].Equals(0))
                {
                    double distance = (double)values[0];
                    double speed = (double)values[1];

                    return Math.Ceiling(distance / speed);
                }
            }

            return 0;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
