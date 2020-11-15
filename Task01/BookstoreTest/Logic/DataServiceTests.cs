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
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(dataService.GetNumberOfBooks(book), 33);
			dataService.BuyBook(client, bookDetails);
			Assert.AreEqual(dataService.GetNumberOfBooks(book), 32);
			Assert.IsTrue(dataService.GetPurchasesForClient(client).First().BookDetails.Equals(bookDetails));
			Assert.IsTrue(dataService.GetPurchasesForClient(client).First().Client.Equals(client));
		}

		[TestMethod()]
		public void DeleteBookByBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllBooks().Count());
			dataService.DeleteBook(dataService.GetAllBooks().First());
			Assert.AreEqual(4, dataService.GetAllBooks().Count());

		}

		[TestMethod()]
		public void DeleteBookByKeyTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllBooks().Count());
			dataService.DeleteBook(dataService.GetBook(0));
			Assert.AreEqual(4, dataService.GetAllBooks().Count());
		}

		[TestMethod()]
		public void DeleteBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllBookDetails().Count());
			dataService.DeleteBookDetails(dataService.GetBookDetails(0));
			Assert.AreEqual(4, dataService.GetAllBookDetails().Count());
		}

		[TestMethod()]
		public void DeleteClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllClients().Count());
			dataService.DeleteClient(dataService.GetClient(0));
			Assert.AreEqual(4, dataService.GetAllClients().Count());
		}

		[TestMethod()]
		public void DeletePurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllPurchases().Count());
			dataService.DeletePurchase(dataService.GetPurchase(0));
			Assert.AreEqual(4, dataService.GetAllPurchases().Count());
		}

		[TestMethod()]
		public void GetAllBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllBookDetails().Count());
		}

		[TestMethod()]
		public void GetAllBooksTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllBooks().Count());
		}

		[TestMethod()]
		public void GetAllClientsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllClients().Count());
		}

		[TestMethod()]
		public void GetAllPurchasesTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(5, dataService.GetAllPurchases().Count());
		}

		[TestMethod()]
		public void GetNumberOfBooksByBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetBookDetails(0).Count, dataService.GetNumberOfBooks(dataService.GetBookDetails(0).Book));
		}

		[TestMethod()]
		public void GetNumberOfBooksByKeyTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetBookDetails(1).Count, dataService.GetNumberOfBooks(1));
		}

		[TestMethod()]
		public void GetPurchasesBetweenTest()
		{
			//DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			//DataService dataService = new DataService(dataRepository);
			//DateTime startDate = new DateTime();
			//Book book = new Book("Bk name", "Bk author", 2010);
			//BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			//Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			//dataService.AddBook(book);
			//dataService.AddBookDetails(bookDetails);
			//dataService.AddClient(client);

			//dataService.BuyBook(client, bookDetails);
			//DateTime endDate = new DateTime();

			//CollectionAssert.AreEqual(new List<Purchase> { dataService.GetPurchase(dataService.GetAllPurchases().Count() - 1) }, dataService.GetPurchasesBetween(startDate, endDate).ToList());


			throw new NotImplementedException();
		}

		[TestMethod()]
		public void GetPurchasesForBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			CollectionAssert.AreEqual(new List<Purchase> { dataService.GetPurchase(0) }, dataService.GetPurchasesForBook(dataService.GetBook(0)).ToList());
		}

		[TestMethod()]
		public void GetPurchasesForClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			CollectionAssert.AreEqual(new List<Purchase> { dataService.GetPurchase(0) }, dataService.GetPurchasesForClient(dataService.GetClient(0)).ToList());
		}

		[TestMethod()]
		public void GetBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetAllBooks().First(), dataService.GetBook(0));
		}

		[TestMethod()]
		public void GetBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetAllBookDetails().First(), dataService.GetBookDetails(0));
		}

		[TestMethod()]
		public void GetClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetAllClients().First(), dataService.GetClient(0));
		}


		[TestMethod()]
		public void GetPurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(dataRepository);

			Assert.AreEqual(dataService.GetAllPurchases().First(), dataService.GetPurchase(0));
		}
	}
}