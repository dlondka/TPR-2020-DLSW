using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LayerData;
using System.Linq;

namespace LayerDataTests
{
	[TestClass]
	public class LayerDataTests
	{
		[TestMethod]
		public void AddToAndGetFromDBTest()
		{
			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				ContactType newContact = new ContactType
				{
					Name = "New contact name",
					ModifiedDate = DateTime.Now
				};

				Context.ContactType.InsertOnSubmit(newContact);
				Context.SubmitChanges();
			}

			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				ContactType readContact = Context.ContactType.FirstOrDefault(c => c.Name == "New contact name");
				ContactType anotherReadContact = Context.ContactType.FirstOrDefault(c => c.Name == "A name that does not appear");

				Assert.AreEqual("New contact name", readContact.Name);
				Assert.IsNull(anotherReadContact);

				Context.ContactType.DeleteOnSubmit(readContact);
				Context.SubmitChanges();

				ContactType yetAnotherReadContact = Context.ContactType.FirstOrDefault(c => c.Name == "New contact name");

				Assert.IsNull(yetAnotherReadContact);
			}


		}
	}
}
