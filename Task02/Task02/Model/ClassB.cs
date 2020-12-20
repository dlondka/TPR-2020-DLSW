using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task02
{
    public class ClassB : ISerializable
    {
        public string ClassName { get; set; }
        public int ExampleInt { get; set; }
        public ClassC ExampleC { get; set; }

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
            info.AddValue("ClassName", ClassName, typeof(string));
            info.AddValue("ExampleInt", ExampleInt, typeof(int));
            info.AddValue("ExampleC", ExampleC, typeof(ClassC));
        }

		public override bool Equals(object obj)
		{
			return obj is ClassB b &&
				   ClassName == b.ClassName &&
				   ExampleInt == b.ExampleInt &&
				   EqualityComparer<ClassC>.Default.Equals(ExampleC, b.ExampleC);
		}
	}
}
