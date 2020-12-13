using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookstoreLibrary.Filler;
using BookstoreLibrary.Model;

namespace BookstoreLibrary.ModelTests
{
	[TestClass()]
	public class SellBookTests
	{
		[TestMethod()]
		public void SellBookTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			int numberOfBooksBeforePurchase = repository.GetBookCount(repository.GetBook(0));
			new SellBook(repository.GetClient(0), repository.GetBookDetails(0), new DateTime(), 12);
			Assert.AreEqual(numberOfBooksBeforePurchase - 12, repository.GetBookDetails(0).Count);
		}

		[TestMethod()]
		public void EqualsTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			SellBook sellBookA = new SellBook(repository.GetClient(0), repository.GetBookDetails(0), new DateTime(), 12);
			SellBook sellBookB = new SellBook(repository.GetClient(0), repository.GetBookDetails(0), new DateTime(), 12);
			SellBook sellBookC = new SellBook(repository.GetClient(1), repository.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(sellBookA, sellBookB);
			Assert.AreNotEqual(sellBookA, sellBookC);
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			SellBook sellBookA = new SellBook(repository.GetClient(0), repository.GetBookDetails(0), new DateTime(), 12);
			SellBook sellBookB = new SellBook(repository.GetClient(0), repository.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(sellBookA.GetHashCode(), sellBookB.GetHashCode());
		}
	}
}