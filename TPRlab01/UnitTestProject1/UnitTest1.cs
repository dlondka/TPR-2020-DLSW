using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        Class1 class1 = new Class1();

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(class1.add(2, 0.231), 2 + 0.231);
        }
    }
}
