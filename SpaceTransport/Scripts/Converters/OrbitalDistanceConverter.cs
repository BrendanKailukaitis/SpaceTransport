using System;
using System.Globalization;
using System.Windows.Data;

namespace SpaceTransport.Scripts.Converters
{
    public class OrbitalDistanceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null)
            {
                return 0;
            }

            Orbital origin = values[0] as Orbital;
            Orbital destination = values[1] as Orbital;

            double distance = Math.Abs(origin.Distance - destination.Distance);

            return distance;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
