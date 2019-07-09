using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Tita
{
    public class SuffixConverter : MarkupExtension, IValueConverter
    {
        

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString() + parameter.ToString();
            
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
