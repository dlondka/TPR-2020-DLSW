using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreLibrary.Logic
{
	public class DataService : IDataService
	{
		IDataRepository DataRepository;

		public DataService(DataRepository dataRepository)
		{
			DataRepository = dataRepository;
		}

		public void AddBook(Book book)
		{
			DataRepository.AddBook(book);
		}

		public void AddBookDetails(BookDetails bookDetails)
		{
			DataRepository.AddBookDetails(bookDetails);
		}

		public void AddClient(Client client)
		{
			DataRepository.AddClient(client);
		}

		public void AddPublisher(Publisher publisher)
		{
			DataRepository.AddPublisher(publisher);
		}

		public void BuyBook(Publisher publisher, BookDetails bookDetails, int numberOfBooks)
		{
			DataRepository.AddPurchase(new BuyBook(publisher, bookDetails, new DateTime(), numberOfBooks));
		}

		public void SellBook(Client client, BookDetails bookDetails, int numberOfBooks)
		{
			DataRepository.AddPurchase(new SellBook(client, bookDetails, new DateTime(), numberOfBooks));
		}

		public void DeleteBook(Book book)
		{
			DataRepository.DeleteBook(DataRepository.FindBook(book));
		}

		public void DeleteBook(int key)
		{
			DataRepository.DeleteBook(key);
		}

		public void DeleteBookDetails(BookDetails bookDetails)
		{
			DataRepository.DeleteBookDetails(bookDetails);
		}

		public void DeleteClient(Client client)
		{
			DataRepository.DeleteClient(client);
		}

		public void DeletePublisher(Publisher publisher)
		{
			DataRepository.DeletePublisher(publisher);
		}

		public void DeletePurchase(Purchase purchase)
		{
			DataRepository.DeletePurchase(purchase);
		}

		public IEnumerable<BookDetails> GetAllBookDetails()
		{
			return DataRepository.GetAllBooksDetails();
		}

		public IEnumerable<Book> GetAllBooks()
		{
			return DataRepository.GetAllBooks();
		}

		public IEnumerable<Client> GetAllClients()
		{
			return DataRepository.GetAllClients();
		}

		public IEnumerable<Publisher> GetAllPublishers()
		{
			return DataRepository.GetAllPublishers();
		}

		public IEnumerable<Purchase> GetAllPurchases()
		{
			return DataRepository.GetAllPurchases();
		}

		public Book GetBook(int key)
		{
			return DataRepository.GetBook(key);
		}

		public BookDetails GetBookDetails(int index)
		{
			return DataRepository.GetBookDetails(index);
		}

		public Client GetClient(int index)
		{
			return DataRepository.GetClient(index);
		}

		public int GetNumberOfBooks(Book book)
		{
			return DataRepository.GetBookCount(book);
		}

		public int GetNumberOfBooks(int key)
		{
			return DataRepository.GetBookCount(DataRepository.GetBook(key));
		}

		public Publisher GetPublisher(int index)
		{
			return DataRepository.GetPublisher(index);
		}

		public Purchase GetPurchase(int index)
		{
			return DataRepository.GetPurchase(index);
		}

		public IEnumerable<Purchase> GetPurchasesBetween(DateTime firstDate, DateTime secondDate)
		{
			return DataRepository.GetAllPurchases().Where(p => (p.PurchaseTime.CompareTo(firstDate) == 1) && (p.PurchaseTime.CompareTo(secondDate) == -1));
		}

		public IEnumerable<Purchase> GetPurchasesForBook(Book book)
		{
			return DataRepository.GetAllPurchases().Where(p => (p.BookDetails.Book.Equals(book)));
		}

		public IEnumerable<Purchase> GetPurchasesForClient(Client client)
		{
			return DataRepository.GetAllPurchases().Where(p => typeof(SellBook).IsInstanceOfType(p) && ((SellBook)p).Client.Equals(client));
		}

		public IEnumerable<Purchase> GetPurchasesForPublisher(Publisher publisher)
		{
			return DataRepository.GetAllPurchases().Where(p => typeof(BuyBook).IsInstanceOfType(p) && ((BuyBook)p).Publisher.Equals(publisher));
		}
	}
}
