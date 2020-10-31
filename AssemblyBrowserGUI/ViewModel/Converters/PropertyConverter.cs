using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace AssemblyBrowserGUI.ViewModel.Converters
{
    class PropertyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PropertyInfo pi = value as PropertyInfo;
            return $"{GenericTypeNameConverter.ConvertGenericTypeName(pi.PropertyType)} {pi.Name}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
