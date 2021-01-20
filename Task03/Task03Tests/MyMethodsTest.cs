using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task03.Tests
{
	[TestClass()]
	public class MyMethodsTest
	{
		[TestMethod()]
		public void GetProductsByNameTest()
		{
            List<MyProduct> products = MyMethods.GetProductsByName("");

            Assert.AreEqual(4, products.Count);
            Assert.AreEqual("Przepis na człowieka", products[0].Name);
            Assert.AreEqual("Włam się do mózgu", products[1].Name);
            Assert.AreEqual("Milka", products[2].Name);
            Assert.AreEqual("Piernik", products[3].Name);
        }

		[TestMethod()]
		public void GetProductsByVendorNameTest()
		{
            List<MyProduct> products = MyMethods.GetProductsByVendorName("E.Wedel");

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Milka", products[0].Name);
            Assert.AreEqual("Piernik", products[1].Name);
        }

		[TestMethod()]
		public void GetNProductsFromCategoryTest()
		{
            List<MyProduct> products = MyMethods.GetNProductsFromCategory("Books", 2);

            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Przepis na człowieka", products[0].Name);
            Assert.AreEqual("Włam się do mózgu", products[1].Name);
        }
	}
}