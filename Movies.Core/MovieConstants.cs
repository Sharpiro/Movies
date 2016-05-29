namespace Movies.Core
{
    public static class MovieConstants
    {
        public static class Urls
        {
            public const string Omdb = "http://www.omdbapi.com/?i={0}&plot=long&r=json";
            public const string ImdbTop250 = "http://www.imdb.com/chart/top?ref_=nv_mv_250_6";
        }
    }
}
