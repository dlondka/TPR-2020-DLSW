using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookstoreLibrary
{
    public class DataContext
    {
        public List<Client> Clients = new List<Client>();
        public List<Publisher> Publishers = new List<Publisher>();
        public Dictionary<int, Book> Books = new Dictionary<int, Book>();
        public ObservableCollection<Purchase> Purchases = new ObservableCollection<Purchase>();
        public ObservableCollection<BookDetails> BooksDetails = new ObservableCollection<BookDetails>();
    }
}