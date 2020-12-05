using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using BookstoreLibrary.Model;
using BookstoreLibrary.Logic;


namespace BookstoreLibrary.Tests
{
	[TestClass()]
	public class DataServiceTests
	{
		[TestMethod()]
		public void AddBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);

			Assert.AreEqual(dataService.GetAllBooks().Count(), 0);
			dataService.AddBook(book);
			Assert.AreEqual(dataService.GetAllBooks().Count(), 1);
		}

		[TestMethod()]
		public void AddBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");

			Assert.AreEqual(dataService.GetAllBookDetails().Count(), 0);
			dataService.AddBookDetails(bookDetails);
			Assert.AreEqual(dataService.GetAllBookDetails().Count(), 1);
		}

		[TestMethod()]
		public void AddClientTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");

			Assert.AreEqual(dataService.GetAllClients().Count(), 0);
			dataService.AddClient(client);
			Assert.AreEqual(dataService.GetAllClients().Count(), 1);
		}

		[TestMethod()]
		public void SellBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(dataService.GetNumberOfBooks(book), 33);
			dataService.SellBook(client, bookDetails, 10);
			Assert.AreEqual(dataService.GetNumberOfBooks(book), 23);
			Assert.IsTrue(dataService.GetPurchasesForClient(client).First().BookDetails.Equals(bookDetails));
		}

		[TestMethod()]
		public void DeleteBookByBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			dataService.AddBook(book);

			Assert.AreEqual(1, dataService.GetAllBooks().Count());
			dataService.DeleteBook(dataService.GetAllBooks().First());
			Assert.AreEqual(0, dataService.GetAllBooks().Count());

		}

		[TestMethod()]
		public void DeleteBookByKeyTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			dataService.AddBook(book);

			Assert.AreEqual(1, dataService.GetAllBooks().Count());
			dataService.DeleteBook(0);
			Assert.AreEqual(0, dataService.GetAllBooks().Count());
		}

		[TestMethod()]
		public void DeleteBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(1, dataService.GetAllBookDetails().Count());
			dataService.DeleteBookDetails(dataService.GetBookDetails(0));
			Assert.AreEqual(0, dataService.GetAllBookDetails().Count());
		}

		[TestMethod()]
		public void DeleteClientTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataService.AddClient(client);

			Assert.AreEqual(1, dataService.GetAllClients().Count());
			dataService.DeleteClient(dataService.GetClient(0));
			Assert.AreEqual(0, dataService.GetAllClients().Count());
		}

		[TestMethod()]
		public void DeletePurchaseTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Publisher publisher = new Publisher("Publisher1", "111111111");
			dataService.BuyBook(publisher, bookDetails, 112);

			Assert.AreEqual(1, dataService.GetAllPurchases().Count());
			dataService.DeletePurchase(dataService.GetPurchase(0));
			Assert.AreEqual(0, dataService.GetAllPurchases().Count());
		}

		[TestMethod()]
		public void GetAllBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			dataService.AddBookDetails(new BookDetails(new Book("Something Fishy", "Wodehouse", 1957), new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It."));
			dataService.AddBookDetails(new BookDetails(new Book("Pet Sematary", "King", 1983), new decimal(32.99), new decimal(0.05), 18, "Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1986, and adapted into two films: one in 1989 and another in 2019. In November 2013, PS Publishing released Pet Sematary in a limited 30th-anniversary edition."));
			dataService.AddBookDetails(new BookDetails(new Book("Harry Potter and the Half-Blook Prince", "Rowling", 2005), new decimal(25.99), new decimal(0.05), 54, "Harry Potter and the Half-Blood Prince is a fantasy novel written by British author J.K. Rowling and the sixth and penultimate novel in the Harry Potter series."));
			dataService.AddBookDetails(new BookDetails(new Book("Marley & Me", "Grogan", 2005), new decimal(15.99), new decimal(0.05), 35, "Marley & Me: Life and Love with the World's Worst Dog is an autobiographical book by journalist John Grogan, published in 2005, about the 13 years he and his family spent with their yellow Labrador Retriever, Marley."));
			dataService.AddBookDetails(new BookDetails(new Book("Feast", "Masterton", 1988), new decimal(30.99), new decimal(0.05), 23, "The little town of Allen's Corner in rural Connecticut hid a secret. A terrible, unimaginable secret. A secret that only the children knew. It fed on their youth, ate away at their innocence, and consumed their very souls with a twisted hunger that could never be revealed - nor ever satisfied."));

			Assert.AreEqual(5, dataService.GetAllBookDetails().Count());
			Assert.IsInstanceOfType(dataService.GetAllBookDetails(), typeof(IEnumerable<BookDetails>));
		}

		[TestMethod()]
		public void GetAllBooksTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			dataService.AddBook(new Book("Something Fishy", "Wodehouse", 1957));
			dataService.AddBook(new Book("Pet Sematary", "King", 1983));
			dataService.AddBook(new Book("Harry Potter and the Half-Blook Prince", "Rowling", 2005));
			dataService.AddBook(new Book("Marley & Me", "Grogan", 2005));
			dataService.AddBook(new Book("Feast", "Masterton", 1988));

			Assert.AreEqual(5, dataService.GetAllBooks().Count());
			Assert.IsInstanceOfType(dataService.GetAllBooks(), typeof(IEnumerable<Book>));
		}

		[TestMethod()]
		public void GetAllClientsTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			dataService.AddClient(new Client("Ellie", "Doe", "21151112115", "111112115"));
			dataService.AddClient(new Client("Luis", "Snow", "21152222115", "222222115"));
			dataService.AddClient(new Client("Rachel", "Sanchez", "21153332115", "333332115"));
			dataService.AddClient(new Client("Jud", "Smith", "21154442115", "444442115"));
			dataService.AddClient(new Client("Gage", "Butler", "21155552115", "555552115"));

			Assert.AreEqual(5, dataService.GetAllClients().Count());
			Assert.IsInstanceOfType(dataService.GetAllClients(), typeof(IEnumerable<Client>));
		}

		[TestMethod()]
		public void GetAllPurchasesTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			dataService.AddBookDetails(new BookDetails(new Book("Something Fishy", "Wodehouse", 1957), new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It."));
			dataService.AddBookDetails(new BookDetails(new Book("Pet Sematary", "King", 1983), new decimal(32.99), new decimal(0.05), 18, "Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1986, and adapted into two films: one in 1989 and another in 2019. In November 2013, PS Publishing released Pet Sematary in a limited 30th-anniversary edition."));
			dataService.AddBookDetails(new BookDetails(new Book("Harry Potter and the Half-Blook Prince", "Rowling", 2005), new decimal(25.99), new decimal(0.05), 54, "Harry Potter and the Half-Blood Prince is a fantasy novel written by British author J.K. Rowling and the sixth and penultimate novel in the Harry Potter series."));
			dataService.AddBookDetails(new BookDetails(new Book("Marley & Me", "Grogan", 2005), new decimal(15.99), new decimal(0.05), 35, "Marley & Me: Life and Love with the World's Worst Dog is an autobiographical book by journalist John Grogan, published in 2005, about the 13 years he and his family spent with their yellow Labrador Retriever, Marley."));
			dataService.AddBookDetails(new BookDetails(new Book("Feast", "Masterton", 1988), new decimal(30.99), new decimal(0.05), 23, "The little town of Allen's Corner in rural Connecticut hid a secret. A terrible, unimaginable secret. A secret that only the children knew. It fed on their youth, ate away at their innocence, and consumed their very souls with a twisted hunger that could never be revealed - nor ever satisfied."));

			dataService.BuyBook(new Publisher("Publisher1", "111111111"), dataService.GetBookDetails(0), 112);
			dataService.BuyBook(new Publisher("Publisher2", "222222222"), dataService.GetBookDetails(1), 113);
			dataService.BuyBook(new Publisher("Publisher3", "333333333"), dataService.GetBookDetails(2), 114);
			dataService.BuyBook(new Publisher("Publisher4", "444444444"), dataService.GetBookDetails(3), 115);
			dataService.BuyBook(new Publisher("Publisher5", "555555555"), dataService.GetBookDetails(4), 116);

			Assert.AreEqual(5, dataService.GetAllPurchases().Count());
			Assert.IsInstanceOfType(dataService.GetAllPurchases(), typeof(IEnumerable<Purchase>));
		}

		[TestMethod()]
		public void GetNumberOfBooksByBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(dataService.GetBookDetails(0).Count, dataService.GetNumberOfBooks(dataService.GetBookDetails(0).Book));
		}

		[TestMethod()]
		public void GetNumberOfBooksByKeyTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(dataService.GetBookDetails(0).Count, dataService.GetNumberOfBooks(dataService.GetBookDetails(0).Book));
		}

		[TestMethod()]
		public void GetPurchasesBetweenTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			dataService.AddBookDetails(new BookDetails(new Book("Something Fishy", "Wodehouse", 1957), new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It."));
			dataService.AddBookDetails(new BookDetails(new Book("Pet Sematary", "King", 1983), new decimal(32.99), new decimal(0.05), 18, "Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1986, and adapted into two films: one in 1989 and another in 2019. In November 2013, PS Publishing released Pet Sematary in a limited 30th-anniversary edition."));
			dataService.AddBookDetails(new BookDetails(new Book("Harry Potter and the Half-Blook Prince", "Rowling", 2005), new decimal(25.99), new decimal(0.05), 54, "Harry Potter and the Half-Blood Prince is a fantasy novel written by British author J.K. Rowling and the sixth and penultimate novel in the Harry Potter series."));
			dataService.AddBookDetails(new BookDetails(new Book("Marley & Me", "Grogan", 2005), new decimal(15.99), new decimal(0.05), 35, "Marley & Me: Life and Love with the World's Worst Dog is an autobiographical book by journalist John Grogan, published in 2005, about the 13 years he and his family spent with their yellow Labrador Retriever, Marley."));
			dataService.AddBookDetails(new BookDetails(new Book("Feast", "Masterton", 1988), new decimal(30.99), new decimal(0.05), 23, "The little town of Allen's Corner in rural Connecticut hid a secret. A terrible, unimaginable secret. A secret that only the children knew. It fed on their youth, ate away at their innocence, and consumed their very souls with a twisted hunger that could never be revealed - nor ever satisfied."));

			dataService.BuyBook(new Publisher("Publisher1", "111111111"), dataService.GetBookDetails(0), 112);
			dataService.BuyBook(new Publisher("Publisher2", "222222222"), dataService.GetBookDetails(1), 113);
			dataService.BuyBook(new Publisher("Publisher3", "333333333"), dataService.GetBookDetails(2), 114);
			dataService.BuyBook(new Publisher("Publisher4", "444444444"), dataService.GetBookDetails(3), 115);
			dataService.BuyBook(new Publisher("Publisher5", "555555555"), dataService.GetBookDetails(4), 116);
			DateTime startDate = new DateTime(2015, 1, 1, 0, 0, 0);
			DateTime endDate = new DateTime(2018, 1, 1, 0, 0, 0);

			for (int i = 0; i < dataService.GetAllPurchases().Count(); i++)
			{
				if (dataService.GetPurchase(i).PurchaseTime >= startDate && dataService.GetPurchase(i).PurchaseTime <= endDate)
				{
					Assert.IsTrue(dataService.GetPurchasesBetween(startDate, endDate).Contains(dataService.GetPurchase(i)));
				}
				else
				{
					Assert.IsFalse(dataService.GetPurchasesBetween(startDate, endDate).Contains(dataService.GetPurchase(i)));
				}

			}
		}

		[TestMethod()]
		public void GetPurchasesForBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Something Fishy", "Wodehouse", 1957);
			BookDetails bookDetails = new BookDetails(book, new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It.");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);
			dataService.BuyBook(new Publisher("Publisher1", "111111111"), dataService.GetBookDetails(0), 112);
			dataService.SellBook(client, bookDetails, 10);

			CollectionAssert.AreEqual(new List<Purchase> { dataService.GetPurchase(0), dataService.GetPurchase(1) }, dataService.GetPurchasesForBook(dataService.GetBook(0)).ToList());
		}

		[TestMethod()]
		public void GetPurchasesForClientTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Something Fishy", "Wodehouse", 1957);
			BookDetails bookDetails = new BookDetails(book, new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It.");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataService.AddClient(client);
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);
			dataService.SellBook(client, bookDetails, 10);

			CollectionAssert.AreEqual(new List<Purchase> { dataService.GetPurchase(0) }, dataService.GetPurchasesForClient(dataService.GetClient(0)).ToList());
		}

		[TestMethod()]
		public void GetBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Something Fishy", "Wodehouse", 1957);
			dataService.AddBook(book);

			Assert.AreEqual(dataService.GetAllBooks().First(), dataService.GetBook(0));
		}

		[TestMethod()]
		public void GetBookDetailsTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Something Fishy", "Wodehouse", 1957);
			BookDetails bookDetails = new BookDetails(book, new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It.");
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(dataService.GetAllBookDetails().First(), dataService.GetBookDetails(0));
		}

		[TestMethod()]
		public void GetClientTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataService.AddClient(client);

			Assert.AreEqual(dataService.GetAllClients().First(), dataService.GetClient(0));
		}


		[TestMethod()]
		public void GetPurchaseTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Something Fishy", "Wodehouse", 1957);
			BookDetails bookDetails = new BookDetails(book, new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It.");
			Client client = new Client("ClName", "ClLastName", "99101023432", "321654987");
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);
			dataService.BuyBook(new Publisher("Publisher1", "111111111"), dataService.GetBookDetails(0), 112);

			Assert.AreEqual(dataService.GetAllPurchases().First(), dataService.GetPurchase(0));
		}

		[TestMethod()]
		public void AddPublisherTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Publisher publisher = new Publisher("Name", "2115");

			Assert.AreEqual(dataService.GetAllPublishers().Count(), 0);
			dataService.AddPublisher(publisher);
			Assert.AreEqual(dataService.GetAllPublishers().Count(), 1);
		}

		[TestMethod()]
		public void BuyBookTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Bk name", "Bk author", 2010);
			BookDetails bookDetails = new BookDetails(book, new decimal(24.99), new decimal(0.05), 33, "Book that contains words");
			Publisher publisher = new Publisher("Name", "2115");
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);

			Assert.AreEqual(dataService.GetNumberOfBooks(book), 33);
			dataService.BuyBook(publisher, bookDetails, 25);
			Assert.AreEqual(dataService.GetNumberOfBooks(book), 58);
		}

		[TestMethod()]
		public void DeletePublisherTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Publisher publisher = new Publisher("Name", "2115");
			dataService.AddPublisher(publisher);

			Assert.AreEqual(1, dataService.GetAllPublishers().Count());
			dataService.DeletePublisher(dataService.GetPublisher(0));
			Assert.AreEqual(0, dataService.GetAllPublishers().Count());
		}

		[TestMethod()]
		public void GetAllPublishersTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Publisher publisher = new Publisher("Name", "2115");
			dataService.AddPublisher(publisher);

			Assert.AreEqual(1, dataService.GetAllPublishers().Count());
			Assert.IsInstanceOfType(dataService.GetAllPublishers(), typeof(IEnumerable<Publisher>));
		}

		[TestMethod()]
		public void GetPublisherTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Publisher publisher = new Publisher("Name", "2115");
			dataService.AddPublisher(publisher);

			Assert.AreEqual(dataService.GetAllPublishers().First(), dataService.GetPublisher(0));
		}

		[TestMethod()]
		public void GetPurchasesForPublisherTest()
		{
			DataRepository dataRepository = new DataRepository();
			DataService dataService = new DataService(dataRepository);
			Book book = new Book("Something Fishy", "Wodehouse", 1957);
			BookDetails bookDetails = new BookDetails(book, new decimal(12.99), new decimal(0.05), 12, "Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It.");
			Publisher publisher = new Publisher("Publisher1", "111111111");
			dataService.AddPublisher(publisher);
			dataService.AddBook(book);
			dataService.AddBookDetails(bookDetails);
			dataService.BuyBook(publisher, dataService.GetBookDetails(0), 112);

			CollectionAssert.AreEqual(new List<Purchase> { dataService.GetPurchase(0) }, dataService.GetPurchasesForPublisher(dataService.GetPublisher(0)).ToList());
		}
	}
}