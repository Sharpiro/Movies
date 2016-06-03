using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.DotnetCore.Models;

namespace Movies.DotnetCore.Interfaces
{
    public interface IMovieApiHelper
    {
        Task<Movie> GetMovieInfo(string movieId, int rank = 0);
        IEnumerable<string> GetTopMovieIds();
    }
}