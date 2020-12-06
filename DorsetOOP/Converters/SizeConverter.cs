/// Team 18
/// Student names | ID:
/// Wim POIGNON | 23408
/// Maélis YONES | 23217
/// Rémi LOMBARD | 23210
/// Christophe NGUYEN | 23219
/// Gwendoline MAREK | 23397
/// Maxime DENNERY | 23203
/// Victor TACHOIRES | 22844

using System;
using System.Windows.Data;

namespace DorsetOOP.Converters
{
    public class SizeConverter : IValueConverter // Typical converter, inherits from IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double width = Double.Parse(value.ToString());
            //Subtract 1, otherwise we could overflow to two rows.
            return .25 * width - 1; // Returns a quarter
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
