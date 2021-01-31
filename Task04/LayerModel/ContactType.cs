using LayerServices;
using System;

namespace LayerModel
{
    class ContactType
    {
        private int _contactTypeID;
        private string _name;
        private DateTime _modifiedDate;


        public int ContactTypeID
        {
            get
            {
                return _contactTypeID;
            }
            set
            {
                _contactTypeID = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return _modifiedDate;
            }
            set
            {
                _modifiedDate = value;
            }
        }
        public ContactType() {}
        
        public ContactType(ContactTypeWrapper contactTypeWrapper)
        {
            ContactTypeID = contactTypeWrapper.ContactTypeID;
            Name = contactTypeWrapper.Name;
            ModifiedDate = contactTypeWrapper.ModifiedDate;
        }
    }
}
