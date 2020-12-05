using System;
using System.Collections.Generic;

namespace BookstoreLibrary.Model
{
	public class BuyBook : Purchase
	{
		public Publisher Publisher { get; set; }

		public BuyBook(Publisher publisher, BookDetails bookDetails, DateTime purchaseTime, int numberOfBooks)
			: base(purchaseTime, bookDetails, numberOfBooks)
		{
			Publisher = publisher;
			bookDetails.Count += numberOfBooks;
		}

		public override bool Equals(object obj)
		{
			return obj is BuyBook book &&
				   PurchaseTime == book.PurchaseTime &&
				   NumberOfBooks == book.NumberOfBooks &&
				   EqualityComparer<Publisher>.Default.Equals(Publisher, book.Publisher) &&
				   EqualityComparer<BookDetails>.Default.Equals(BookDetails, book.BookDetails);
		}

		public override int GetHashCode()
		{
			int hashCode = -125248555;
			hashCode = hashCode * -1521134295 + PurchaseTime.GetHashCode();
			hashCode = hashCode * -1521134295 + NumberOfBooks.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<Publisher>.Default.GetHashCode(Publisher);
			hashCode = hashCode * -1521134295 + EqualityComparer<BookDetails>.Default.GetHashCode(BookDetails);
			return hashCode;
		}
	}
}
