using System;
using System.Collections.Generic;

namespace BookstoreLibrary
{
	public interface IDataService
	{
		void AddBook(Book book);
		void AddClient(Client client);
		void AddBookDetails(BookDetails bookDetails);
		Purchase BuyBook(Client client, BookDetails bookDetails);
		IEnumerable<Client> GetAllClients();
		IEnumerable<Book> GetAllBooks();
		IEnumerable<BookDetails> GetAllBookDetails();
		IEnumerable<Purchase> GetAllPurchases();
		IEnumerable<Purchase> GetPurchasesForBook(Book book);
		IEnumerable<Purchase> GetPurchasesForClient(Client client);
		IEnumerable<Purchase> GetPurchasesBetween(DateTime firstDate, DateTime secondDate);
		int GetNumberOfBooks(Book book);
		int GetNumberOfBooks(int key);

		void DeleteClient(Client client);
		void DeleteBook(Book book);
		void DeleteBook(int key);
		void DeleteBookDetails(BookDetails bookDetails);
		void DeletePurchase(Purchase purchase);
		
	}
}
