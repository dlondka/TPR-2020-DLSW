using Task03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task03.Tests
{
	[TestClass()]
	public class ExtendingMethodsTest
	{
		[TestMethod()]
		public void GetProductsWithoutCategoryQTest()
		{
			List<Product> products = ExtendingMethods.GetProductsWithoutCategoryQ(Methods.GetProductsByName("Ch"));

			Assert.AreEqual(5, products.Count);
			Assert.AreEqual("Chain Stays", products[0].Name);
			Assert.AreEqual("Chainring", products[1].Name);
			Assert.AreEqual("Chainring Bolts", products[2].Name);
			Assert.AreEqual("Chainring Nut", products[3].Name);
			Assert.AreEqual("Pinch Bolt", products[4].Name);
		}

		[TestMethod()]
		public void GetProductWithoutCategoryMTest()
		{
			List<Product> products = ExtendingMethods.GetProductsWithoutCategoryQ(Methods.GetProductsByName("Ch"));

			Assert.AreEqual(5, products.Count);
			Assert.AreEqual("Chain Stays", products[0].Name);
			Assert.AreEqual("Chainring", products[1].Name);
			Assert.AreEqual("Chainring Bolts", products[2].Name);
			Assert.AreEqual("Chainring Nut", products[3].Name);
			Assert.AreEqual("Pinch Bolt", products[4].Name);
		}

		[TestMethod()]
		public void GetProductsAsPageWithSizeTest()
		{
			List<Product> products = ExtendingMethods.GetProductsAsPageWithSize(Methods.GetProductsByName("A"), 5, 2);

			Assert.AreEqual(5, products.Count);
			Assert.AreEqual("LL Crankarm", products[0].Name);
			Assert.AreEqual("ML Crankarm", products[1].Name);
			Assert.AreEqual("HL Crankarm", products[2].Name);
			Assert.AreEqual("Chainring Bolts", products[3].Name);
			Assert.AreEqual("Chainring Nut", products[4].Name);
		}

		[TestMethod()]
		public void GetProductsWithVendorNameQTest()
		{
			string products = ExtendingMethods.GetProductsWithVendorNameQ(Methods.GetProductsByName("A"));

			Assert.AreEqual(12993, products.Length);
			Assert.AreEqual("Adjustable Race - Litware, Inc.", products.Split('\n')[0]);
			Assert.AreEqual("Bearing Ball - Wood Fitness", products.Split('\n')[1]);
			Assert.AreEqual("Headset Ball Bearings - American Bicycles and Wheels", products.Split('\n')[2]);
		}
	}
}