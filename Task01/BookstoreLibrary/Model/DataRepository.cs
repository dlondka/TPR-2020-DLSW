using System;
using System.Collections.Generic;

namespace BookstoreLibrary
{
    class DataRepository : IDataRepository
    {
        private DataContext DataContext = new DataContext();

        private int BookKey = 0;

        public DataRepository() { }

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

        public void AddPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int key)
        {
            throw new NotImplementedException();
        }

        public void DeleteBookDetails(BookDetails bookDetails)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void DeletePurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public int FindBook(Book book)
        {
            throw new NotImplementedException();
        }

        public int FindBookDetails(BookDetails bookDetails)
        {
            throw new NotImplementedException();
        }

        public int FindClient(Client client)
        {
            throw new NotImplementedException();
        }

        public int FindPurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookDetails> GetAllBooksDetails()
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

        public Book GetBook(int key)
        {
            throw new NotImplementedException();
        }

        public BookDetails GetBookDetails(int index)
        {
            throw new NotImplementedException();
        }

        public Client GetClient(int index)
        {
            throw new NotImplementedException();
        }

        public Book GetPurchase(int index)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(int key, Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBookDetails(BookDetails bookDetails, int index)
        {
            throw new NotImplementedException();
        }

        public void UpdateClient(Client client, int index)
        {
            throw new NotImplementedException();
        }

        public void UpdatePurchase(Purchase purchase, int index)
        {
            throw new NotImplementedException();
        }
    }
}
