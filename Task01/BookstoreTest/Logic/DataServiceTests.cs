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
	public class DataServiceTests
	{
		[TestMethod()]
		public void AddBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);

			Assert.AreEqual(dataService.GetAllBooks().Count(), 5);
			dataService.AddBook(book);
			Assert.AreEqual(dataService.GetAllBooks().Count(), 6);
		}

		[TestMethod()]
		public void AddBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");

			Assert.AreEqual(dataService.GetAllBookDetails().Count(), 5);
			dataService.AddBookDetails(bookDetails);
			Assert.AreEqual(dataService.GetAllBookDetails().Count(), 6);
		}

		[TestMethod()]
		public void AddClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.AreEqual(dataService.GetAllClients().Count(), 5);
			dataService.AddClient(client);
			Assert.AreEqual(dataService.GetAllClients().Count(), 6);
		}

		[TestMethod()]
		public void BuyBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.AreEqual(dataService.GetNumberOfBooks(book), 33);
			dataService.BuyBook(client, bookDetails);
			Assert.AreEqual(dataService.GetNumberOfBooks(book), 32);
			Assert.IsTrue(dataService.GetPurchasesForClient(client).First().BookDetails.Equals(bookDetails));
			Assert.IsTrue(dataService.GetPurchasesForClient(client).First().Client.Equals(client));
		}

		[TestMethod()]
		public void DeleteBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();

		}

		[TestMethod()]
		public void DeleteBookTest1()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void DeleteBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void DeleteClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void DeletePurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetAllBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetAllBooksTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetAllClientsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetAllPurchasesTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetNumberOfBooksTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetNumberOfBooksTest1()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetPurchasesBetweenTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetPurchasesForBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetPurchasesForClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetPurchase(0), dataService.GetPurchasesForClient(dataService.GetPurchase(0).Client));
		}

		[TestMethod()]
		public void GetBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			//Assert.AreEqual(dataService.GetAllBooks[0]
			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			throw new NotImplementedException();
		}


		[TestMethod()]
		public void GetPurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);
			throw new NotImplementedException();
		}
	}
}