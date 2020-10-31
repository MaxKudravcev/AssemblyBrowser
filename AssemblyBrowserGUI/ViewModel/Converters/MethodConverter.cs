using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;
using System.Linq;

namespace AssemblyBrowserGUI.ViewModel.Converters
{
    class MethodConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MethodInfo mi = value as MethodInfo;
            string res = (mi.IsPublic ? "public " : "private ") + (mi.IsStatic ? "static " : "") + (mi.IsVirtual ? "virtual " : "") +
                         (mi.IsAbstract ? "abstract " : "") + (mi.IsFinal ? "final " : "") + GenericTypeNameConverter.ConvertGenericTypeName(mi.ReturnType) +
                         " " + mi.Name + " (" + string.Join(", ", mi.GetParameters().Select(pi => GenericTypeNameConverter.ConvertGenericTypeName(pi.ParameterType) +
                         " " + pi.Name)) + ")";

            if (mi.GetCustomAttribute<System.Runtime.CompilerServices.CompilerGeneratedAttribute>() != null)
                res += "  <- extension method";
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
