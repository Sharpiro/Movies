using Movies.DotnetCore;
using Movies.DotnetCore.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Xunit;

namespace Movies.Core.Tests
{
    public class MovieBusinessLayerTests
    {
        private const string _dataLoaction = @"c:\users\u403598\desktop\temp\movies";

        [Fact]
        public void GetMovieDataTest()
        {
            var wrapper = new HttpWrapper();
            var apiHelper = new MovieApiHelper(wrapper);
            var movieBl = new MovieBusinessLayer(apiHelper);
            var fakeMovieBl = new FakeMovieBusinessLayer();
            var data = fakeMovieBl.GetMovieData().Result;
            Assert.True(data.Count() > 0);
            var jsonString = JsonConvert.SerializeObject(data);
            Assert.NotNull(jsonString);
            //File.WriteAllText($"{_dataLoaction}\\movieIds.txt", jsonString);
        }

        [Fact]
        public void GetMoviesByQuery()
        {
            var fakeMovieBl = new FakeMovieBusinessLayer();
            var movies = fakeMovieBl.GetMovieData().Result;
            var movieQuery = new MovieQuery { MinYear = 2013, MaxYear = 2016, OrderBy = "Released" };
            var filteredMovies = fakeMovieBl.GetMoviesByQuery(movies, movieQuery);
        }
    }
}
