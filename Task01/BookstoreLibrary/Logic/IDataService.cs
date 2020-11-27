using System;
using System.Collections.Generic;

namespace BookstoreLibrary
{
	public interface IDataService
	{
		void AddBook(Book book);
		void AddClient(Client client);
		void AddBookDetails(BookDetails bookDetails);
		void AddPublisher(Publisher publisher);
		void BuyBook(Publisher publisher, BookDetails bookDetails, int numberOfBooks);
		void SellBook(Client client, BookDetails bookDetails, int numberOfBooks);
		IEnumerable<Client> GetAllClients();
		IEnumerable<Book> GetAllBooks();
		IEnumerable<BookDetails> GetAllBookDetails();
		IEnumerable<Publisher> GetAllPublishers();
		IEnumerable<Purchase> GetAllPurchases();
		IEnumerable<Purchase> GetPurchasesForBook(Book book);
		IEnumerable<Purchase> GetPurchasesForClient(Client client);
		IEnumerable<Purchase> GetPurchasesForPublisher(Publisher publisher);
		IEnumerable<Purchase> GetPurchasesBetween(DateTime firstDate, DateTime secondDate);
		int GetNumberOfBooks(Book book);
		int GetNumberOfBooks(int key);

		void DeleteClient(Client client);
		void DeletePublisher(Publisher publisher);
		void DeleteBook(Book book);
		void DeleteBook(int key);
		void DeleteBookDetails(BookDetails bookDetails);
		void DeletePurchase(Purchase purchase);

		Client GetClient(int index);
		Publisher GetPublisher(int index);
		Book GetBook(int key);
		BookDetails GetBookDetails(int index);
		Purchase GetPurchase(int index);
	}
}
