using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Movies.DotnetCore.Interfaces;
using Movies.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Web.Api
{
    public class MoviesController : Controller
    {
        private IMemoryCache _cache;
        private readonly IMovieBusinessLayer _movieBusinessLayer;

        public MoviesController(IMovieBusinessLayer movieHelper, IMemoryCache cache)
        {
            _cache = cache;
            _movieBusinessLayer = movieHelper;
        }

        public async Task<IEnumerable<Movie>> GetMovieData(int take)
        {
            var data = await GetMovieDataFromCache();
            return data;
        }

        public async Task<IActionResult> GetMoviesByQuery([FromBody] MovieQuery query)
        {
            try
            {
                var movies = await GetMovieDataFromCache();
                var filteredMovies = _movieBusinessLayer.GetMoviesByQuery(movies, query);
                return Ok(filteredMovies);

            }
            catch (Exception ex)
            {
                var jsonResult = new JsonResult(new { error = ex.Message });
                jsonResult.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return jsonResult;
            }
        }

        private async Task<IEnumerable<Movie>> GetMovieDataFromCache()
        {
            var data = _cache.Get("movieData") as IEnumerable<Movie>;
            if (data == null)
            {
                data = await _movieBusinessLayer.GetMovieData();
                _cache.Set("movieData", data);
            }
            return data;
        }
    }
}
