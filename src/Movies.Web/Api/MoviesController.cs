using Movies.DotnetCore;
using Movies.DotnetCore.Models;
using System.Collections.Generic;

namespace Movies.Web.Api
{
    public class MoviesController
    {
        private readonly MovieBusinessLayer _movieBusinessLayer;

        public MoviesController(MovieBusinessLayer movieHelper)
        {
            _movieBusinessLayer = movieHelper;
        }

        public IEnumerable<Movie> GetMovieData(int take)
        {
            var data = _movieBusinessLayer.GetMovieData(take).Result;
            return data;
        }
    }
}
