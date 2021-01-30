using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerData;

namespace LayerServices
{
	public interface IContactsRepository
	{
		void AddContactType(string name);
		int GetContactIDByName(string name);
		ContactType GetContactType(int id);
		List<ContactType> GetContactTypes();
		void UpdateContactType(int contactID, string name);
		void RemoveContactType(int contactID);
	}
}
