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
			Binder.BindToName(graph.GetType(), out string assemblyName, out string typeName);
			StringBuilder.Append(assemblyName + "||" + typeName + "||" + m_idGenerator.GetId(graph, out bool firstTime) + "\n");

			ISerializable obj = (ISerializable)graph;
			SerializationInfo serializationInfo = new SerializationInfo(graph.GetType(), new FormatterConverter());
			StreamingContext context = new StreamingContext(StreamingContextStates.File);

			obj.GetObjectData(serializationInfo, context);

			foreach (SerializationEntry property in serializationInfo)
			{
				WriteMember(property.Name, property.Value);
			}

			while (m_objectQueue.Count != 0)
			{
				Serialize(null, m_objectQueue.Dequeue());
			}

			if (serializationStream != null)
			{
				StreamWriter(serializationStream);
			}
		}

		public override object Deserialize(Stream serializationStream)
		{
			if (serializationStream == null)
			{
				return null;
			}

			Dictionary<int, object> deserializedObjects = new Dictionary<int, object>();
			Dictionary<int, List<string>> propertiesOfTheObject = new Dictionary<int, List<string>>();

			StreamReader(serializationStream);
			int id = 0;

			for (int i = 0; i < DeserializedData.Count; i++)
			{
				if (DeserializedData[i].Contains("Task02, ")) // if that's an object
				{
					string[] values = DeserializedData[i].Split("||");
					Type type = Binder.BindToType(values[0], values[1]);
					id = int.Parse(values[2]);

					object uninitializedObject = FormatterServices.GetUninitializedObject(type);

					deserializedObjects.Add(id, uninitializedObject);
				}
				else // if that's a property
				{
					if (!propertiesOfTheObject.ContainsKey(id))
					{
						propertiesOfTheObject.Add(id, new List<string>());
					}
					propertiesOfTheObject[id].Add(DeserializedData[i]);
				}
			}

			Dictionary<int, object> readyObjects = new Dictionary<int, object>();
			Dictionary<int, List<int>> objIdRefId = new Dictionary<int, List<int>>();

			foreach (KeyValuePair<int, object> obj in deserializedObjects)
			{
				Type currentType = obj.Value.GetType();
				int currentId = obj.Key;

				SerializationInfo serializationInfo = new SerializationInfo(currentType, new FormatterConverter());
				StreamingContext context = new StreamingContext(StreamingContextStates.File);
				List<int> localRefs = new List<int>();

				foreach (string str in propertiesOfTheObject[obj.Key])
				{
					List<string> singleProperty = str.Split("||").ToList();
					Type propertyType = Type.GetType(singleProperty[0]);
					string propertyName = singleProperty[1];
					string propertyValue = singleProperty[2];

					if (singleProperty[0].Contains("Task02"))
					{
						serializationInfo.AddValue(propertyName, null);
						localRefs.Add(int.Parse(propertyValue));
					}
					else
					{
						serializationInfo.AddValue(propertyName, Convert.ChangeType(propertyValue, propertyType), propertyType);
					}
				}

				if (localRefs.Count > 0)
				{
					objIdRefId.Add(currentId, localRefs);
				}

				readyObjects.Add(currentId, Activator.CreateInstance(currentType, serializationInfo, context));

			}

			
			foreach (int objectId in objIdRefId.Keys)
			{
				foreach (int refId in objIdRefId[objectId])
				{
					foreach (PropertyInfo p in readyObjects[objectId].GetType().GetProperties())
					{
						if (p.PropertyType == readyObjects[refId].GetType())
						{
							p.SetValue(readyObjects[objectId], readyObjects[refId]);
						}
					}
				}
			}

			return readyObjects.First().Value;
		}


		// Own methods:

		private void StreamReader(Stream serializationStream)
		{
			using StreamReader reader = new StreamReader(serializationStream);
			string line;
			while ((line = reader.ReadLine()) != null)
				this.DeserializedData.Add(line);
		}

		private void StreamWriter(Stream serializationStream)
		{
			using StreamWriter writer = new StreamWriter(serializationStream);
			writer.Write(StringBuilder);
		}

		// Overridden Write methods:

		protected override void WriteBoolean(bool val, string name)
		{
			StringBuilder.Append(val.GetType() + "||" + name + "||" + val + "\n");
		}

		protected override void WriteDouble(double val, string name)
		{
			StringBuilder.Append(val.GetType() + "||" + name + "||" + val + "\n");
		}

		protected override void WriteInt32(int val, string name)
		{
			StringBuilder.Append(val.GetType() + "||" + name + "||" + val + "\n");
		}

		protected override void WriteObjectRef(object obj, string name, Type memberType)
		{
			if (obj != null)
			{
				if (memberType == typeof(string))
				{
					StringBuilder.Append(obj.GetType() + "||" + name + "||" + obj + "\n");
				}
				else
				{
					StringBuilder.Append(obj.GetType() + "||" + name + "||" + m_idGenerator.GetId(obj, out bool firstTime).ToString() + "\n");

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
