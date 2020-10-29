using System;
using System.Collections.Generic;

namespace AssemblyBrowserLib
{
    public class NamespaceDO
    {
        public string Name { get; private set; }

        public List<Type> Types { get; private set; } = new List<Type>();


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