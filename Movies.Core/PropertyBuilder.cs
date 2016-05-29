using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Core
{
    public static class PropertyBuilder
    {
        public static string Build(string names)
        {
            var nameList = names.Split(new[] { "\r\n" }, StringSplitOptions.None);
            var list = new List<string>();
            var builder = new StringBuilder();
            foreach (var name in nameList.Skip(1).Reverse().Skip(1).Reverse())
            {
                var current = $"public string {name} {{ get; set; }}";
                list.Add(current);
                builder.AppendLine(current);
            }
            var stringList = builder.ToString();
            return stringList;
        }
    }
}
