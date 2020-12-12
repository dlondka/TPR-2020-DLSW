using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
namespace Task02
{
	class CustomSerializer : Formatter
	{
		public override SerializationBinder Binder { get; set; }
		public override StreamingContext Context { get; set; }
		public override ISurrogateSelector SurrogateSelector { get; set; }
		private List<string> DeserializedData = new List<string>();
		private StringBuilder StringBuilder { get; set; }

		public CustomSerializer()
		{
			Binder = new AssemblyBinder();
		}

		public override object Deserialize(Stream serializationStream)
		{
			throw new NotImplementedException();
		}

		public override void Serialize(Stream serializationStream, object graph)
		{
			List<PropertyInfo> propertiesInfo = graph.GetType().GetProperties().ToList();
			string assemblyInfo;
			string typeName;
			Binder.BindToName(graph.GetType(), out assemblyInfo, out typeName);
			



			throw new NotImplementedException();
		}












		protected override void WriteArray(object obj, string name, Type memberType)
		{
			throw new NotImplementedException();
		}

		protected override void WriteBoolean(bool val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteByte(byte val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteChar(char val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteDateTime(DateTime val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteDecimal(decimal val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteDouble(double val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteInt16(short val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteInt32(int val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteInt64(long val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteObjectRef(object obj, string name, Type memberType)
		{
			throw new NotImplementedException();
		}

		protected override void WriteSByte(sbyte val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteSingle(float val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteTimeSpan(TimeSpan val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteUInt16(ushort val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteUInt32(uint val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteUInt64(ulong val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteValueType(object obj, string name, Type memberType)
		{
			throw new NotImplementedException();
		}

		private void StreamReader(Stream serializationStream)
		{
			if (serializationStream is null)
				throw new ArgumentException("The provided stream must be non-null");

			using StreamReader reader = new StreamReader(serializationStream);
			while (!(reader.ReadLine() is null))
			{
				this.DeserializedData.Add(reader.ReadLine());
			}
		}

		private void StreamWriter(Stream serializationStream)
		{
			if (!(serializationStream is null))
			{
				using StreamWriter writer = new StreamWriter(serializationStream);
				writer.Write(this.StringBuilder);
			}
		}
	}
}
