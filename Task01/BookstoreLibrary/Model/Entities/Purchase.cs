using System;

namespace BookstoreLibrary.Model
{
	public abstract class Purchase
	{
		public DateTime PurchaseTime { get; set; }
		public BookDetails BookDetails { get; set; }
		public int NumberOfBooks { get; set; }

		public Purchase(DateTime purchaseTime, BookDetails bookDetails, int numberOfBooks)
		{
			PurchaseTime = purchaseTime;
			BookDetails = bookDetails;
			NumberOfBooks = numberOfBooks;
		}
	}
}
