using BookstoreLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookstoreLib.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void addTest()
        {
            Class1 class1 = new Class1();
            Assert.AreEqual(class1.add(1, 1.1), 2.1);
        }
    }
}
