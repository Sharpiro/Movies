using Movies.DotnetCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Movies.DotnetCore
{
    public class MovieBusinessLayer
    {
        private readonly MovieApiHelper _movieApiHelper;

        public MovieBusinessLayer(MovieApiHelper movieApiHelper)
        {
            _movieApiHelper = movieApiHelper;
        }

        public async Task<IEnumerable<Movie>> GetMovieData(int take)
        {
            if (take <= 0 || take > 250)
                throw new ArgumentOutOfRangeException(nameof(take), "'take' must be between 1 and 250 inclusively");
            var movieIds = _movieApiHelper.GetTopMovieIds();
            var movieDetailsList = await Task.WhenAll(movieIds.Take(take).Select((id, other) =>
                _movieApiHelper.GetMovieInfo(id, other)));
            return movieDetailsList.ToList();
        }
    }
}
