using Microsoft.VisualStudio.TestTools.UnitTesting;
using LayerViewModel;
using LayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerViewModel.Tests
{
	[TestClass()]
	public class ViewModelTests
	{
		[TestMethod()]
		public void AddContactTypeTest()
		{
			ViewModel vm = new ViewModel(new ContactsModel());
			int i = vm.ContactTypes.Count;
			vm.CurrentName = "Test";
			vm.ConfirmAdd();
			System.Threading.Thread.Sleep(300);
			Assert.AreEqual(i + 1, vm.ContactTypes.Count);
		}

		[TestMethod()]
		public void DeleteContactTypeTest()
		{
			ViewModel vm = new ViewModel(new ContactsModel());
			int i = vm.ContactTypes.Count;
			vm.CurrentContactType = vm.ContactTypes[0];
			vm.DeleteContactType();
			System.Threading.Thread.Sleep(300);
			Assert.AreEqual(i - 1, vm.ContactTypes.Count);
		}

		[TestMethod()]
		public void ConfirmEditTest()
		{
			ViewModel vm = new ViewModel(new ContactsModel());
			vm.CurrentContactTypeID = 0;
			string name = vm.ContactTypes[vm.CurrentContactTypeID].Name;
			vm.CurrentName = "";
			vm.ConfirmEdit();
			Assert.AreEqual("Assistant Sales Agent", vm.ContactTypes[vm.CurrentContactTypeID].Name);
		}
	}
}