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
			Assert.AreEqual(repo.GetContactIDByName("Owner"), list[10].ContactTypeID);
		}

		[TestMethod()]
		public void GetContactIdByName()
		{
			ContactsRepository repo = new ContactsRepository();

			int i = repo.GetContactIDByName("Owner");

			Assert.AreEqual(11, i);
		}

		[TestMethod()]
		public void GetContactType()
		{
			ContactsRepository repo = new ContactsRepository();
			string name = repo.GetContactType(1).Name;

			Assert.AreEqual("Accounting Manager", name);
		}

		[TestMethod()]
		public void UpdateContactTypeTest()
		{
			ContactsRepository repo = new ContactsRepository();
			string oldName = repo.GetContactType(1).Name;

			repo.UpdateContactType(1, "2115");

			Assert.AreEqual("2115", repo.GetContactType(1).Name);

			repo.UpdateContactType(1, oldName);

			Assert.AreEqual(oldName, repo.GetContactType(1).Name);
		}
	}
}