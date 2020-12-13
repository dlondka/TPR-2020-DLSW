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
            xmlSerializer.Serialize("..\\..\\..\\XmlSerialization\\A.xml", A);
            xmlSerializer.Serialize("..\\..\\..\\XmlSerialization\\B.xml", B);
            xmlSerializer.Serialize("..\\..\\..\\XmlSerialization\\C.xml", C);

            A deserializedA = (A)xmlSerializer.Deserialize("A.xml", typeof(A));
            B deserializedB = (B)xmlSerializer.Deserialize("B.xml", typeof(B));
            C deserializedC = (C)xmlSerializer.Deserialize("C.xml", typeof(C));

            Assert.IsTrue(deserializedA.Equals(A));
            Assert.IsTrue(deserializedB.Equals(B));
            Assert.IsTrue(deserializedC.Equals(C));
        }
    }
}