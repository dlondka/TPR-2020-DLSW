using System.Runtime.Serialization;

namespace Task02
{
    public class ClassB : ISerializable
    {
        public string ClassName;
        public int ExampleInt;
        public ClassC ExampleC;

        public ClassB(string className, int exampleInt, ClassC exampleC)
        {
            ClassName = className;
            ExampleInt = exampleInt;
            ExampleC = exampleC;
        }

        public ClassB(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ClassName = serializationInfo.GetString("ClassName");
            ExampleInt = serializationInfo.GetInt32("ExampleInt");
            ExampleC = (ClassC)serializationInfo.GetValue("ExampleC", typeof(ClassC));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("ExampleInt", ExampleInt);
            info.AddValue("ExampleC", ExampleC);
        }
    }
}
