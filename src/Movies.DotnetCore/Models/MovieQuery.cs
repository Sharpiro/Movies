namespace Movies.DotnetCore.Models
{
    public class MovieQuery
    {
        public int MinYear { get; set; } = int.MinValue;
        public int MaxYear { get; set; } = int.MaxValue;
        public string Contains { get; set; } = "*";
        public string OrderBy { get; set; } = "Rank";
    }
}