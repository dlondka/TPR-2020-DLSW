using System.Collections.Generic;
using LayerServices;

namespace LayerModel
{
	public class ContactsModel : IContactsModel
	{
		private readonly IContactsRepository ContactsRepository;

		public ContactsModel()
		{
			ContactsRepository = new ContactsRepository();
		}

		public ContactsModel(IContactsRepository contactsRepository)
		{
			ContactsRepository = contactsRepository;
		}

		public void AddContactType(string name)
		{
			ContactsRepository.AddContactType(name);
		}

		public int GetContactIDByName(string name)
		{
			return ContactsRepository.GetContactIDByName(name);
		}

		public ContactType GetContactType(int id)
		{
			return new ContactType(ContactsRepository.GetContactType(id));
		}

		public List<ContactType> GetContactTypes()
		{
			List<ContactType> contacts = new List<ContactType>();
			foreach (ContactTypeWrapper wrapper in ContactsRepository.GetContactTypes())
            {
				contacts.Add(new ContactType(wrapper));
            }
			return contacts;
		}

		public void UpdateContactType(int contactID, string name)
		{
			ContactsRepository.UpdateContactType(contactID, name);
		}

		public void RemoveContactType(int contactID)
		{
			ContactsRepository.RemoveContactType(contactID);
		}

	}
}
