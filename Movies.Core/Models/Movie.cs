using Movies.Core.JsonHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Movies.Core.Models
{
    public class Movie
    {
        [JsonConverter(typeof(StringListConverter))]
        public IEnumerable<string> Actors { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string Director { get; set; }
        [JsonProperty("Genre"), JsonConverter(typeof(StringListConverter))]
        public IEnumerable<string> Genres { get; set; }
        [JsonProperty("Language"), JsonConverter(typeof(StringListConverter))]
        public IEnumerable<string> Languages { get; set; }
        [JsonConverter(typeof(IntConverter))]
        public int Metascore { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Rated { get; set; }
        [JsonConverter(typeof(DateConverter))]
        public DateTime? Released { get; set; }
        public bool Response { get; set; }
        [JsonProperty("RunTime"), JsonConverter(typeof(IntConverter))]
        public int RuntimeMinutes { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        [JsonProperty("Writer"), JsonConverter(typeof(StringListConverter))]
        public IEnumerable<string> Writers { get; set; }
        public string ImdbID { get; set; }
        public double ImdbRating { get; set; }
        [JsonConverter(typeof(IntConverter))]
        public int ImdbVotes { get; set; }
        public int Rank { get; set; }
    }
}
