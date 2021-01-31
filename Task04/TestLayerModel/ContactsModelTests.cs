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
			IContactsModel Model = new ContactsModel();

			Assert.AreEqual(20, Model.GetContactTypes().Count);

			Model.AddContactType("2115");

			Assert.AreEqual(21, Model.GetContactTypes().Count);

			Model.RemoveContactType(Model.GetContactIDByName("2115"));

			Assert.AreEqual(20, Model.GetContactTypes().Count);
		}

		[TestMethod()]
		public void GetContactIdByName()
		{
			ContactsModel Model = new ContactsModel();
			int i = Model.GetContactIDByName("Owner");

			Assert.AreEqual(11, i);
		}
	}
}