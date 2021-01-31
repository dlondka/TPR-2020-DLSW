using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LayerServices.Tests
{
	[TestClass()]
	public class ContactsRepositoryTests
	{
		[TestMethod()]
		public void AddAndRemoveContactTypeTest()
		{
			ContactsRepository repo = new ContactsRepository();

			int i = repo.GetContactTypes().Count;
			string name = "It's a contact type";
			repo.AddContactType(name);

			Assert.AreEqual(i + 1, repo.GetContactTypes().Count);

			repo.RemoveContactType(repo.GetContactIDByName(name));

			Assert.AreEqual(i, repo.GetContactTypes().Count);
		}

		[TestMethod()]
		public void GetContactTypesTest()
		{
			ContactsRepository repo = new ContactsRepository();
			List<ContactTypeWrapper> list = repo.GetContactTypes();

			Assert.AreEqual(20, repo.GetContactTypes().Count);
			Assert.AreEqual(repo.GetContactIDByName("Owner") + 1, list[10].ContactTypeID);
		}
	}
}