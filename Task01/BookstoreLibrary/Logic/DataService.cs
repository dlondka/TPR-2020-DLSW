using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreLibrary
{
	class DataService : IDataService
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

		public void BuyBook(Client client, BookDetails bookDetails)
		{
			if (!(bookDetails.Count > 0))
			{
				throw new ArgumentException("There is no such book available");
			}
			bookDetails.Count--;
			DataRepository.AddPurchase(new Purchase(client, new DateTime(), bookDetails));
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
			throw new NotImplementedException();
		}

		public void DeletePurchase(Purchase purchase)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<BookDetails> GetAllBookDetails()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Book> GetAllBooks()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Client> GetAllClients()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Purchase> GetAllPurchases()
		{
			throw new NotImplementedException();
		}

		public int GetNumberOfBooks(Book book)
		{
			throw new NotImplementedException();
		}

		public int GetNumberOfBooks(int key)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Purchase> GetPurchasesBetween(DateTime firstDate, DateTime secondDate)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Purchase> GetPurchasesForBook(Book book)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Purchase> GetPurchasesForClient(Client client)
		{
			throw new NotImplementedException();
		}
	}
}
