using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BookstoreLibrary.Model;

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

			Assert.AreEqual(5, dataRepository.GetAllPublishers().Count());
			Assert.AreEqual("Publisher: Publisher1, phone numer: 111111111\n", dataRepository.GetPublisher(0).ToString());
			Assert.AreEqual("Publisher: Publisher2, phone numer: 222222222\n", dataRepository.GetPublisher(1).ToString());
			Assert.AreEqual("Publisher: Publisher3, phone numer: 333333333\n", dataRepository.GetPublisher(2).ToString());
			Assert.AreEqual("Publisher: Publisher4, phone numer: 444444444\n", dataRepository.GetPublisher(3).ToString());
			Assert.AreEqual("Publisher: Publisher5, phone numer: 555555555\n", dataRepository.GetPublisher(4).ToString());

			Assert.AreEqual(5, dataRepository.GetAllBooks().Count());
			Assert.AreEqual("Book: \"Something Fishy\" by Wodehouse (1957)", dataRepository.GetBook(0).ToString());
			Assert.AreEqual("Book: \"Pet Sematary\" by King (1983)", dataRepository.GetBook(1).ToString());
			Assert.AreEqual("Book: \"Harry Potter and the Half-Blook Prince\" by Rowling (2005)", dataRepository.GetBook(2).ToString());
			Assert.AreEqual("Book: \"Marley & Me\" by Grogan (2005)", dataRepository.GetBook(3).ToString());
			Assert.AreEqual("Book: \"Feast\" by Masterton (1988)", dataRepository.GetBook(4).ToString());

			Assert.AreEqual(5, dataRepository.GetAllBooksDetails().Count());
			Assert.AreEqual("Book details: Book: \"Something Fishy\" by Wodehouse (1957), price: 12,99, tax: 5,00%, count: 114, description: \"Something Fishy is a novel by P. G. Wodehouse, first published in the United Kingdom on 18 January 1957 by Herbert Jenkins, London and in the United States on 28 January 1957 by Simon & Schuster, Inc., New York, under the title The Butler Did It.\"\n", dataRepository.GetBookDetails(0).ToString());
			Assert.AreEqual("Book details: Book: \"Pet Sematary\" by King (1983), price: 32,99, tax: 5,00%, count: 120, description: \"Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1986, and adapted into two films: one in 1989 and another in 2019. In November 2013, PS Publishing released Pet Sematary in a limited 30th-anniversary edition.\"\n", dataRepository.GetBookDetails(1).ToString());
			Assert.AreEqual("Book details: Book: \"Harry Potter and the Half-Blook Prince\" by Rowling (2005), price: 25,99, tax: 5,00%, count: 156, description: \"Harry Potter and the Half-Blood Prince is a fantasy novel written by British author J.K. Rowling and the sixth and penultimate novel in the Harry Potter series.\"\n", dataRepository.GetBookDetails(2).ToString());
			Assert.AreEqual("Book details: Book: \"Marley & Me\" by Grogan (2005), price: 15,99, tax: 5,00%, count: 137, description: \"Marley & Me: Life and Love with the World's Worst Dog is an autobiographical book by journalist John Grogan, published in 2005, about the 13 years he and his family spent with their yellow Labrador Retriever, Marley.\"\n", dataRepository.GetBookDetails(3).ToString());
			Assert.AreEqual("Book details: Book: \"Feast\" by Masterton (1988), price: 30,99, tax: 5,00%, count: 125, description: \"The little town of Allen's Corner in rural Connecticut hid a secret. A terrible, unimaginable secret. A secret that only the children knew. It fed on their youth, ate away at their innocence, and consumed their very souls with a twisted hunger that could never be revealed - nor ever satisfied.\"\n", dataRepository.GetBookDetails(4).ToString());
			
			Assert.AreEqual(10, dataRepository.GetAllPurchases().Count());
		}
	}
}