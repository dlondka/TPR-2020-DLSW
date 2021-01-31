using LayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLayerModel
{
	public class ModelTest : IContactsModel
	{

		List<ContactType> Contacts;
		int index = 1;

		public ModelTest()
		{
			Contacts = new List<ContactType>();

			ContactType ct = new ContactType();
			ct.ContactTypeID = 0;
			ct.Name = "Test1";
			ct.ModifiedDate = DateTime.Now;
			Contacts.Add(ct);
		}

		public void AddContactType(string name)
		{
			ContactType ct = new ContactType();
			ct.ContactTypeID = index++;
			ct.Name = name;
			ct.ModifiedDate = DateTime.Now;
			
			Contacts.Add(ct);
		}

		public int GetContactIDByName(string name)
		{
			return 0;
		}

		public ContactType GetContactType(int id)
		{
			return Contacts[id];
		}

		public List<ContactType> GetContactTypes()
		{
			return Contacts;
		}

		public void RemoveContactType(int contactID)
		{
			Contacts.RemoveAt(contactID);
		}

		public void UpdateContactType(int contactID, string name)
		{
			Contacts[contactID].Name = name;
			Contacts[contactID].ModifiedDate = DateTime.Now;
		}
	}
}
