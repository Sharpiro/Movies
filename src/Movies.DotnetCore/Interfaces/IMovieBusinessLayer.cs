using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.DotnetCore.Models;

namespace Movies.DotnetCore.Interfaces
{
    public interface IMovieBusinessLayer
    {
        Task<IEnumerable<Movie>> GetMovieData(int take = 250);
        IEnumerable<Movie> GetMoviesByQuery(IEnumerable<Movie> movies, MovieQuery query);
    }
}