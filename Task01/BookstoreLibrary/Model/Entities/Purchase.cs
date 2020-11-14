using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreLibrary.Model.Entities
{
	public class Purchase
	{
		Client Client { get; set; }
		public DateTime PurchaseTime { get; set; }
		public BookDetails BookDetails { get; set; }

		public Purchase(Client client, DateTime purchaseTime, BookDetails bookDetails)
		{
			Client = client;
			PurchaseTime = purchaseTime;
			BookDetails = bookDetails;
		}

		public override bool Equals(object obj)
		{
			return obj is Purchase purchase &&
				   EqualityComparer<Client>.Default.Equals(Client, purchase.Client) &&
				   PurchaseTime == purchase.PurchaseTime &&
				   EqualityComparer<BookDetails>.Default.Equals(BookDetails, purchase.BookDetails);
		}

		public override int GetHashCode()
		{
			int hashCode = -1512294898;
			hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(Client);
			hashCode = hashCode * -1521134295 + PurchaseTime.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<BookDetails>.Default.GetHashCode(BookDetails);
			return hashCode;
		}

		public override string ToString()
		{
			return $"Purchase:\n{PurchaseTime}\n{Client}{BookDetails}-----";
		}
	}
}
