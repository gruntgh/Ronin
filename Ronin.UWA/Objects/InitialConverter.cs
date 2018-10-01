using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Ronin.UWA.Converters
{
    public class InitialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.GetType() == typeof(string))
            {
                string retVal = value as String;
                if (!String.IsNullOrEmpty(retVal))
                {
                    return retVal.Substring(0, 1);
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
