using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task02;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

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

			using (FileStream fileStream = new FileStream("tests.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				IFormatter customSerializer = new CustomSerializer();
				customSerializer.Serialize(fileStream, a);
			}

			List<string> results = new List<string>();
			using (StreamReader reader = new StreamReader(new FileStream("tests.txt", FileMode.Open, FileAccess.Read)))
			{
				string line;
				int id = -1;
				while ((line = reader.ReadLine()) != null)
				{
					if (line.Contains("Task02,"))
					{
						results.Add("");
						id++;
					}
					results[id] += line + "\n";
				}
			}
			//<Task02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null||Task02.ClassA||1System.String||ClassName||ClassASystem.Double||ExampleDouble||21,15Task02.ClassB||ExampleB||2>.
			Assert.AreEqual("Task02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null||Task02.ClassA||1\nSystem.String||ClassName||ClassA\nSystem.Double||ExampleDouble||21,15\nTask02.ClassB||ExampleB||2\n", results[0]);
			Assert.AreEqual("Task02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null||Task02.ClassB||2\nSystem.String||ClassName||ClassB\nSystem.Int32||ExampleInt||2115\nTask02.ClassC||ExampleC||3\n", results[1]);
			Assert.AreEqual("Task02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null||Task02.ClassC||3\nSystem.String||ClassName||ClassC\nSystem.Boolean||ExampleBool||True\nTask02.ClassA||ExampleA||1\n", results[2]);

			File.Delete("tests.txt");
		}


		[TestMethod()]
		public void DeserializeTest()
		{
			ClassA a = new ClassA("A", 77.77, null);
			ClassB b = new ClassB("B", 2115, null);
			ClassC c = new ClassC("C", false, null);
			a.ExampleB = b;
			b.ExampleC = c;
			c.ExampleA = a;

			using (FileStream fileStream = new FileStream("tests.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				IFormatter customSerializer = new CustomSerializer();
				customSerializer.Serialize(fileStream, a);
			}

			ClassA deserializedA;
			using (FileStream fileStream = new FileStream("tests.txt", FileMode.Open, FileAccess.ReadWrite))
			{
				IFormatter customSerializer = new CustomSerializer();
				deserializedA = customSerializer.Deserialize(fileStream) as ClassA;
			}

			Assert.IsNotNull(deserializedA);
			Assert.AreEqual(a.ClassName, deserializedA.ClassName);
			Assert.AreEqual(a.ExampleDouble, deserializedA.ExampleDouble);
			Assert.AreEqual(a.ExampleB, deserializedA.ExampleB);
			Assert.AreEqual(a.ExampleB, deserializedA.ExampleB);
			Assert.AreEqual(a.ExampleB.ClassName, deserializedA.ExampleB.ClassName);
			Assert.AreEqual(a.ExampleB.ExampleInt, deserializedA.ExampleB.ExampleInt);
			Assert.AreEqual(a.ExampleB.ExampleC, deserializedA.ExampleB.ExampleC);
			Assert.AreEqual(a.ExampleB.ExampleC.ClassName, deserializedA.ExampleB.ExampleC.ClassName);
			Assert.AreEqual(a.ExampleB.ExampleC.ExampleBool, deserializedA.ExampleB.ExampleC.ExampleBool);
			Assert.AreSame(deserializedA, deserializedA.ExampleB.ExampleC.ExampleA);

			File.Delete("tests.txt");
		}
	}
}