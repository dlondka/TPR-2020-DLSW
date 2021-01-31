using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
				onPropertyChanged();
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
				onPropertyChanged();
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
				onPropertyChanged();
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
				onPropertyChanged();
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
				onPropertyChanged();
			}
		}
		#endregion

		#region Commands
		public Command ShowAddWindowProperty { get; private set; }

		public Command ShowDetailsWindowProperty { get; private set; }

		public Command DeleteContactTypeProperty { get; set; }

		public Command RefreshProperty { get; set; }

		public Command ConfirmAddProperty { get; set; }

		public Command ConfirmEditProperty { get; set; }
		#endregion

		#region Windows
		public Lazy<IWindow> AddWindow { get; set; }

		public Lazy<IWindow> DetailsWindow { get; set; }
		#endregion

		public ViewModel()
		{
			ContactsModel = new ContactsModel();
			init();
		}

		public ViewModel(IContactsModel contactsModel)
		{
			ContactsModel = contactsModel;
			init();
		}


		private void init()
		{
			ContactTypes = ContactsModel.GetContactTypes();
			ShowAddWindowProperty = new Command(ShowAddWindow);
			ShowDetailsWindowProperty = new Command(ShowDetailsWindow);
			DeleteContactTypeProperty = new Command(DeleteContactType);
			RefreshProperty = new Command(Refresh);
			ConfirmAddProperty = new Command(ConfirmAdd);
			ConfirmEditProperty = new Command(ConfirmEdit);
		}


		#region Actions

		public void DeleteContactType()
		{
			if (CurrentContactType != null)
			{
				Task.Run(() =>
				{

					ContactsModel.RemoveContactType(CurrentContactType.ContactTypeID);
					Refresh();
				});
			}
		}

		public void ConfirmEdit()
		{
			Task.Run(() =>
			{
				ContactsModel.UpdateContactType(CurrentContactTypeID, CurrentName);
				Refresh();
			});
		}

		public void ConfirmAdd()
		{
			Task.Run(() =>
			{
				ContactsModel.AddContactType(CurrentName);
				Refresh();
			});
		}

		public void Refresh()
		{
			ContactTypes = ContactsModel.GetContactTypes();
		}

		public void ShowDetailsWindow()
		{
			if (CurrentContactType == null)
			{
				return;
			}
			CurrentContactTypeID = CurrentContactType.ContactTypeID;
			CurrentName = CurrentContactType.Name;
			CurrentModifiedDate = CurrentContactType.ModifiedDate;

			IWindow window = DetailsWindow.Value;
			window.SetViewModel(this);
			window.Show();
		}

		public void ShowAddWindow()
		{
			IWindow window = AddWindow.Value;
			window.SetViewModel(this);
			window.Show();
		}
		#endregion

	}
}
