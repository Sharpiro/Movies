using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.DotnetCore.Models;

namespace Movies.DotnetCore.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovie(string movieId, int rank = 0);
        IEnumerable<string> GetTopMovieIds();
        Task<MovieList> GetMovieList(int take = 250);
    }
}