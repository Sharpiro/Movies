using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Movies.DotnetCore.Interfaces;
using Movies.DotnetCore.Models;
using System;
using System.Threading.Tasks;

namespace Movies.Web.Api
{
    public class MoviesController : Controller
    {
        private IMemoryCache _cache;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository, IMemoryCache cache)
        {
            _cache = cache;
            _movieRepository = movieRepository;
        }

        public async Task<MovieList> GetMovieData(int take)
        {
            var data = await GetMovieDataFromCache();
            return data;
        }

        public async Task<IActionResult> GetMoviesByQuery([FromBody] MovieQuery query)
        {
            try
            {
                var movies = await GetMovieDataFromCache();
                var filteredMovies = movies.Filter(query);
                return Ok(filteredMovies);

            }
            catch (Exception ex)
            {
                var jsonResult = new JsonResult(new { error = ex.Message });
                jsonResult.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return jsonResult;
            }
        }

        private async Task<MovieList> GetMovieDataFromCache()
        {
            var data = _cache.Get("movieData") as MovieList;
            if (data == null)
            {
                data = await _movieRepository.GetMovieList();
                _cache.Set("movieData", data);
            }
            return data;
        }
    }
}
