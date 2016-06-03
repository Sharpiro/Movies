using Movies.DotnetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movies.DotnetCore.Models;
using System.IO;

namespace Movies.DotnetCore
{
    public class FakeApiHelper : IMovieApiHelper
    {
        public string DataPath { get; set; } = @"c:\users\u403598\desktop\temp\movies";

        public Task<Movie> GetMovieInfo(string movieId, int rank = 0)
        {
            var movieIds = File.ReadAllLines($"{DataPath}\\movieIds.txt");
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTopMovieIds()
        {
            throw new NotImplementedException();
        }
    }
}
