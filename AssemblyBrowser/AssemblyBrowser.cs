using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AssemblyBrowserLib
{
    public class AssemblyBrowser
    {
        //public AssemblyDO Assembly { get; private set; }

        public AssemblyDO BrowseAssembly(Assembly assembly)
        {
            AssemblyDO res = new AssemblyDO(assembly.GetName().Name);
            var definedTypes = assembly.GetTypes().ToList();
            List<MethodInfo> extensionMethods = new List<MethodInfo>();

            foreach (Type t in definedTypes)
            {
                if (!IsCompilerGenerated(t))
                {
                    if (!res.Namespaces.Any(ns => ns.Name == t.Namespace))
                        res.Namespaces.Add(new NamespaceDO(t.Namespace));

                    TypeDO typeDO = new TypeDO(t);
                    typeDO.Properties.AddRange(t.GetProperties());
                    typeDO.Fields.AddRange(t.GetFields());

                    if (t.IsAbstract && t.IsSealed)                 //Check for extension methods
                        foreach (MethodInfo mi in t.GetMethods())           
                            if (mi.IsDefined(typeof(ExtensionAttribute)))
                                extensionMethods.Add(mi);
                            else typeDO.Methods.Add(mi);
                    else typeDO.Methods.AddRange(t.GetMethods());

                    res.Namespaces.Find(ns => ns.Name == t.Namespace).Types.Add(typeDO);
                }
            }

            extensionMethods.ForEach(mi =>
            {
                Type extendedType = mi.GetParameters()[0].ParameterType;
                TypeDO typeDO = FindTypeDO(res, extendedType);
                if (typeDO != null)
                    typeDO.Methods.Add(mi);
                else
                {
                    TypeDO extendedTypeDO = new TypeDO(extendedType);
                    extendedTypeDO.Methods.Add(mi);
                    NamespaceDO nsDO = res.Namespaces.Find(ns => ns.Name == extendedType.Namespace);
                    if (nsDO != null)
                        nsDO.Types.Add(extendedTypeDO);
                    else
                    {
                        NamespaceDO extendedNSDO = new NamespaceDO(extendedType.Namespace);
                        extendedNSDO.Types.Add(extendedTypeDO);
                        res.Namespaces.Add(extendedNSDO);
                    }
                }
            });

            return res;
        }

        private bool IsCompilerGenerated(Type type)
        {
            return type.GetCustomAttribute<System.Runtime.CompilerServices.CompilerGeneratedAttribute>() != null;
        }

        private TypeDO FindTypeDO(AssemblyDO asm, Type type)
        {
            NamespaceDO ns = asm.Namespaces.Find(nDO => nDO.Name == type.Namespace);
            TypeDO typeDO = ns != null ? ns.Types.Find(t => t.Type == type) : null;
            return typeDO;
        }
    }
}
