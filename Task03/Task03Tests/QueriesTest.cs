using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Task03.Tests
{
	[TestClass()]
	public class QueriesTest
	{
		[TestMethod()]
		public void GetProductsByNameTest()
		{
			Queries queries = new Queries();
			List<Product> products = queries.GetProductsByName("Metal Sheet");
			queries.CloseConnection();
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
			Queries queries = new Queries();
			List<Product> products = queries.GetProductsByVendorName("Custom Frames, Inc.");
			queries.CloseConnection();
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
			Queries queries = new Queries();
			List<string> products = queries.GetProductNamesByVendorName("Custom Frames, Inc.");
			queries.CloseConnection();
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
			Queries queries = new Queries();
			string vendorName = queries.GetProductVendorByProductName("Metal Sheet 1");
			queries.CloseConnection();

			Assert.AreEqual("Custom Frames, Inc.", vendorName);
		}

		[TestMethod()]
		public void GetProductsWithNRecentReviewsTest()
		{
			Queries queries = new Queries();
			List<Product> products = queries.GetProductsWithNRecentReviews(5);
			queries.CloseConnection();
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
			Queries queries = new Queries();
			List<Product> products = queries.GetNRecentlyReviewedProducts(4);
			queries.CloseConnection();
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
			Queries queries = new Queries();
			List<Product> products = queries.GetNProductsFromCategory("Bikes", 5);
			queries.CloseConnection();
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
			Queries queries = new Queries();
			ProductCategory bikes = queries.GetProductCategoryByName("Bikes");
			int cost = queries.GetTotalStandardCostByCategory(bikes);
			queries.CloseConnection();

			Assert.AreEqual(92092, cost);
		}

		[TestMethod()]
		public void GetProductCategoryByNameTest()
		{
			Queries queries = new Queries();
			ProductCategory productCategory = queries.GetProductCategoryByName("Bikes");
			queries.CloseConnection();

			Assert.AreEqual("Bikes", productCategory.Name);
		}
	}
}