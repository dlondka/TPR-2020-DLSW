using Task03;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Task03.Tests
{
	[TestClass()]
	public class MethodsTest
	{
		[TestMethod()]
		public void GetProductsByNameTest()
		{
			List<Product> products = Methods.GetProductsByName("Metal Sheet");

			Assert.AreEqual(7, products.Count);
			Assert.AreEqual("MS-0253", products[0].ProductNumber);
			Assert.AreEqual("MS-1256", products[1].ProductNumber);
			Assert.AreEqual("MS-1981", products[2].ProductNumber);
			Assert.AreEqual("MS-2259", products[3].ProductNumber);
			Assert.AreEqual("MS-2341", products[4].ProductNumber);
			Assert.AreEqual("MS-2348", products[5].ProductNumber);
			Assert.AreEqual("MS-6061", products[6].ProductNumber);
		}

		[TestMethod()]
		public void GetProductsByVendorNameTest()
		{
			List<Product> products = Methods.GetProductsByVendorName("Custom Frames, Inc.");

			Assert.AreEqual(14, products.Count);
			Assert.AreEqual("MS-0253", products[6].ProductNumber);
			Assert.AreEqual("MS-1256", products[7].ProductNumber);
			Assert.AreEqual("MS-1981", products[8].ProductNumber);
			Assert.AreEqual("MS-2259", products[9].ProductNumber);
			Assert.AreEqual("MS-2341", products[10].ProductNumber);
			Assert.AreEqual("MS-2348", products[11].ProductNumber);
			Assert.AreEqual("MS-6061", products[12].ProductNumber);
		}

		[TestMethod()]
		public void GetProductNamesByVendorNameTest()
		{
			List<string> products = Methods.GetProductNamesByVendorName("Custom Frames, Inc.");

			Assert.AreEqual(14, products.Count);
			Assert.AreEqual("Metal Sheet 2", products[6]);
			Assert.AreEqual("Metal Sheet 3", products[7]);
			Assert.AreEqual("Metal Sheet 7", products[8]);
			Assert.AreEqual("Metal Sheet 4", products[9]);
			Assert.AreEqual("Metal Sheet 5", products[10]);
			Assert.AreEqual("Metal Sheet 6", products[11]);
			Assert.AreEqual("Metal Sheet 1", products[12]);
		}

		[TestMethod()]
		public void GetProductVendorByProductNameTest()
		{
			string vendorName = Methods.GetProductVendorByProductName("Metal Sheet 1");
			Assert.AreEqual("Custom Frames, Inc.", vendorName);
		}

		[TestMethod()]
		public void GetProductsWithNRecentReviewsTest()
		{
			List<Product> products = Methods.GetProductsWithNRecentReviews(5);
			Assert.AreEqual(3, products.Count);
			Assert.AreEqual("Mountain Bike Socks, M", products[0].Name);
			Assert.AreEqual("Road-550-W Yellow, 40", products[1].Name);
			Assert.AreEqual("HL Mountain Pedal", products[2].Name);
		}

		[TestMethod()]
		public void GetNRecentlyReviewedProductsTest()
		{
			List<Product> products = Methods.GetNRecentlyReviewedProducts(4);
			Assert.AreEqual(4, products.Count);
			Assert.AreEqual("Mountain Bike Socks, M", products[0].Name);
			Assert.AreEqual("HL Mountain Pedal", products[1].Name);
			Assert.AreEqual("HL Mountain Pedal", products[2].Name);
			Assert.AreEqual("Road-550-W Yellow, 40", products[3].Name);
		}

		[TestMethod()]
		public void GetNProductsFromCategoryTest()
		{
			List<Product> products = Methods.GetNProductsFromCategory("Bikes", 5);

			Console.WriteLine(products[0].Name);
			Console.WriteLine(products[1].Name);
			Console.WriteLine(products[2].Name);
			Console.WriteLine(products[3].Name);
			Console.WriteLine(products[4].Name);

			Assert.AreEqual(5, products.Count);
			Assert.AreEqual("Mountain-100 Black, 38", products[0].Name);
			Assert.AreEqual("Mountain-100 Black, 42", products[1].Name);
			Assert.AreEqual("Mountain-100 Black, 44", products[2].Name);
			Assert.AreEqual("Mountain-100 Black, 48", products[3].Name);
			Assert.AreEqual("Mountain-100 Silver, 38", products[4].Name);
		}

		[TestMethod()]
		public void GetTotalStandardCostByCategoryTest()
		{
			ProductCategory bikes = Methods.GetProductCategoryByString("Bikes");
			int cost = Methods.GetTotalStandardCostByCategory(bikes);

			Assert.AreEqual(92092, cost);
		}

		[TestMethod()]
		public void GetProductCategoryByStringTest()
		{
			ProductCategory productCategory = Methods.GetProductCategoryByString("Bikes");

			Assert.AreEqual("Bikes", productCategory.Name);
		}
	}
}