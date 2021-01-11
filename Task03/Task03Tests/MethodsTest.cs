using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task03.Tests
{
	[TestClass()]
	public class MethodsTest
	{
		[TestMethod()]
		public void GetProductsByNameTest()
		{
			Methods methods = new Methods();
			List<Product> products = methods.GetProductsByName("Metal Sheet");
			methods.CloseConnection();
			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.ProductNumber.CompareTo(p2.ProductNumber);
				});

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
			Methods methods = new Methods();
			List<Product> products = methods.GetProductsByVendorName("Custom Frames, Inc.");
			methods.CloseConnection();
			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.ProductNumber.CompareTo(p2.ProductNumber);
				});

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
			Methods methods = new Methods();
			List<string> products = methods.GetProductNamesByVendorName("Custom Frames, Inc.");
			methods.CloseConnection();
			products.Sort();

			Assert.AreEqual(14, products.Count);
			Assert.AreEqual("Metal Sheet 1", products[6]);
			Assert.AreEqual("Metal Sheet 2", products[7]);
			Assert.AreEqual("Metal Sheet 3", products[8]);
			Assert.AreEqual("Metal Sheet 4", products[9]);
			Assert.AreEqual("Metal Sheet 5", products[10]);
			Assert.AreEqual("Metal Sheet 6", products[11]);
			Assert.AreEqual("Metal Sheet 7", products[12]);
		}

		[TestMethod()]
		public void GetProductVendorByProductNameTest()
		{
			Methods methods = new Methods();
			string vendorName = methods.GetProductVendorByProductName("Metal Sheet 1");
			methods.CloseConnection();

			Assert.AreEqual("Custom Frames, Inc.", vendorName);
		}

		[TestMethod()]
		public void GetProductsWithNRecentReviewsTest()
		{
			Methods methods = new Methods();
			List<Product> products = methods.GetProductsWithNRecentReviews(5);
			methods.CloseConnection();
			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.Name.CompareTo(p2.Name);
				});

			Assert.AreEqual(3, products.Count);
			Assert.AreEqual("HL Mountain Pedal", products[0].Name);
			Assert.AreEqual("Mountain Bike Socks, M", products[1].Name);
			Assert.AreEqual("Road-550-W Yellow, 40", products[2].Name);
		}

		[TestMethod()]
		public void GetNRecentlyReviewedProductsTest()
		{
			Methods methods = new Methods();
			List<Product> products = methods.GetNRecentlyReviewedProducts(4);
			methods.CloseConnection();
			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.Name.CompareTo(p2.Name);
				});

			Assert.AreEqual(4, products.Count);
			Assert.AreEqual("HL Mountain Pedal", products[0].Name);
			Assert.AreEqual("HL Mountain Pedal", products[1].Name);
			Assert.AreEqual("Mountain Bike Socks, M", products[2].Name);
			Assert.AreEqual("Road-550-W Yellow, 40", products[3].Name);
		}

		[TestMethod()]
		public void GetNProductsFromCategoryTest()
		{
			Methods methods = new Methods();
			List<Product> products = methods.GetNProductsFromCategory("Bikes", 5);
			methods.CloseConnection();
			products.Sort(
				delegate (Product p1, Product p2)
				{
					return p1.Name.CompareTo(p2.Name);
				});

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
			Methods methods = new Methods();
			ProductCategory bikes = methods.GetProductCategoryByName("Bikes");
			int cost = methods.GetTotalStandardCostByCategory(bikes);
			methods.CloseConnection();

			Assert.AreEqual(92092, cost);
		}

		[TestMethod()]
		public void GetProductCategoryByNameTest()
		{
			Methods methods = new Methods();
			ProductCategory productCategory = methods.GetProductCategoryByName("Bikes");
			methods.CloseConnection();

			Assert.AreEqual("Bikes", productCategory.Name);
		}
	}
}