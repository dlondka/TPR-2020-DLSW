using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary.Tests
{
	[TestClass()]
	public class DataRepositoryTests
	{
		[TestMethod()]
		public void DataRepositoryTest1()
		{
			DataRepository dr1 = new DataRepository();
			Assert.AreEqual(dr1.GetAllBooks().Count(), 0);
			Assert.AreEqual(dr1.GetAllPurchases().Count(), 0);
			Assert.AreEqual(dr1.GetAllBooksDetails().Count(), 0);
			Assert.AreEqual(dr1.GetAllClients().Count(), 0);
		}

		[TestMethod()]
		public void DataRepositoryTest2()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Assert.AreEqual(dataRepository.GetAllBooks().Count(), 5);
			Assert.AreEqual(dataRepository.GetAllPurchases().Count(), 5);
			Assert.AreEqual(dataRepository.GetAllBooksDetails().Count(), 5);
			Assert.AreEqual(dataRepository.GetAllClients().Count(), 5);
		}

		[TestMethod()]
		public void AddBookTest()
		{

		}

		[TestMethod()]
		public void AddBookDetailsTest()
		{

		}

		[TestMethod()]
		public void AddClientTest()
		{

		}

		[TestMethod()]
		public void AddPurchaseTest()
		{

		}

		[TestMethod()]
		public void DeleteBookTest()
		{

		}

		[TestMethod()]
		public void DeleteBookDetailsTest()
		{

		}

		[TestMethod()]
		public void DeleteClientTest()
		{

		}

		[TestMethod()]
		public void DeletePurchaseTest()
		{

		}

		[TestMethod()]
		public void FindBookTest()
		{

		}

		[TestMethod()]
		public void FindBookDetailsTest()
		{

		}

		[TestMethod()]
		public void FindClientTest()
		{

		}

		[TestMethod()]
		public void FindPurchaseTest()
		{

		}

		[TestMethod()]
		public void GetAllBooksTest()
		{

		}

		[TestMethod()]
		public void GetAllBooksDetailsTest()
		{

		}

		[TestMethod()]
		public void GetAllClientsTest()
		{

		}

		[TestMethod()]
		public void GetAllPurchasesTest()
		{

		}

		[TestMethod()]
		public void GetBookTest()
		{

		}

		[TestMethod()]
		public void GetBookDetailsTest()
		{

		}

		[TestMethod()]
		public void GetClientTest()
		{

		}

		[TestMethod()]
		public void GetPurchaseTest()
		{

		}

		[TestMethod()]
		public void UpdateBookTest()
		{

		}

		[TestMethod()]
		public void UpdateBookDetailsTest()
		{

		}

		[TestMethod()]
		public void UpdateClientTest()
		{

		}

		[TestMethod()]
		public void UpdatePurchaseTest()
		{

		}
	}
}