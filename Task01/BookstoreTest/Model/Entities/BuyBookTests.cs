using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookstoreLibrary.Filler;
using BookstoreLibrary.Model;

namespace BookstoreLibrary.ModelTests
{
	[TestClass()]
	public class BuyBookTests
	{
		[TestMethod()]
		public void BuyBookTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			int numberOfBooksBeforePurchase = repository.GetBookCount(repository.GetBook(0));
			new BuyBook(repository.GetPublisher(0), repository.GetBookDetails(0), new DateTime(), 12);
			Assert.AreEqual(numberOfBooksBeforePurchase + 12, repository.GetBookDetails(0).Count);
		}

		[TestMethod()]
		public void EqualsTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			BuyBook buyBookA = new BuyBook(repository.GetPublisher(0), repository.GetBookDetails(0), new DateTime(), 12);
			BuyBook buyBookB = new BuyBook(repository.GetPublisher(0), repository.GetBookDetails(0), new DateTime(), 12);
			BuyBook buyBookC = new BuyBook(repository.GetPublisher(1), repository.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(buyBookA, buyBookB);
			Assert.AreNotEqual(buyBookA, buyBookC);
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			BuyBook buyBookA = new BuyBook(repository.GetPublisher(0), repository.GetBookDetails(0), new DateTime(), 12);
			BuyBook buyBookB = new BuyBook(repository.GetPublisher(0), repository.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(buyBookA.GetHashCode(), buyBookB.GetHashCode());
		}
	}
}