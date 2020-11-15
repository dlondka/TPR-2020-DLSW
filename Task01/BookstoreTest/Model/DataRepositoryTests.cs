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
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			dataRepository.AddBook(book);
			Assert.AreEqual(5, dataRepository.FindBook(book));
			Assert.IsTrue(dataRepository.GetAllBooks().Last().Equals(book));
			Assert.ThrowsException<ArgumentException>(() => dataRepository.AddBook(book));
		}

		[TestMethod()]
		public void AddBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			dataRepository.AddBookDetails(bookDetails);
			Assert.AreEqual(dataRepository.GetAllBooksDetails().Count(), 6);
			Assert.AreEqual(dataRepository.GetBookDetails(5), bookDetails);
			Assert.ThrowsException<ArgumentException>(() => dataRepository.AddBookDetails(bookDetails));
		}

		[TestMethod()]
		public void AddClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataRepository.AddClient(client);
			Assert.AreEqual(dataRepository.GetAllClients().Count(), 6);
			Assert.AreEqual(dataRepository.GetClient(5), client);
			Assert.ThrowsException<ArgumentException>(() => dataRepository.AddClient(client));
		}

		[TestMethod()]
		public void AddPurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			Purchase purchase = new Purchase(client, new DateTime(), bookDetails);
			dataRepository.AddPurchase(purchase);

			Assert.AreEqual(dataRepository.GetAllPurchases().Count(), 6);
			Assert.AreEqual(dataRepository.GetPurchase(5), purchase);
			Assert.ThrowsException<ArgumentException>(() => dataRepository.AddPurchase(purchase));
		}

		[TestMethod()]
		public void DeleteBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteBook(dataRepository.FindBook(book)));
			Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteBook(123));
			Assert.AreEqual(dataRepository.GetAllBooks().Count(), 5);
			dataRepository.DeleteBook(4);
			Assert.AreEqual(dataRepository.GetAllBooks().Count(), 4);
		}

		[TestMethod()]
		public void DeleteBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteBookDetails(bookDetails));
			dataRepository.AddBookDetails(bookDetails);
			Assert.AreEqual(dataRepository.GetAllBooksDetails().Count(), 6);
			dataRepository.DeleteBookDetails(bookDetails);
			Assert.AreEqual(dataRepository.GetAllBooksDetails().Count(), 5);
		}

		[TestMethod()]
		public void DeleteClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.DeleteClient(client));
			dataRepository.AddClient(client);
			Assert.AreEqual(dataRepository.GetAllClients().Count(), 6);
			dataRepository.DeleteClient(client);
			Assert.AreEqual(dataRepository.GetAllClients().Count(), 5);
		}

		[TestMethod()]
		public void DeletePurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			Purchase purchase = new Purchase(client, new DateTime(), bookDetails);

			Assert.ThrowsException<ArgumentException>(() => dataRepository.DeletePurchase(purchase));
			dataRepository.AddPurchase(purchase);
			Assert.AreEqual(dataRepository.GetAllPurchases().Count(), 6);
			dataRepository.DeletePurchase(purchase);
			Assert.AreEqual(dataRepository.GetAllPurchases().Count(), 5);
		}

		[TestMethod()]
		public void FindBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			Assert.ThrowsException<ArgumentException>(() => dataRepository.FindBook(book));
			dataRepository.AddBook(book);
			Assert.AreEqual(5, dataRepository.FindBook(book));
		}

		[TestMethod()]
		public void FindBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.FindBookDetails(bookDetails));
			dataRepository.AddBookDetails(bookDetails);
			Assert.AreEqual(5, dataRepository.FindBookDetails(bookDetails));
		}

		[TestMethod()]
		public void FindClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.FindClient(client));
			dataRepository.AddClient(client);
			Assert.AreEqual(5, dataRepository.FindClient(client));
		}

		[TestMethod()]
		public void FindPurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			Purchase purchase = new Purchase(client, new DateTime(), bookDetails);

			Assert.ThrowsException<ArgumentException>(() => dataRepository.FindPurchase(purchase));
			dataRepository.AddPurchase(purchase);
			Assert.AreEqual(5, dataRepository.FindPurchase(purchase));
		}

		[TestMethod()]
		public void GetAllBooksTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Assert.AreEqual(5, dataRepository.GetAllBooks().Count());
			Assert.IsInstanceOfType(dataRepository.GetAllBooks(), typeof(IEnumerable<Book>));
		}

		[TestMethod()]
		public void GetAllBooksDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Assert.AreEqual(5, dataRepository.GetAllBooksDetails().Count());
			Assert.IsInstanceOfType(dataRepository.GetAllBooksDetails(), typeof(IEnumerable<BookDetails>));
		}

		[TestMethod()]
		public void GetAllClientsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Assert.AreEqual(5, dataRepository.GetAllClients().Count());
			Assert.IsInstanceOfType(dataRepository.GetAllClients(), typeof(IEnumerable<Client>));
		}

		[TestMethod()]
		public void GetAllPurchasesTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Assert.AreEqual(5, dataRepository.GetAllPurchases().Count());
			Assert.IsInstanceOfType(dataRepository.GetAllPurchases(), typeof(IEnumerable<Purchase>));
		}

		[TestMethod()]
		public void GetBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);

			Assert.ThrowsException<ArgumentException>(() => dataRepository.GetBook(5));
			dataRepository.AddBook(book);
			Assert.AreEqual(dataRepository.GetBook(5), book);
		}

		[TestMethod()]
		public void GetBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.GetBookDetails(5));
			dataRepository.AddBookDetails(bookDetails);
			Assert.AreEqual(dataRepository.GetBookDetails(5), bookDetails);
		}

		[TestMethod()]
		public void GetClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.GetClient(5));
			dataRepository.AddClient(client);
			Assert.AreEqual(dataRepository.GetClient(5), client);
		}

		[TestMethod()]
		public void GetPurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			Purchase purchase = new Purchase(client, new DateTime(), bookDetails);

			Assert.ThrowsException<ArgumentException>(() => dataRepository.GetPurchase(5));
			dataRepository.AddPurchase(purchase);
			Assert.AreEqual(dataRepository.GetPurchase(5), purchase);
		}

		[TestMethod()]
		public void UpdateBookTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);

			Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateBook(20, book));
			Assert.AreNotEqual(dataRepository.GetBook(4), book);
			dataRepository.UpdateBook(4, book);
			Assert.AreEqual(dataRepository.GetBook(4), book);
		}

		[TestMethod()]
		public void UpdateBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateBookDetails(bookDetails, 22));
			Assert.AreNotEqual(dataRepository.GetBookDetails(4), bookDetails);
			dataRepository.UpdateBookDetails(bookDetails, 4);
			Assert.AreEqual(dataRepository.GetBookDetails(4), bookDetails);
		}

		[TestMethod()]
		public void UpdateClientTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdateClient(client, 22));
			Assert.AreNotEqual(dataRepository.GetClient(4), client);
			dataRepository.UpdateClient(client, 4);
			Assert.AreEqual(dataRepository.GetClient(4), client);
		}

		[TestMethod()]
		public void UpdatePurchaseTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			Purchase purchase = new Purchase(client, new DateTime(), bookDetails);

			Assert.ThrowsException<ArgumentException>(() => dataRepository.UpdatePurchase(purchase, 33));
			Assert.AreNotEqual(dataRepository.GetPurchase(3), purchase);
			dataRepository.UpdatePurchase(purchase, 3);
			Assert.AreEqual(dataRepository.GetPurchase(3), purchase);
		}
	}
}