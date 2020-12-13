using System.Runtime.Serialization;

namespace Task02
{
    public class ClassA : ISerializable
    {
        public string ClassName;
        public double ExampleDouble;
        public ClassB ExampleB;

        public ClassA(string className, double exampleDouble, ClassB exampleB)
        {
            ClassName = className;
            ExampleDouble = exampleDouble;
            ExampleB = exampleB;
        }

        public ClassA(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            ClassName = serializationInfo.GetString("ClassName");
            ExampleDouble = serializationInfo.GetDouble("ExampleDouble");
            ExampleB = (ClassB)serializationInfo.GetValue("ExampleB", typeof(ClassB));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ClassName", ClassName);
            info.AddValue("ExampleDouble", ExampleDouble);
            info.AddValue("ExampleB", ExampleB);
        }
    }

}
