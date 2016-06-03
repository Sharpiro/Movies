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
    public class FakeMovieBusinessLayer : IMovieBusinessLayer
    {
        public string DataPath { get; set; } = @"c:\users\u403598\desktop\temp\movies";

        public async Task<IEnumerable<Movie>> GetMovieData(int take = 250)
        {
            var movieString = File.ReadAllText($"{DataPath}\\movieData.txt");
            var movies = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Movie>>(movieString));
            return movies.Take(take);
        }

        public IEnumerable<Movie> GetMoviesByQuery(IEnumerable<Movie> movies, MovieQuery query)
        {
            var filteredMovies = movies.Where(m => m.Released.Year <= query.MaxYear && m.Released.Year >= query.MinYear);
            if (query.Contains != "*")
                filteredMovies = filteredMovies.Where(m => m.Title.ToLower().Contains(query.Contains.ToLower()));
            Func<Movie, object> orderByLogic = null;
            if (query.OrderBy.ToLower() == "rank")
                orderByLogic = (movie) => movie.Rank;
            if (query.OrderBy.ToLower() == "title")
                orderByLogic = (movie) => movie.Title;
            if (query.OrderBy.ToLower() == "released")
                orderByLogic = (movie) => movie.Released;
            filteredMovies = filteredMovies.OrderBy(orderByLogic);
            return filteredMovies;
        }
    }
}
