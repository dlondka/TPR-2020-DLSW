using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreLibrary.Filler;
using BookstoreLibrary.Model;

namespace BookstoreLibrary.ModelTests
{
	[TestClass()]
	public class PublisherTests
	{
		[TestMethod()]
		public void ToStringTest()
		{
			ConstantDataFiller filler = new ConstantDataFiller();
			DataRepository repository = new DataRepository(filler.Fill(new DataContext()));

			Assert.AreEqual("Publisher: Publisher1, phone numer: 111111111\n", repository.GetPublisher(0).ToString());
		}
	}
}