using Microsoft.AspNetCore.Mvc;
using Movies.DotnetCore;
using Movies.DotnetCore.Models;
using System.Collections.Generic;

namespace Movies.Web.Api
{
    public class MoviesController : Controller
    {
        private readonly MovieBusinessLayer _movieBusinessLayer;

        public MoviesController(MovieBusinessLayer movieHelper)
        {
            _movieBusinessLayer = movieHelper;
        }

        public IEnumerable<Movie> GetMovieData()
        {
            var data = _movieBusinessLayer.GetMovieData(5).Result;
            return data;
        }
    }
}
