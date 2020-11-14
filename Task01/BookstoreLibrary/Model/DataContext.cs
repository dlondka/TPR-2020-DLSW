using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookstoreLibrary
{
    public class DataContext
    {
        public List<Client> Clients = new List<Client>();
        public Dictionary<int, Book> Books = new Dictionary<int, Book>();
        public ObservableCollection<Purchase> Purchases = new ObservableCollection<Purchase>();
        public ObservableCollection<BookDetails> BooksDetails = new ObservableCollection<BookDetails>();
    }
}