﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreLibrary
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
			DataRepository.DeleteClient(client);
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

		public IEnumerable<Purchase> GetAllPurchases()
		{
			return DataRepository.GetAllPurchases();
		}

		public int GetNumberOfBooks(Book book)
		{
			return DataRepository.GetBookCount(book);
		}

		public int GetNumberOfBooks(int key)
		{
			return DataRepository.GetBookCount(DataRepository.GetBook(key));
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
			return DataRepository.GetAllPurchases().Where(p => (p.Client.Equals(client)));
		}
	}
}
