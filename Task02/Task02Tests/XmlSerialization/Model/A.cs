using System.Runtime.Serialization;

namespace Task02
{
    [DataContract(IsReference = true)]
    public class A
    {
        [DataMember]
        public string ClassName;
        [DataMember]
        public double ExampleDouble;
        [DataMember]
        public B ExampleB;

        public A(string className, double exampleDouble, B exampleB)
        {
            ClassName = className;
            ExampleDouble = exampleDouble;
            ExampleB = exampleB;
        }

        public A(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ClassName = serializationInfo.GetString("ClassName");
            ExampleDouble = serializationInfo.GetDouble("ExampleDouble");
            ExampleB = (B)serializationInfo.GetValue("ExampleB", typeof(B));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("ExampleDouble", ExampleDouble);
            info.AddValue("ExampleB", ExampleB);
        }

        public override bool Equals(object obj)
        {
            return obj is A a &&
                   ClassName == a.ClassName &&
                   ExampleDouble == a.ExampleDouble &&
                   ExampleB.Equals(a.ExampleB);
        }
    }

}
