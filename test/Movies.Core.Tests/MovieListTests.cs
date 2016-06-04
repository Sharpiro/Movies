using Movies.DotnetCore;
using Movies.DotnetCore.Models;
using System.Linq;
using Xunit;

namespace Movies.Core.Tests
{
    public class MovieListTests
    {
        private const string _dataLoaction = @"c:\users\sharpiro\desktop\temp\movies";

        [Fact]
        public void GetEnumeratorTest()
        {
            var repo = new FakeMovieRepository();
            var movieList = repo.GetMovieList().Result;
            Assert.True(movieList.Count() > 1);
        }

        [Fact]
        public void FilterTest()
        {
            var fakeRepo = new FakeMovieRepository();
            var movies = fakeRepo.GetMovieList().Result;
            var movieQuery = new MovieQuery { MinYear = 2013, MaxYear = 2016, OrderBy = "Released" };
            var filteredMovies = movies.Filter(movieQuery);
            Assert.True(filteredMovies.Count() == 3);
            Assert.NotNull(filteredMovies.FirstOrDefault());
            Assert.Equal(filteredMovies.FirstOrDefault().ImdbID, "2");
        }
    }
}
