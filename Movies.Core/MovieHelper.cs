using Movies.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Movies.Core
{
    public class MovieHelper
    {
        private readonly HttpWrapper _wrapper;

        public MovieHelper(HttpWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public IEnumerable<string> GetTopMovieIds()
        {
            var movieData = _wrapper.Get(MovieConstants.Urls.ImdbTop250);
            var regex = new Regex("(?<=data-titleid=\")[^\"]*");
            var stringList = regex.Matches(movieData).Cast<Match>().Select(m => m.Value);
            return stringList;
        }

        public async Task<Movie> GetMovieInfo(string movieId, int rank = 0)
        {
            var url = string.Format(MovieConstants.Urls.Omdb, movieId);
            var movieData = await _wrapper.GetASync(url);
            var movie = JsonConvert.DeserializeObject<Movie>(movieData);
            movie.Rank = rank + 1;
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetAllMovieData(int take = 250)
        {
            var movieIds = GetTopMovieIds().ToList();
            var movieDetailsList = await Task.WhenAll(movieIds.Take(take).Select((id, other) => GetMovieInfo(id, other)));
            return movieDetailsList;
        }
    }
}
