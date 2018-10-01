using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Ronin.Data
{
    public class JSONAddressContractResolver : DefaultContractResolver
    {
        public new static readonly JSONAddressContractResolver Instance = new JSONAddressContractResolver();

                protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName.Equals("JSONGoogles", StringComparison.InvariantCultureIgnoreCase))
            {
                property.PropertyType = typeof(object);
                property.Converter = new PlainJsonStringConverter();
                property.ItemConverter = new PlainJsonStringConverter();
                property.MemberConverter = new PlainJsonStringConverter();
                //property.ValueProvider = new Vprov();

                property.ShouldDeserialize = instance => { return true; };
            }

            if (property.PropertyName.Equals("AddressID", StringComparison.InvariantCultureIgnoreCase))
            {
                property.ShouldSerialize = instance => { return false; };
                property.ShouldDeserialize = instance => { return false; };
            }
                // property.Converter = new Newtonsoft.Json. Converters.BinaryConverter()
                return property;
        }



    }

    public class PlainJsonStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
            return objectType == typeof(string);

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                return item.ToString();
            }


            // This should not happen. Perhaps better to throw exception at this point?
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue((string)value);
        }


    }

    public class Vprov : IValueProvider
    {
        public object GetValue(object target)
        {
            return "gigga";
        }

        public void SetValue(object target, object value)
        {
            throw new NotImplementedException();
        }
    }

    public class Myconvert : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
            //throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get
            {
                bool retVal = base.CanRead;
                return retVal;
            }
        }
    }
}
