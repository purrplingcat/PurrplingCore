using Netcode;
using Newtonsoft.Json;
using System;

namespace PurrplingCore.Framework.Serialization.Converters
{
    internal class NetFieldConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            var check = TypeUtils.IsSubclassOfRawGeneric(typeof(NetFieldBase<,>), objectType);
            return check;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var prop = existingValue?.GetType().GetProperty("Value");

            if (prop != null)
            {
                prop.SetValue(existingValue, serializer.Deserialize(reader, prop.PropertyType));
            }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var prop = value?.GetType().GetProperty("Value");

            if (prop == null)
            {
                writer.WriteNull();
                return;
            }

            serializer.Serialize(writer, prop.GetValue(value));
        }
    }
}