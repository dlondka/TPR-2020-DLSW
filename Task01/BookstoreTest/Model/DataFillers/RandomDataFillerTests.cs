using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			Assert.AreEqual(5, dataRepository.GetAllBooks().Count());
			Assert.AreEqual(5, dataRepository.GetAllBooksDetails().Count());
			Assert.AreEqual(5, dataRepository.GetAllPurchases().Count());
		}
	}
}