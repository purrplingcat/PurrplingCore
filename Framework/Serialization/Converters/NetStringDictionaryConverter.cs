using Netcode;
using Newtonsoft.Json;
using StardewValley.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PurrplingCore.Framework.Serialization.Converters
{
    class NetStringDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return TypeUtils.IsSubclassOfRawGeneric(typeof(NetStringDictionary<,>), objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = typeof(NetStringDictionary<,>);
            
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(NetStringDictionary<,>))
            {
                // get dictionary's key/value types
                Type[] genericArgs = type.GetGenericArguments();
                if (genericArgs.Length != 2)
                    throw new InvalidOperationException("Can't parse the asset's dictionary key/value types.");
                Type valueType = type.GetGenericArguments().FirstOrDefault();
                Type fieldType = type.GetGenericArguments().LastOrDefault();
                if (valueType == null)
                    throw new InvalidOperationException("Can't parse the asset's dictionary key type.");
                if (fieldType == null)
                    throw new InvalidOperationException("Can't parse the asset's dictionary value type.");

                // get underlying apply method
                MethodInfo method = this.GetType().GetMethod(nameof(this.WriteJsonDict), BindingFlags.Instance | BindingFlags.NonPublic);
                if (method == null)
                    throw new InvalidOperationException($"Can't fetch the internal {nameof(this.WriteJsonDict)} method.");

                // invoke method
                method
                    .MakeGenericMethod(valueType, fieldType)
                    .Invoke(this, new object[] { writer, value, serializer });
            }
        }

        private void WriteJsonDict<T, TField>(JsonWriter writer, object value, JsonSerializer serializer) where TField : NetField<T, TField>, new()
        {
            var netDict = (NetStringDictionary<T, TField>)value;
        }
    }
}
