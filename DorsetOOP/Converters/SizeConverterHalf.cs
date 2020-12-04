using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace DorsetOOP.Converters
{
	/// <summary>
	/// Name of the Students :
	/// Wim Poignon 23408
    /// </summary>
    public class SizeConverterHalf : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            double width = Double.Parse(value.ToString());
            //Subtract 1, otherwise we could overflow to two rows.
            return .5 * width - 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
