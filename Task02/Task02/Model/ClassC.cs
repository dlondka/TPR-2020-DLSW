using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task02
{
    public class ClassC : ISerializable
    {
        public string ClassName { get; set; }
        public bool ExampleBool { get; set; }
        public ClassA ExampleA { get; set; }

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
            info.AddValue("ClassName", ClassName, typeof(string));
            info.AddValue("ExampleBool", ExampleBool, typeof(bool));
            info.AddValue("ExampleA", ExampleA, typeof(ClassA));
        }

		public override bool Equals(object obj)
		{
			return obj is ClassC c &&
				   ClassName == c.ClassName &&
				   ExampleBool == c.ExampleBool &&
				   ExampleA.ClassName == c.ExampleA.ClassName &&
                   ExampleA.ExampleDouble == c.ExampleA.ExampleDouble;
		}
	}
}
