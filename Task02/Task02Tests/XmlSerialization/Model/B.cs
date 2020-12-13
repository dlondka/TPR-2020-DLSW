using System.Runtime.Serialization;

namespace Task02
{
    [DataContract(IsReference = true)]
    public class B
    {
        [DataMember]
        public string ClassName;
        [DataMember]
        public int ExampleInt;
        [DataMember]
        public C ExampleC;

        public B(string className, int exampleInt, C exampleC)
        {
            ClassName = className;
            ExampleInt = exampleInt;
            ExampleC = exampleC;
        }

        public B(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ClassName = serializationInfo.GetString("ClassName");
            ExampleInt = serializationInfo.GetInt32("ExampleInt");
            ExampleC = (C)serializationInfo.GetValue("ExampleC", typeof(C));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("ExampleInt", ExampleInt);
            info.AddValue("ExampleC", ExampleC);
        }

        public override bool Equals(object obj)
        {
            return obj is B b &&
                   ClassName == b.ClassName &&
                   ExampleInt == b.ExampleInt &&
                   ExampleC.Equals(b.ExampleC);
        }
    }
}
