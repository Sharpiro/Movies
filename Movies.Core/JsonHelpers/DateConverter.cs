using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Movies.Core.JsonHelpers
{
    public class DateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = JToken.Load(reader).Value<string>();
            var split = value.Split(' ').Reverse();
            if (split.Count() < 3)
                return null;
            var newValue = string.Join(" ", split);
            var datetime = DateTime.Parse(newValue);
            return datetime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
    }
}
