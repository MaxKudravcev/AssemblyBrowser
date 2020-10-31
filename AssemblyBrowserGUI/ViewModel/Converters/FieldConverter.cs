using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace AssemblyBrowserGUI.ViewModel.Converters
{
    class FieldConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FieldInfo fi = value as FieldInfo;
            string res = (fi.IsPublic ? "public " : "private ") + (fi.IsStatic ? "static " : ""); 
            return res + $"{GenericTypeNameConverter.ConvertGenericTypeName(fi.FieldType)} {fi.Name}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
