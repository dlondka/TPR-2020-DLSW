using BookstoreLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookstoreLibrary.Tests
{
	[TestClass()]
	public class UnitTest1
	{
		Class1 class1 = new Class1();
		[TestMethod()]
		public void AddTest()
		{
			Assert.AreEqual(class1.Add(2, 0.231), 2 + 0.231);
		}
	}
}