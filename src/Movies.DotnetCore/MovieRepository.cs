using Movies.DotnetCore.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Movies.DotnetCore.JsonHelpers;
using Movies.DotnetCore.Interfaces;
using System;

namespace Movies.DotnetCore
{
    public class MovieRepository : IMovieRepository
    {
        private readonly HttpWrapper _wrapper;

        public MovieRepository(HttpWrapper wrapper)
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

        public async Task<Movie> GetMovie(string movieId, int rank = 0)
        {
            var url = string.Format(MovieConstants.Urls.Omdb, movieId);
            var movieData = await _wrapper.GetASync(url);
            var jObject = JObject.Parse(movieData);
            jObject.ReplacePropertyName("Language", "Languages");
            jObject.ReplacePropertyName("Genre", "Genres");
            jObject.ReplacePropertyName("Runtime", "RuntimeMinutes");
            jObject.ReplacePropertyName("Writer", "Writers");
            var movieModified = jObject.ToObject<Movie>();
            movieModified.Rank = rank + 1;
            return movieModified;
        }

        public async Task<MovieList> GetMovieList(int take = 250)
        {
            if (take < 1 || take > 250)
                throw new ArgumentOutOfRangeException(nameof(take), "'take' must be between 1 and 250 inclusively");
            var movieIds = GetTopMovieIds();
            var movieDetailsList = await Task.WhenAll(movieIds.Take(take)
                .Select((id, index) => GetMovie(id, index)));
            var movieList = new MovieList(movieDetailsList);
            return movieList;
        }
    }
}
