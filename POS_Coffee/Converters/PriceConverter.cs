using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Converters
{
    public class PriceConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value + " VND";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string priceString = value.ToString();
            priceString = priceString.Replace(" VND", ""); // Loại bỏ " VND"
            decimal priceDecimal = decimal.Parse(priceString);
            return priceDecimal;
        }
    }
}
