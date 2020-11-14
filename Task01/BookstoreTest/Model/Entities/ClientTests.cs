using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookstoreLibrary.Model.Entities.Tests
{
	[TestClass()]
	public class ClientTests
	{
		[TestMethod()]
		public void ClientTest()
		{
			Client C1 = new Client("John", "Doe", "21157772115", "606211568");
			Assert.IsTrue(C1.FirstName == "John" && C1.LastName == "Doe" && C1.PESEL == "21157772115" && C1.PhoneNumber == "606211568");
		}

		[TestMethod()]
		public void EqualsTest()
		{
			Client C1 = new Client("John", "Doe", "21157772115", "606211568");
			Client C2 = new Client("John", "Doe", "21157772115", "606211568");
			Client C3 = new Client("Jon", "Snow", "21157772115", "606211568");
			Assert.IsTrue(C1.Equals(C2));
			Assert.IsFalse(C1.Equals(C3));
		}

		[TestMethod()]
		public void GetHashCodeTest()
		{
			Client C1 = new Client("John", "Doe", "21157772115", "606211568");
			Client C2 = new Client("John", "Doe", "21157772115", "606211568");
			Assert.AreEqual(C1.GetHashCode(), C1.GetHashCode());
			Assert.AreNotEqual(C1.GetHashCode(), C2.GetHashCode());
		}

		[TestMethod()]
		public void ToStringTest()
		{
			Client C1 = new Client("John", "Doe", "21157772115", "606211568");
			Assert.AreEqual(C1.ToString(), "Client: John Doe, PESEL: 21157772115, phone number: 606211568\n");
		}
	}
}