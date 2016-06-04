using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Movies.DotnetCore.JsonHelpers
{
    public class DateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime returnDate;
            if (reader.ValueType == typeof(string))
            {
                var value = JToken.Load(reader).Value<string>();
                var split = value.Split(' ').Reverse();
                if (split.Count() < 3)
                    return DateTime.MinValue;
                var newValue = string.Join(" ", split);
                returnDate = DateTime.Parse(newValue);
                return returnDate;
            }
            returnDate = JToken.Load(reader).Value<DateTime>();
            return returnDate;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
