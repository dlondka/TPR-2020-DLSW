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
	public class ConstantDataFillerTests
	{
		[TestMethod()]
		public void FillTest()
		{
			DataRepository dataRepository = new DataRepository(new ConstantDataFiller());

			Assert.AreEqual(5, dataRepository.GetAllClients().Count());
			Assert.AreEqual("Client: Ellie Doe, PESEL: 21151112115, phone number: 111112115\n", dataRepository.GetClient(0).ToString());
			Assert.AreEqual("Client: Luis Snow, PESEL: 21152222115, phone number: 222222115\n", dataRepository.GetClient(1).ToString());
			Assert.AreEqual("Client: Rachel Sanchez, PESEL: 21153332115, phone number: 333332115\n", dataRepository.GetClient(2).ToString());
			Assert.AreEqual("Client: Jud Smith, PESEL: 21154442115, phone number: 444442115\n", dataRepository.GetClient(3).ToString());
			Assert.AreEqual("Client: Gage Butler, PESEL: 21155552115, phone number: 555552115\n", dataRepository.GetClient(4).ToString());
			Assert.AreEqual(5, dataRepository.GetAllBooks().Count());
			Assert.AreEqual("Book: \"Something Fishy\" by Wodehouse (1957)", dataRepository.GetBook(1).ToString());
			Assert.AreEqual("Book: \"Something Fishy\" by Wodehouse (1957)", dataRepository.GetBook(2).ToString());
			Assert.AreEqual("Book: \"Something Fishy\" by Wodehouse (1957)", dataRepository.GetBook(3).ToString());
			Assert.AreEqual("Book: \"Something Fishy\" by Wodehouse (1957)", dataRepository.GetBook(4).ToString());
			Assert.AreEqual("Book: \"Something Fishy\" by Wodehouse (1957)", dataRepository.GetBook(5).ToString());

		}
	}
}