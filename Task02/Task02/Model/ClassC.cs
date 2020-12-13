using System.Runtime.Serialization;

namespace Task02
{
    public class ClassC : ISerializable
    {
        public string ClassName;
        public bool ExampleBool;
        public ClassA ExampleA;

        public ClassC(string className, bool exampleBool, ClassA exampleA)
        {
            ClassName = className;
            ExampleBool = exampleBool;
            ExampleA = exampleA;
        }

        public ClassC(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ClassName = serializationInfo.GetString("ClassName");
            ExampleBool = serializationInfo.GetBoolean("ExampleBool");
            ExampleA = (ClassA)serializationInfo.GetValue("ExampleA", typeof(ClassA));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("ExampleBool", ExampleBool);
            info.AddValue("ExampleA", ExampleA);
        }
    }
}
