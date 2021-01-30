using System;
using System.Collections.Generic;
using System.Linq;
using LayerData;

namespace LayerServices
{
	public class ContactsRepository : IContactsRepository
	{
		public void AddContactType(string name)
		{
			ContactType newContact = new ContactType
			{
				Name = name,
				ModifiedDate = DateTime.Now
			};

			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				Context.ContactType.InsertOnSubmit(newContact);
				Context.SubmitChanges();
			}
		}

		public int GetContactIDByName(string name)
		{
			ContactType contact = new ContactType();

			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				contact = Context.ContactType.Where(ct => ct.Name == name).FirstOrDefault();
			}
			return contact.ContactTypeID;
		}

		public ContactType GetContactType(int id)
		{
			ContactType contact = new ContactType();

			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				contact = Context.ContactType.Where(ct => ct.ContactTypeID == id).FirstOrDefault();
			}
			return contact;
		}

		public List<ContactType> GetContactTypes()
		{
			List<ContactType> contacts = new List<ContactType>();

			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				contacts = Context.ContactType.ToList();
			}

			return contacts;
		}

		public void RemoveContactType(int contactID)
		{
			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				ContactType contactType = Context.ContactType.Where(ct => ct.ContactTypeID == contactID).FirstOrDefault();
				Context.ContactType.DeleteOnSubmit(contactType);
				Context.SubmitChanges();
			}
		}

		public void UpdateContactType(int contactID, string name)
		{
			using (ContactTypeDBDataContext Context = new ContactTypeDBDataContext())
			{
				ContactType contact = Context.ContactType.Where(ct => ct.ContactTypeID == contactID).FirstOrDefault();
				contact.Name = name;
				contact.ModifiedDate = DateTime.Now;

				Context.SubmitChanges();
			}
		}
	}
}
