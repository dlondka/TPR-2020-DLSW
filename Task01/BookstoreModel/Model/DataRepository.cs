﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BookstoreLibrary.Model
{
	public class DataRepository : IDataRepository
	{
		private DataContext DataContext = new DataContext();
		private int BookKey = 0;

		public DataRepository() {}

		public DataRepository(DataContext dataContext)
        {
			DataContext = dataContext;

			if (dataContext.Books.Count > 0)
            {
				BookKey = DataContext.Books.Last().Key + 1;
			}

		}

		public void AddBook(Book book)
		{
			if (DataContext.Books.ContainsValue(book))
			{
				throw new ArgumentException("Book you are trying to add already exist");
			}
			DataContext.Books.Add(BookKey, book);
			BookKey++;
		}

		public void AddBookDetails(BookDetails bookDetails)
		{
			if (DataContext.BooksDetails.Contains(bookDetails))
			{
				throw new ArgumentException("Book details you were trying to add already exist");
			}
			DataContext.BooksDetails.Add(bookDetails);
		}

		public void AddClient(Client client)
		{
			if (DataContext.Clients.Contains(client))
			{
				throw new ArgumentException("Client you are trying to add already exists");
			}
			DataContext.Clients.Add(client);
		}

		public void AddPublisher(Publisher publisher)
		{
			if (DataContext.Publishers.Contains(publisher))
			{
				throw new ArgumentException("Publisher you are trying to add already exists");
			}
			DataContext.Publishers.Add(publisher);
		}

		public void AddPurchase(Purchase purchase)
		{
			if (DataContext.Purchases.Contains(purchase))
			{
				throw new ArgumentException("Purchase you are trying to add already exists");
			}
			DataContext.Purchases.Add(purchase);
		}

		public void DeleteBook(int key)
		{
			if (!DataContext.Books.ContainsKey(key))
			{
				throw new ArgumentException("Book with the key you used does not exist");
			}
			for (int i = 0; i < GetAllBooksDetails().Count(); i++)
			{
				if (GetBookDetails(i).Book.Equals(GetBook(key)))
				{
					DeleteBookDetails(GetBookDetails(i));
				}
			}
			DataContext.Books.Remove(key);
		}

		public void DeleteBookDetails(BookDetails bookDetails)
		{
			if (!DataContext.BooksDetails.Contains(bookDetails))
			{
				throw new ArgumentException("Book details you are trying to delete do not exist");
			}
			DataContext.BooksDetails.Remove(bookDetails);
		}

		public void DeleteClient(Client client)
		{
			if (!DataContext.Clients.Contains(client))
			{
				throw new ArgumentException("Client you are trying to remove does not exist");
			}
			DataContext.Clients.Remove(client);
		}

		public void DeletePublisher(Publisher publisher)
		{
			if (!DataContext.Publishers.Contains(publisher))
			{
				throw new ArgumentException("Publisher you are trying to remove does not exist");
			}
			DataContext.Publishers.Remove(publisher);
		}

		public void DeletePurchase(Purchase purchase)
		{
			if (!DataContext.Purchases.Contains(purchase))
			{
				throw new ArgumentException("Purchase you are trying to remove does not exist");
			}
			DataContext.Purchases.Remove(purchase);
		}

		public int FindBook(Book book)
		{
			if (!DataContext.Books.ContainsValue(book))
			{
				throw new ArgumentException("The book you were trying to find does not exist");
			}
			return DataContext.Books.FirstOrDefault(b => b.Value.Equals(book)).Key;
		}

		public int FindBookDetails(BookDetails bookDetails)
		{
			if (!DataContext.BooksDetails.Contains(bookDetails))
			{
				throw new ArgumentException("Book details you are trying to find do not exist");
			}
			return DataContext.BooksDetails.IndexOf(bookDetails);
		}

		public int FindClient(Client client)
		{
			if (!DataContext.Clients.Contains(client))
			{
				throw new ArgumentException("Client you are trying to find does not exist");
			}
			return DataContext.Clients.IndexOf(client);
		}

		public int FindPublisher(Publisher publisher)
		{
			if (!DataContext.Publishers.Contains(publisher))
			{
				throw new ArgumentException("Publisher you are trying to find does not exist");
			}
			return DataContext.Publishers.IndexOf(publisher);
		}

		public int FindPurchase(Purchase purchase)
		{
			if (!DataContext.Purchases.Contains(purchase))
			{
				throw new ArgumentException("Purchase you are trying to find does not exist");
			}
			return DataContext.Purchases.IndexOf(purchase);
		}

		public IEnumerable<Book> GetAllBooks()
		{
			return DataContext.Books.Values;
		}

		public IEnumerable<BookDetails> GetAllBooksDetails()
		{
			return DataContext.BooksDetails;
		}

		public IEnumerable<Client> GetAllClients()
		{
			return DataContext.Clients;
		}

		public IEnumerable<Publisher> GetAllPublishers()
		{
			return DataContext.Publishers;
		}

		public IEnumerable<Purchase> GetAllPurchases()
		{
			return DataContext.Purchases;
		}

		public Book GetBook(int key)
		{
			if (!DataContext.Books.ContainsKey(key))
			{
				throw new ArgumentException($"Book with the key: {key} does not exist");
			}
			return DataContext.Books[key];
		}

		public BookDetails GetBookDetails(int index)
		{
			if (!(index < DataContext.BooksDetails.Count() && index >= 0))
			{
				throw new ArgumentException("Book details you are trying to get do not exist");
			}
			return DataContext.BooksDetails[index];
		}

		public Client GetClient(int index)
		{
			if (!(index < DataContext.Clients.Count() && index >= 0))
			{
				throw new ArgumentException("Client you are trying to get does not exist");
			}
			return DataContext.Clients[index];
		}

		public Publisher GetPublisher(int index)
		{
			if (!(index < DataContext.Publishers.Count() && index >= 0))
			{
				throw new ArgumentException("The publisher you are trying to get does not exist");
			}
			return DataContext.Publishers[index];
		}

		public Purchase GetPurchase(int index)
		{
			if (!(index < DataContext.Purchases.Count() && index >= 0))
			{
				throw new ArgumentException("The purchase you are trying to get does not exist");
			}
			return DataContext.Purchases[index];
		}

		public void UpdateBook(int key, Book book)
		{
			if (!DataContext.Books.ContainsKey(key))
			{
				throw new ArgumentException("The key you used to update book does not exist");
			}
			DataContext.Books[key] = book;
		}

		public void UpdateBookDetails(BookDetails bookDetails, int index)
		{
			if (!(index <= DataContext.BooksDetails.Count() && index >= 0))
			{
				throw new ArgumentException("The book details you tried to eddit do not exist at used index");
			}
			DataContext.BooksDetails[index] = bookDetails;
		}

		public void UpdateClient(Client client, int index)
		{
			if (!(index <= DataContext.Clients.Count() && index >= 0))
			{
				throw new ArgumentException("The client ");
			}
			DataContext.Clients[index] = client;
		}

		public void UpdatePublisher(Publisher publisher, int index)
		{
			if (!(index <= DataContext.Publishers.Count() && index >= 0))
			{
				throw new ArgumentException("Publisher with index you tried to update does not exist");
			}
			DataContext.Publishers[index] = publisher;
		}

		public void UpdatePurchase(Purchase purchase, int index)
		{
			if (!(index <= DataContext.Purchases.Count() && index >= 0))
			{
				throw new ArgumentException("Purchase with index you tried to update does not exist");
			}
			DataContext.Purchases[index] = purchase;
		}

		public int GetBookCount(Book book)
		{
			for (int i = 0; i < DataContext.BooksDetails.Count; i++)
			{
				if (DataContext.BooksDetails[i].Book.Equals(book))
                {
					return DataContext.BooksDetails[i].Count;
                }
			}
			throw new ArgumentException("Book you are looking for does not exist");
		}
	}
}
