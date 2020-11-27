using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Model;
using System.Linq;

namespace BookstoreLibrary.Tests
{
	[TestClass()]
	public class RandomDataFillerTests
	{
		[TestMethod()]
		public void FillTest()
		{
			DataRepository dataRepository = new DataRepository(new RandomDataFiller());

			Assert.AreEqual(5, dataRepository.GetAllClients().Count());
			Assert.AreEqual(5, dataRepository.GetAllPublishers().Count());
			Assert.AreEqual(5, dataRepository.GetAllBooks().Count());
			Assert.AreEqual(5, dataRepository.GetAllBooksDetails().Count());
			Assert.AreEqual(10, dataRepository.GetAllPurchases().Count());
		}
	}
}