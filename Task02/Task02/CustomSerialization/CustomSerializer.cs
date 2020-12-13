using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
namespace Task02
{
	public class CustomSerializer : Formatter
	{
		public override SerializationBinder Binder { get; set; }
		public override StreamingContext Context { get; set; }
		public override ISurrogateSelector SurrogateSelector { get; set; }
		private List<string> DeserializedData = new List<string>();
		private StringBuilder StringBuilder = new StringBuilder();

		public CustomSerializer()
		{
			Binder = new Binder();
		}

		public override void Serialize(Stream serializationStream, object graph)
		{
			do
			{
				List<PropertyInfo> propertiesInfo = graph.GetType().GetProperties().ToList();
				Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);
				Console.WriteLine(assemblyName + "~~" + typeName + "~~");
				StringBuilder.Append(assemblyName + "~~" + typeName + "~~" + m_idGenerator.GetId(graph, out _));

				foreach (PropertyInfo p in propertiesInfo)
				{
					WriteMember(p.Name, p.GetValue(graph));
				}

				graph = m_objectQueue.Dequeue();
			} while (!m_objectQueue.Count.Equals(0));


			StringBuilder.Remove(StringBuilder.Length - 1, 1);
			StreamWriter(serializationStream);
		}

		public override object Deserialize(Stream serializationStream)
		{
			StreamReader(serializationStream);

			object[] objectsArray = new object[DeserializedData.Count];
			Dictionary<int, object> objectsWithIDs = new Dictionary<int, object>();

			for (int i = 0; i < DeserializedData.Count; i++)
			{
				string[] splitString = DeserializedData[i].Split("~~");

				Type currentType = Binder.BindToType(splitString[0], splitString[1]);
				int currentID = Convert.ToInt32(splitString[2]);
				object currentObject = FormatterServices.GetUninitializedObject(currentType);
				objectsArray[i] = currentObject;
				objectsWithIDs.Add(currentID, currentObject);
			}


			for (int i = 0; i < DeserializedData.Count; i++)
			{
				string[] splitString = DeserializedData[i].Split("~~");

				Type currentType = Binder.BindToType(splitString[0], splitString[1]);

				List<PropertyInfo> propertiesInfo = currentType.GetProperties().ToList();
				Type[] typesArray = new Type[propertiesInfo.Count];
				object[] valuesOfTheParameters = new object[propertiesInfo.Count];
				int ID = Convert.ToInt32(splitString[5].Split("||")[2]);

				for (int j = 0; j < splitString.Length - 3; j++)
				{
					string[] property = splitString[j + 3].Split("||");
					Type type = propertiesInfo[j].PropertyType;
					typesArray[j] = type;

					valuesOfTheParameters[j] = objectsArray.Any(obj => type == obj.GetType()) ? objectsWithIDs[ID] : Convert.ChangeType(property[2], type);
				}
				currentType.GetConstructor(typesArray).Invoke(objectsArray[i], valuesOfTheParameters);

			}
			return objectsArray[0];
		}


		// Own methods:

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

		protected void WriteString(string val, string name)
		{
			this.StringBuilder.Append(val.GetType() + "||" + name + "||" + val);
		}



		// Overridden Write methods:

		protected override void WriteBoolean(bool val, string name)
		{
			this.StringBuilder.Append(val.GetType() + "||" + name + "||" + val);
		}

		protected override void WriteDouble(double val, string name)
		{
			this.StringBuilder.Append(val.GetType() + "||" + name + "||" + val);
		}

		protected override void WriteInt32(int val, string name)
		{
			this.StringBuilder.Append(val.GetType() + "||" + name + "||" + val);
		}

		protected override void WriteObjectRef(object obj, string name, Type memberType)
		{
			if (memberType == typeof(string))
			{
				this.WriteString(obj.ToString(), name);
			}
			else
			{
				if (obj is null)
				{
					Type type;
					switch(name)
					{
						case "ExampleA":
							type = typeof(ClassA);
							break;
						case "ExampleB":
							type = typeof(ClassB);
							break;
						case "ExampleC":
							type = typeof(ClassC);
							break;
						default:
							type = typeof(object);
							break;
					}

					StringBuilder.Append(type + "~~" + name + "~~" + null);
				}
				else
				{
					StringBuilder.Append(memberType + "~~" + name + "~~" + m_idGenerator.GetId(obj, out bool firstTime));

					if (firstTime)
					{
						m_objectQueue.Enqueue(obj);
					}
				}
			}
		}



		// Unimplemented methods:

		protected override void WriteArray(object obj, string name, Type memberType)
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

		protected override void WriteInt16(short val, string name)
		{
			throw new NotImplementedException();
		}

		protected override void WriteInt64(long val, string name)
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
	}
}
