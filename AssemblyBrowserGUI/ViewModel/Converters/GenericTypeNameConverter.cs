using System;
using System.Linq;

namespace AssemblyBrowserGUI.ViewModel.Converters
{
    class GenericTypeNameConverter
    {
        public static string ConvertGenericTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                string res = type.Name;
                res = res.Remove(res.IndexOf('`')) + '<';
                Type[] genericArgs = type.GetGenericArguments();
                
                res = res + string.Join(", ", genericArgs.Select(t => ConvertGenericTypeName(t))) + '>';
                return res;
            }
            return type.Name;
        }
    }
}
