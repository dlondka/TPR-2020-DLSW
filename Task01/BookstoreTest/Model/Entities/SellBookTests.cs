using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookstoreLibrary.Logic;

namespace BookstoreLibrary.Model.Tests
{
	[TestClass()]
	public class SellBookTests
	{
		[TestMethod()]
		public void SellBookTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);

			int numberOfBooksBeforePurchase = dataService.GetNumberOfBooks(dataService.GetBook(0));
			new SellBook(dataService.GetClient(0), dataService.GetBookDetails(0), new DateTime(), 12);
			Assert.AreEqual(numberOfBooksBeforePurchase - 12, dataService.GetBookDetails(0).Count);
		}

		[TestMethod()]
		public void EqualsTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);

			SellBook sellBookA = new SellBook(dataService.GetClient(0), dataService.GetBookDetails(0), new DateTime(), 12);
			SellBook sellBookB = new SellBook(dataService.GetClient(0), dataService.GetBookDetails(0), new DateTime(), 12);
			SellBook sellBookC = new SellBook(dataService.GetClient(1), dataService.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(sellBookA, sellBookB);
			Assert.AreNotEqual(sellBookA, sellBookC);
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);

			SellBook sellBookA = new SellBook(dataService.GetClient(0), dataService.GetBookDetails(0), new DateTime(), 12);
			SellBook sellBookB = new SellBook(dataService.GetClient(0), dataService.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(sellBookA.GetHashCode(), sellBookB.GetHashCode());
		}
	}
}