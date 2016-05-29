using Movies.Core;
using System.Linq;

namespace Movies.CommandLine
{
    public class Program
    {
        public static object JsonConvert { get; private set; }

        public static void Main(string[] args)
        {
            var helper = new MovieHelper(new HttpWrapper());
            //var topMovieIds = helper.GetTopMovieIds();
            //var movieInfo = helper.GetMovieInfo(topMovieIds.Skip(10).FirstOrDefault()).Result;
            var allMovies = helper.GetAllMovieData().Result;
        }
    }
}
