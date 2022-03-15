using Newtonsoft.Json.Serialization;
using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace PurrplingCore.Framework.Serialization
{
    class TypeBinder : ISerializationBinder
    {
        private readonly Dictionary<string, Type> _knownTypes = new Dictionary<string, Type>();
        private readonly IMonitor monitor;

        public TypeBinder(IManifest manifest, IMonitor monitor)
        {
            this.Manifest = manifest;
            this.monitor = monitor;
        }

        public IManifest Manifest { get; }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = this.Manifest.UniqueID;
            typeName = this.GetTypeKey(serializedType);

            if (typeName == null)
                throw new TypeSerializationExcetion(serializedType);
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            if (this.Manifest.UniqueID == assemblyName)
            {
                return this._knownTypes
                    .SingleOrDefault(tkv => tkv.Key == typeName)
                    .Value;
            }

            return null;
        }

        private string GetTypeKey(Type type)
        {
            return this._knownTypes
                .SingleOrDefault(tkv => tkv.Value == type)
                .Key;
        }

        internal void RegisterType(Type type, string name)
        {
            if (this._knownTypes.ContainsKey(name))
                throw new InvalidOperationException($"Type name `{name}` is already used");

            if (this._knownTypes.ContainsValue(type))
                throw new InvalidOperationException($"Type `{type.FullName}` is already registered as `{this.GetTypeKey(type)}`");

            this._knownTypes.Add(name, type);
            this.monitor.Log($"Registered data type `{type.FullName}, {type.Assembly.GetName().Name}` as `{name}`");

            foreach (var attr in type.GetCustomAttributes<XmlIncludeAttribute>())
            {
                if (!this._knownTypes.ContainsValue(attr.Type))
                    this.RegisterType(attr.Type, $"{name}.{attr.Type.Name}");
            }
        }
    }
}
