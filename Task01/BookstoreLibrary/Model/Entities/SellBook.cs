using System;
using System.Collections.Generic;

namespace BookstoreLibrary
{
	public class SellBook : Purchase
	{
		public Client Client { get; set; }

		public SellBook(Client client, BookDetails bookDetails, DateTime purchaseTime, int numberOfBooks)
			: base(purchaseTime, bookDetails, numberOfBooks)
		{
			Client = client;
			if (bookDetails.Count < numberOfBooks)
			{
				throw new ArgumentException("There is not enought books");
			}
			bookDetails.Count -= numberOfBooks;
		}

		public override bool Equals(object obj)
		{
			return obj is SellBook book &&
				   PurchaseTime == book.PurchaseTime &&
				   NumberOfBooks == book.NumberOfBooks &&
				   EqualityComparer<Client>.Default.Equals(Client, book.Client) &&
				   EqualityComparer<BookDetails>.Default.Equals(BookDetails, book.BookDetails);
		}

		public override int GetHashCode()
		{
			int hashCode = 1575402700;
			hashCode = hashCode * -1521134295 + PurchaseTime.GetHashCode();
			hashCode = hashCode * -1521134295 + NumberOfBooks.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
			hashCode = hashCode * -1521134295 + EqualityComparer<BookDetails>.Default.GetHashCode(BookDetails);
			return hashCode;
		}
	}
}
