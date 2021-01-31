using System.Collections.Generic;

namespace LayerModel
{
    public interface IContactsModel
    {
        void AddContactType(string name);
        int GetContactIDByName(string name);
        ContactType GetContactType(int id);
        List<ContactType> GetContactTypes();
        void UpdateContactType(int contactID, string name);
        void RemoveContactType(int contactID);
    }
}
