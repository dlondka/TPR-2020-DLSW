using Microsoft.VisualStudio.TestTools.UnitTesting;
using LayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerData;

namespace LayerModel.Tests
{
	[TestClass()]
	public class ContactsModelTests
	{

		[TestMethod()]
		public void AddAndRemoveContactTypeTest()
		{
			ContactsModel Model = new ContactsModel();

			Assert.AreEqual(20, Model.GetContactTypes().Count);

			Model.AddContactType("2115");

			Assert.AreEqual(21, Model.GetContactTypes().Count);

			Model.RemoveContactType(Model.GetContactIDByName("2115"));

			Assert.AreEqual(20, Model.GetContactTypes().Count);
		}

		[TestMethod()]
		public void GetContactTypesTest()
		{
			ContactsModel Model = new ContactsModel();
			List<ContactType> list = Model.GetContactTypes();

			Assert.AreEqual(20, Model.GetContactTypes().Count);
			Assert.AreEqual(Model.GetContactIDByName("Owner"), list[10].ContactTypeID);
		}

		[TestMethod()]
		public void GetContactIdByName()
		{
			ContactsModel Model = new ContactsModel();
			int i = Model.GetContactIDByName("Owner");

			Assert.AreEqual(11, i);
		}

		[TestMethod()]
		public void GetContactType()
		{
			ContactsModel Model = new ContactsModel();
			string name = Model.GetContactType(1).Name;

			Assert.AreEqual("Accounting Manager", name);
		}

		[TestMethod()]
		public void UpdateContactTypeTest()
		{
			ContactsModel Model = new ContactsModel();
			string oldName = Model.GetContactType(1).Name;

			Model.UpdateContactType(1, "2115");

			Assert.AreEqual("2115", Model.GetContactType(1).Name);

			Model.UpdateContactType(1, oldName);

			Assert.AreEqual(oldName, Model.GetContactType(1).Name);
		}
	}
}