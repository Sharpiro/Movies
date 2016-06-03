﻿using Movies.DotnetCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Movies.DotnetCore.Interfaces;
using System.Reflection;

namespace Movies.DotnetCore
{
    public class MovieBusinessLayer : IMovieBusinessLayer
    {
        private readonly MovieApiHelper _movieApiHelper;

        public MovieBusinessLayer(MovieApiHelper movieApiHelper)
        {
            _movieApiHelper = movieApiHelper;
        }

        public async Task<IEnumerable<Movie>> GetMovieData(int take = 250)
        {
            if (take < 1 || take > 250)
                throw new ArgumentOutOfRangeException(nameof(take), "'take' must be between 1 and 250 inclusively");
            var movieIds = _movieApiHelper.GetTopMovieIds();
            var movieDetailsList = await Task.WhenAll(movieIds.Take(take).Select((id, index) =>
                _movieApiHelper.GetMovieInfo(id, index)));
            return movieDetailsList;
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
