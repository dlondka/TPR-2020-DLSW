using System.Runtime.Serialization;

namespace Task02
{
    [DataContract(IsReference = true)]
    public class C
    {
        [DataMember]
        public string ClassName;
        [DataMember]
        public bool ExampleBool;
        [DataMember]
        public A ExampleA;

        public C(string className, bool exampleBool, A exampleA)
        {
            ClassName = className;
            ExampleBool = exampleBool;
            ExampleA = exampleA;
        }

        public C(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ClassName = serializationInfo.GetString("ClassName");
            ExampleBool = serializationInfo.GetBoolean("ExampleBool");
            ExampleA = (A)serializationInfo.GetValue("ExampleA", typeof(A));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("ExampleBool", ExampleBool);
            info.AddValue("ExampleA", ExampleA);
        }

        public override bool Equals(object obj)
        {
            return obj is C c &&
                   ClassName == c.ClassName &&
                   ExampleBool == c.ExampleBool;
        }
    }
}
