using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BookstoreLibrary.Logic;

namespace BookstoreLibrary.Model.Tests
{
	[TestClass()]
	public class BuyBookTests
	{
		[TestMethod()]
		public void BuyBookTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);

			int numberOfBooksBeforePurchase = dataService.GetNumberOfBooks(dataService.GetBook(0));
			new BuyBook(dataService.GetPublisher(0), dataService.GetBookDetails(0), new DateTime(), 12);
			Assert.AreEqual(numberOfBooksBeforePurchase + 12, dataService.GetBookDetails(0).Count);
		}

		[TestMethod()]
		public void EqualsTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);
			
			BuyBook buyBookA = new BuyBook(dataService.GetPublisher(0), dataService.GetBookDetails(0), new DateTime(), 12);
			BuyBook buyBookB = new BuyBook(dataService.GetPublisher(0), dataService.GetBookDetails(0), new DateTime(), 12);
			BuyBook buyBookC = new BuyBook(dataService.GetPublisher(1), dataService.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(buyBookA, buyBookB);
			Assert.AreNotEqual(buyBookA, buyBookC);
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);

			BuyBook buyBookA = new BuyBook(dataService.GetPublisher(0), dataService.GetBookDetails(0), new DateTime(), 12);
			BuyBook buyBookB = new BuyBook(dataService.GetPublisher(0), dataService.GetBookDetails(0), new DateTime(), 12);

			Assert.AreEqual(buyBookA.GetHashCode(), buyBookB.GetHashCode());
		}
	}
}