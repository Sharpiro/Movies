using Movies.DotnetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.DotnetCore.Models;

namespace Movies.DotnetCore
{
    public class FakeMovieRepository : IMovieRepository
    {
        public IEnumerable<string> GetTopMovieIds()
        {
            var movieIds = new List<string> { "123", "456" };
            return movieIds;
        }

        public Task<Movie> GetMovie(string movieId, int rank = 0)
        {
            return Task.Run(() => new Movie { ImdbID = "1", Title = "movie" });
        }

        public Task<MovieList> GetMovieList(int take = 250)
        {
            return Task.Run(() =>
            {
                var movies = new List<Movie>
                {
                    new Movie { ImdbID = "1", Title = "movie1", Released = new DateTime(2016, 05, 03) },
                    new Movie { ImdbID = "2", Title = "movie2", Released = new DateTime(2013, 05, 03) },
                    new Movie { ImdbID = "3", Title = "movie3", Released = new DateTime(2015, 05, 03) },
                    new Movie { ImdbID = "4", Title = "movie4", Released = new DateTime(2012, 05, 03) }
                };
                var movieList = new MovieList(movies);
                return movieList;
            });
        }
    }
}
