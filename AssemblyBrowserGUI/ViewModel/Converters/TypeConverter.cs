using System;
using System.Globalization;
using System.Windows.Data;

namespace AssemblyBrowserGUI.ViewModel.Converters
{
    class TypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type type = value as Type;
            string res = (type.IsPublic ? "public " : "private ") + (type.IsAbstract ? "abstract " : "") + (type.IsSealed ? "sealed " : "") +
                         (type.IsInterface ? "interface " : "") + (type.IsValueType ? "struct " : "") + (type.IsClass ? "class " : "") +
                         GenericTypeNameConverter.ConvertGenericTypeName(type);
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
