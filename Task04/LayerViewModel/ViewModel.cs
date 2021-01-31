using System;
using System.Collections.Generic;
using LayerModel;

namespace LayerViewModel
{
    public class ViewModel : ViewModelListener
    {
        private List<ContactType> _contactTypes;
        private ContactType _currentContactType;
        private int _currentContactTypeID;
        private string _currentName;
        private DateTime _currentModifiedDate;

        private IContactsModel ContactsModel;

        #region Properties
        public List<ContactType> ContactTypes
        {
            get
            {
                return _contactTypes;
            }
            set
            {
                _contactTypes = value;
            }
        }
        public ContactType CurrentContactType
        {
            get
            {
                return _currentContactType;
            }
            set
            {
                _currentContactType = value;
            }
        }
        public int CurrentContactTypeID
        {
            get
            {
                return _currentContactTypeID;
            }
            set
            {
                _currentContactTypeID = value;
            }
        }
        public string CurrentName
        {
            get
            {
                return _currentName;
            }
            set
            {
                _currentName = value;
            }
        }
        public DateTime CurrentModifiedDate
        {
            get
            {
                return _currentModifiedDate;
            }
            set
            {
                _currentModifiedDate = value;
            }
        }
        #endregion

        public ViewModel()
        {
            ContactsModel = new ContactsModel();
        }
        private void init()
        {
            ContactTypes = ContactsModel.GetContactTypes();
            // TODO 
        }
    }
}
