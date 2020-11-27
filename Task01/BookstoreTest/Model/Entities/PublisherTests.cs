using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreLibrary.Logic;

namespace BookstoreLibrary.Model.Tests
{
	[TestClass()]
	public class PublisherTests
	{
		[TestMethod()]
		public void ToStringTest()
		{
			DataRepository repo = new DataRepository(new ConstantDataFiller());
			DataService dataService = new DataService(repo);

			Assert.AreEqual("Publisher: Publisher1, phone numer: 111111111\n", dataService.GetPublisher(0).ToString());
		}
	}
}