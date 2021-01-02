using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task02.Tests
{
    [TestClass()]
    public class XmlSerializationTests
    {
        [TestMethod()]
        public void XmlSerializationTest()
        {
            A A = new A("Klasa A", 21.37, null);
            B B = new B("Klasa B", 69, null);
            C C = new C("Klasa C", true, null);
            A.ExampleB = B;
            B.ExampleC = C;
            C.ExampleA = A;

            XmlSerializer xmlSerializer = new XmlSerializer();
            xmlSerializer.Serialize("..\\..\\..\\XmlSerialization\\Serialized\\A.xml", A);
            xmlSerializer.Serialize("..\\..\\..\\XmlSerialization\\Serialized\\B.xml", B);
            xmlSerializer.Serialize("..\\..\\..\\XmlSerialization\\Serialized\\C.xml", C);

            A deserializedA = (A)xmlSerializer.Deserialize("..\\..\\..\\XmlSerialization\\Serialized\\A.xml", typeof(A));
            B deserializedB = (B)xmlSerializer.Deserialize("..\\..\\..\\XmlSerialization\\Serialized\\B.xml", typeof(B));
            C deserializedC = (C)xmlSerializer.Deserialize("..\\..\\..\\XmlSerialization\\Serialized\\C.xml", typeof(C));

            Assert.AreEqual(deserializedA, A);
            Assert.AreEqual(deserializedB, B);
            Assert.AreEqual(deserializedC, C);

            Assert.IsTrue(deserializedA.Equals(A));
            Assert.IsTrue(deserializedB.Equals(B));
            Assert.IsTrue(deserializedC.Equals(C));

            Assert.AreSame(deserializedA, deserializedA.ExampleB.ExampleC.ExampleA);
        }
    }
}