using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookstoreLibrary.Model
{
    public class DataContext
    {
        public List<Entities.Client> Clients = new List<Entities.Client>();
        public Dictionary<int, Entities.Book> Books = new Dictionary<int, Entities.Book>();
        public ObservableCollection<Entities.Purchase> Purchases = new ObservableCollection<Entities.Purchase>();
        public ObservableCollection<Entities.BookDetails> BooksDetails = new ObservableCollection<Entities.BookDetails>();
    }
}