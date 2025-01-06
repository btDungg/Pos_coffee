using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Converters
{
    public class PriceConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal decimalValue)
            {
                CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
                string formattedAmount = decimalValue.ToString("C0", vietnameseCulture); // Định dạng trực tiếp
                return formattedAmount;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string priceString)
            {
                try
                {
                    // Loại bỏ ký hiệu tiền tệ và khoảng trắng không cần thiết
                    priceString = priceString.Replace("₫", "").Trim();
                    var priceDecimal = decimal.Parse(priceString, NumberStyles.Number, new CultureInfo("vi-VN"));
                    return priceDecimal;
                }
                catch (FormatException)
                {
                    // Trả về giá trị mặc định nếu có lỗi định dạng
                    return DependencyProperty.UnsetValue;
                }
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
