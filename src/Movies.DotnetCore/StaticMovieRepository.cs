using Movies.DotnetCore.Interfaces;
using Movies.DotnetCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.DotnetCore
{
    public class StaticMovieRepository : IMovieRepository
    {
        private readonly string _directoryPath;

        public StaticMovieRepository(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        public IEnumerable<string> GetTopMovieIds()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovie(string movieId, int rank = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieList> GetMovieList(int take = 250)
        {
            var movieString = File.ReadAllText($"{_directoryPath}\\movieData.txt");
            var movies = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Movie>>(movieString));
            return new MovieList(movies.Take(take));
        }
    }
}
