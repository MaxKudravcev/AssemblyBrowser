using System.Reflection;
using System.Linq;
using System;

namespace AssemblyBrowserLib
{
    public class AssemblyBrowser
    {
        //public AssemblyDO Assembly { get; private set; }

        public AssemblyDO BrowseAssembly(Assembly assembly)
        {
            AssemblyDO res = new AssemblyDO(assembly.FullName);
            var definedTypes = assembly.GetTypes().ToList();

            foreach(Type t in definedTypes)
            {
                if (!res.Namespaces.Any(ns => ns.Name == t.Namespace))
                    res.Namespaces.Add(new NamespaceDO(t.Namespace));

                if(!IsCompilerGenerated(t))
                res.Namespaces.Find(ns => ns.Name == t.Namespace).Types.Add(t);
            }

            return res;
        }

        private bool IsCompilerGenerated(Type type)
        {
            return type.GetCustomAttribute<System.Runtime.CompilerServices.CompilerGeneratedAttribute>() != null;
        }
    }
}
