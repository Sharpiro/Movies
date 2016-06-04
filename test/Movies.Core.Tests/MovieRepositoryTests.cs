using Movies.DotnetCore;
using Movies.DotnetCore.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using Xunit;

namespace Movies.Core.Tests
{
    public class MovieRepositoryTests
    {
        private const string _dataLoaction = @"c:\users\u403598\desktop\temp\movies";

        [Fact]
        public void GetTopMovieIdsTest()
        {
            //var wrapper = new HttpWrapper();
            //var repo = new MovieRepository(wrapper);
            var fakeRepo = new FakeMovieRepository();
            var ids = fakeRepo.GetTopMovieIds();
            //File.WriteAllLines($"{_dataLoaction}\\movieIds.txt", ids);
            Assert.True(ids.Any());
        }

        [Fact]
        public void GetMovieInfoTest()
        {
            //var wrapper = new HttpWrapper();
            //var repo = new MovieApiHelper(wrapper);
            //var movie = repo.GetMovieInfo("tt0060196");
            var fakeRepo = new FakeMovieRepository();
            var movie = fakeRepo.GetMovie("");
            Assert.NotNull(movie);
        }

        [Fact]
        public void GetMovieDataTest()
        {
            //var wrapper = new HttpWrapper();
            //var repo = new MovieRepository(wrapper);
            var fakeRepo = new FakeMovieRepository();
            var data = fakeRepo.GetMovieList().Result;
            Assert.True(data.Count() > 0);
            var jsonString = JsonConvert.SerializeObject(data);
            Assert.NotNull(jsonString);
            //File.WriteAllText($"{_dataLoaction}\\movieData.txt", jsonString);
        }
    }
}
