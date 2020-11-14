using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreLibrary.Model.Entities.Tests
{
	[TestClass()]
	public class PurchaseTests
	{
		Client C1 = new Client("John", "Doe", "21157772115", "606211568");
		Client C2 = new Client("Jon", "Snow", "21157772115", "606211568");
		BookDetails BD1 = new BookDetails(new Book("Harry Potter", "J.K. Rowling", 1997), new decimal(19.99), new decimal(0.05), 12, "Book about adventures of young Wizzard Harry");
		DateTime PT1 = new DateTime(2020, 10, 5, 12, 45, 12);

		[TestMethod()]
		public void PurchaseTest()
		{
			Purchase Purchase = new Purchase(C1, PT1, BD1);
			Assert.IsTrue(Purchase.Client == C1 && Purchase.PurchaseTime == PT1 && Purchase.BookDetails == BD1);
		}

		[TestMethod()]
		public void EqualsTest()
		{
			Purchase P1 = new Purchase(C1, PT1, BD1);
			Purchase P2 = new Purchase(C1, PT1, BD1);
			Purchase P3 = new Purchase(C2, PT1, BD1);

			Assert.IsTrue(P1.Equals(P2));
			Assert.IsFalse(P1.Equals(P3));
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			Purchase P1 = new Purchase(C1, PT1, BD1);
			Purchase P2 = new Purchase(C2, PT1, BD1);

			Assert.AreEqual(P1.GetHashCode(), P1.GetHashCode());
			Assert.AreNotEqual(P1.GetHashCode(), P2.GetHashCode());
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Purchase P1 = new Purchase(C1, PT1, BD1);
			Assert.AreEqual(P1.ToString(), $"Purchase:\n{P1.PurchaseTime}\n{P1.Client}{P1.BookDetails}-----");
		}
	}
}