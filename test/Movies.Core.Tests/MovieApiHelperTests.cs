using Movies.DotnetCore;
using System.IO;
using System.Linq;
using Xunit;

namespace Movies.Core.Tests
{
    public class MovieApiHelperTests
    {
        private const string _dataLoaction = @"c:\users\u403598\desktop\temp\movies";

        [Fact]
        public void GetTopMovieIdsTest()
        {
            var wrapper = new HttpWrapper();
            var helper = new MovieApiHelper(wrapper);
            var ids = helper.GetTopMovieIds();
            //File.WriteAllLines($"{_dataLoaction}\\movieIds.txt", ids);
            Assert.True(ids.Count() == 250);
        }

        [Fact]
        public void GetMovieInfoTest()
        {
            var wrapper = new HttpWrapper();
            var helper = new MovieApiHelper(wrapper);
            var movie = helper.GetMovieInfo("tt0060196");
            Assert.NotNull(movie);
        }
    }
}
