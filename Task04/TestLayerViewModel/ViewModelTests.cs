using Microsoft.VisualStudio.TestTools.UnitTesting;
using LayerViewModel;
using LayerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerModel.Tests;

namespace LayerViewModel.Tests
{
	[TestClass()]
	public class ViewModelTests
	{
		[TestMethod()]
		public void AddContactTypeTest()
		{
			ViewModel vm = new ViewModel(new ModelTest());
			Assert.AreEqual(1, vm.ContactTypes.Count);
			vm.CurrentName = "Test";
			vm.ConfirmAdd();
			System.Threading.Thread.Sleep(300);
			Assert.AreEqual(2, vm.ContactTypes.Count);
		}

		[TestMethod()]
		public void DeleteContactTypeTest()
		{
			ViewModel vm = new ViewModel(new ModelTest());
			vm.CurrentContactType = vm.ContactTypes[0];
			vm.DeleteContactType();
			System.Threading.Thread.Sleep(300);
			Assert.AreEqual(0, vm.ContactTypes.Count);
		}

		[TestMethod()]
		public void ConfirmEditTest()
		{
			ViewModel vm = new ViewModel(new ModelTest());
			string name = vm.ContactTypes[0].Name;
			vm.CurrentName = "Test1";
			vm.ConfirmEdit();
			Assert.AreEqual("Test1", vm.ContactTypes[vm.CurrentContactTypeID].Name);
		}
	}
}