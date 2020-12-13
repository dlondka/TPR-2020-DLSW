using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Task02
{
	class Binder : SerializationBinder
	{
		public override Type BindToType(string assemblyName, string typeName)
		{
			return Assembly.Load(assemblyName).GetType(typeName);
		}

		public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
		{
			assemblyName = serializedType.Assembly.FullName;
			typeName = serializedType.FullName;
		}
	}
}
