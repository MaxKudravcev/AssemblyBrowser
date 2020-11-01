using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AssemblyBrowserLib;

namespace AssemblyBrowser.Tests
{
    [TestClass]
    public class AssemblyBrowserTests
    {
        private AssemblyDO asmDO;

        [TestInitialize]
        public void TestsInit()
        {
            AssemblyBrowserLib.AssemblyBrowser browser = new AssemblyBrowserLib.AssemblyBrowser();
            Assembly asm = Assembly.LoadFrom("TestLib.dll");
            asmDO = browser.BrowseAssembly(asm);
        }

        [TestMethod]
        public void NamespacesTest()
        {
            Assert.AreEqual(2, asmDO.Namespaces.Count);
            Assert.AreEqual("TestLib", asmDO.Namespaces[0].Name);
            Assert.AreEqual("System", asmDO.Namespaces[1].Name);
        }

        [TestMethod]
        public void ExtensionMethodTest()
        {
            TypeDO typeDO = asmDO.Namespaces[1].Types[0];
            Assert.AreEqual("String", typeDO.Type.Name);
            Assert.AreEqual(1, typeDO.Methods.Count);
            Assert.AreEqual("CharCount", typeDO.Methods[0].Name);
        }

        [TestMethod]
        public void StructTest()
        {
            TypeDO typeDO = asmDO.Namespaces[0].Types[1];
            Assert.IsTrue(typeDO.Fields.Count == 1 && typeDO.Fields[0].Name == "a");
            Assert.IsTrue(typeDO.Properties.Count == 1 && typeDO.Properties[0].Name == "A");
            Assert.IsTrue(typeDO.Methods.Count == 7 && typeDO.Methods.Exists(mi => mi.Name == "TestMethod"));
        }

        [TestMethod]
        public void ClassTest()
        {
            TypeDO typeDO = asmDO.Namespaces[0].Types[0];
            Assert.IsTrue(typeDO.Type.IsAbstract && typeDO.Type.IsSealed);
            Assert.AreEqual("StaticWithExtensions", typeDO.Type.Name);
            Assert.IsTrue(typeDO.Fields.Count == 1 && typeDO.Fields[0].Name == "a");
            Assert.IsTrue(typeDO.Methods.Count == 6);
        }
    }
}
