using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Model;
using System.Linq;
using BookstoreLibrary.Filler;

namespace BookstoreLibrary.Tests
{
	[TestClass()]
	public class RandomDataFillerTests
	{
		[TestMethod()]
		public void FillTest()
		{
			RandomDataFiller filler = new RandomDataFiller();
			IDataRepository dataRepository = new DataRepository(filler.Fill(new DataContext()));

			Assert.AreEqual(5, dataRepository.GetAllClients().Count());
			Assert.AreEqual(5, dataRepository.GetAllPublishers().Count());
			Assert.AreEqual(5, dataRepository.GetAllBooks().Count());
			Assert.AreEqual(5, dataRepository.GetAllBooksDetails().Count());
			Assert.AreEqual(10, dataRepository.GetAllPurchases().Count());
		}
	}
}