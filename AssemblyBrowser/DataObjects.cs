using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowserLib
{
    public class TypeDO
    {
        public Type Type { get; private set; }

        public List<MethodInfo> Methods { get; private set; } = new List<MethodInfo>();

        public List<PropertyInfo> Properties { get; private set; } = new List<PropertyInfo>();

        public List<FieldInfo> Fields { get; private set; } = new List<FieldInfo>();

        public TypeDO(Type type)
        {
            Type = type;
        }
    }

    public class NamespaceDO
    {
        public string Name { get; private set; }

        public List<TypeDO> Types { get; private set; } = new List<TypeDO>();


        public NamespaceDO(string name)
        {
            Name = name;
        }
    }

    public class AssemblyDO
    {
        public string Name { get; private set; }

        public List<NamespaceDO> Namespaces { get; private set; } = new List<NamespaceDO>();


        public AssemblyDO(string name)
        {
            Name = name;
        }
    }
}