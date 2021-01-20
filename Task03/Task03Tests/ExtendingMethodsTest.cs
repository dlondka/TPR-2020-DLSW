using Task03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task03.Tests
{
	[TestClass()]
	public class ExtendingMethodsTest
	{
		[TestMethod()]
		public void GetProductsWithoutCategoryQTest()
		{
			List<Product> products;
			using (ExtendingMethods extendingMethods = new ExtendingMethods())
			{
				using (Methods methods = new Methods())
				{
					products = extendingMethods.GetProductsWithoutCategoryQ(methods.GetProductsByName("Ch"));
				}
			}

			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.Name.CompareTo(p2.Name);
				});

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
			List<Product> products;
			using (ExtendingMethods extendingMethods = new ExtendingMethods())
			{
				using (Methods methods = new Methods())
				{
					products = extendingMethods.GetProductsWithoutCategoryQ(methods.GetProductsByName("Ch"));
				}
			}

			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.Name.CompareTo(p2.Name);
				});

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
			List<Product> products;
			using (ExtendingMethods extendingMethods = new ExtendingMethods())
			{
				using (Methods methods = new Methods())
				{
					products = extendingMethods.GetProductsAsPageWithSize(methods.GetProductsByName(""), 5, 2);
				}
			}

			Assert.AreEqual(5, products.Count);
		}

		[TestMethod()]
		public void GetProductsWithVendorNameQTest()
		{
			string products;
			using (ExtendingMethods extendingMethods = new ExtendingMethods())
			{
				using (Methods methods = new Methods())
				{
					products = extendingMethods.GetProductsWithVendorNameQ(methods.GetProductsByName(""));
				}
			}

			List<string> productsList = products.Split('\n').ToList();
			productsList.Sort();

			Assert.AreEqual(17517, products.Length);
			Assert.AreEqual("Adjustable Race - Litware, Inc.", productsList[0]);
			Assert.AreEqual("All-Purpose Bike Stand - Green Lake Bike Company", productsList[1]);
			Assert.AreEqual("AWC Logo Cap - Integrated Sport Products", productsList[2]);
		}

		[TestMethod()]
		public void GetProductsNamesWithVendorNameMTest()
		{
			string products;
			using (ExtendingMethods extendingMethods = new ExtendingMethods())
			{
				using (Methods methods = new Methods())
				{
					products = extendingMethods.GetProductsWithVendorNameQ(methods.GetProductsByName(""));
				}
			}

			List<string> productsList = products.Split('\n').ToList();
			productsList.Sort();

			Assert.AreEqual(17517, products.Length);
			Assert.AreEqual("Adjustable Race - Litware, Inc.", productsList[0]);
			Assert.AreEqual("All-Purpose Bike Stand - Green Lake Bike Company", productsList[1]);
			Assert.AreEqual("AWC Logo Cap - Integrated Sport Products", productsList[2]);
		}
	}
}