using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task02;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task02.Tests
{
	[TestClass()]
	public class CustomSerializerTests
	{

		[TestMethod()]
		public void SerializeTest()
		{
			ClassA a = new ClassA("ClassA", 21.15, null);
			ClassB b = new ClassB("ClassB", 2115, null);
			ClassC c = new ClassC("ClassC", true, null);
			a.ExampleB = b;
			b.ExampleC = c;
			c.ExampleA = a;

			using (FileStream fileStream = new FileStream("test.txt", FileMode.Create))
			{
				CustomSerializer customSerializer = new CustomSerializer();
				customSerializer.Serialize(fileStream, a);
				customSerializer.Serialize(fileStream, b);
				customSerializer.Serialize(fileStream, c);
			}















			//throw new NotImplementedException();
		}

		[TestMethod()]
		public void DeserializeTest()
		{
			//throw new NotImplementedException();
		}
	}
}