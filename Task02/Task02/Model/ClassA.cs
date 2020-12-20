using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task02
{
    public class ClassA : ISerializable
    {
        public string ClassName { get; set; }
        public double ExampleDouble { get; set; }
        public ClassB ExampleB { get; set; }

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
            info.AddValue("ClassName", ClassName, typeof(string));
            info.AddValue("ExampleDouble", ExampleDouble, typeof(double));
            info.AddValue("ExampleB", ExampleB, typeof(ClassB));
        }

		public override bool Equals(object obj)
		{
			return obj is ClassA a &&
				   ClassName == a.ClassName &&
				   ExampleDouble == a.ExampleDouble &&
				   EqualityComparer<ClassB>.Default.Equals(ExampleB, a.ExampleB);
		}
	}

}
