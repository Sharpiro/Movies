using Newtonsoft.Json.Linq;

namespace Movies.DotnetCore.JsonHelpers
{
    public static class JsonExtensions
    {
        public static void ReplacePropertyName(this JObject jObject, string oldName, string newName)
        {
            var parentObject = jObject[oldName].Parent;
            var newProperty = new JProperty(newName, parentObject.First);
            parentObject.Replace(newProperty);
        }
    }
}
