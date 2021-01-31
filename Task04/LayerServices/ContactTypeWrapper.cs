using LayerData;
using System;


namespace LayerServices
{
    public class ContactTypeWrapper
    {
        private ContactType ContactType;

        public ContactTypeWrapper(ContactType contactType)
        {
            ContactType = contactType;
        }

        public ContactTypeWrapper(int contactTypeID, string name, DateTime modifiedDate)
        {
            ContactType contactType = new ContactType
            {
                ContactTypeID = contactTypeID,
                Name = name,
                ModifiedDate = modifiedDate
            };
            ContactType = contactType;
        }

        public int ContactTypeID
        {
            get
            {
                return ContactType.ContactTypeID;
            }
            set
            {
                ContactType.ContactTypeID = value;
            }
        }

        public string Name
        {
            get
            {
                return ContactType.Name;
            }
            set
            {
                ContactType.Name = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return ContactType.ModifiedDate;
            }
            set
            {
                ContactType.ModifiedDate = value;
            }
        }
    }
}
