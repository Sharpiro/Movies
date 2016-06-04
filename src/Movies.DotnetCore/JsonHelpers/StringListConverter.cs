using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Movies.DotnetCore.JsonHelpers
{
    public class StringListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            IEnumerable<string> result;
            if (reader.ValueType == typeof(string))
            {
                result = JToken.Load(reader).Value<string>()
                    .Split(',').Select(v => v.Trim());
                return result;
            }
            result = JArray.Load(reader).ToObject<List<string>>();
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
