﻿using System.Collections.Generic;

namespace BookstoreLibrary.Model
{
    public interface IDataRepository
    {
        void AddBook(Book book);
        Book GetBook(int key);
        int FindBook(Book book);
        void UpdateBook(int key, Book book);
        void DeleteBook(int key);
        IEnumerable<Book> GetAllBooks();


        void AddPublisher(Publisher publisher);
        Publisher GetPublisher(int index);
        int FindPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher, int index);
        void DeletePublisher(Publisher publisher);
        IEnumerable<Publisher> GetAllPublishers();

        void AddClient(Client client);
        Client GetClient(int index);
        int FindClient(Client client);
        void UpdateClient(Client client, int index);
        void DeleteClient(Client client);
        IEnumerable<Client> GetAllClients();

        int GetBookCount(Book book);


        void AddBookDetails(BookDetails bookDetails);
        BookDetails GetBookDetails(int index);
        int FindBookDetails(BookDetails bookDetails);
        void UpdateBookDetails(BookDetails bookDetails, int index);
        void DeleteBookDetails(BookDetails bookDetails);
        IEnumerable<BookDetails> GetAllBooksDetails();


        void AddPurchase(Purchase purchase);
        Purchase GetPurchase(int index);
        int FindPurchase(Purchase purchase);
        void UpdatePurchase(Purchase purchase, int index);
        void DeletePurchase(Purchase purchase);
        IEnumerable<Purchase> GetAllPurchases();
    }
}
