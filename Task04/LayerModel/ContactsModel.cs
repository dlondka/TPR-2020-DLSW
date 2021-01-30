using System.Collections.Generic;
using LayerServices;
using LayerData;

namespace LayerModel
{
	public class ContactsModel
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
			return ContactsRepository.GetContactType(id);
		}

		public List<ContactType> GetContactTypes()
		{
			return ContactsRepository.GetContactTypes();
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
