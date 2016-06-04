using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Movies.DotnetCore.Models
{
    public class MovieList : IEnumerable, IEnumerable<Movie>
    {
        private readonly IEnumerable<Movie> _movieList;

        public MovieList(IEnumerable<Movie> movieList)
        {
            _movieList = movieList;
        }


        public IEnumerator<Movie> GetEnumerator()
        {
            return _movieList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public MovieList Filter(MovieQuery query)
        {
            var filteredMovies = _movieList.Where(m => m.Released.Year <= query.MaxYear && m.Released.Year >= query.MinYear);
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
            return new MovieList(filteredMovies);
        }
    }
}
