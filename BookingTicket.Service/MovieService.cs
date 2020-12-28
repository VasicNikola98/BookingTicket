using BookingTicket.Entities;
using BookingTicket.Entities.Entities;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.Service
{
    public class MovieService
    {
        public static List<Movie> GetMovies()
        {
            ISession session = SessionManager.GetSession();
            List<Movie> movies = new List<Movie>();


            if (session == null)
                return null;

            var moviesData = session.Execute("select * from \"Movie\"");


            foreach (var movieData in moviesData)
            {
                Movie movie = new Movie();
                movie.MovieId = movieData["MovieId"] != null ? movieData["MovieId"].ToString() : string.Empty;
                movie.Title = movieData["Title"] != null ? movieData["Title"].ToString() : string.Empty;
                movie.Genre = movieData["Genre"] != null ? movieData["Genre"].ToString() : string.Empty;
                movie.RunTime = movieData["RunTime"] != null ? movieData["RunTime"].ToString() : string.Empty;
                movie.ImageUrl = movieData["ImageUrl"] != null ? movieData["ImageUrl"].ToString() : string.Empty;
                movie.Starring = movieData["Starring"] != null ? movieData["Starring"].ToString() : string.Empty;
                movie.Description = movieData["Description"] != null ? movieData["Description"].ToString() : string.Empty;
                movie.ReleaseDate = movieData["ReleaseDate"] != null ? movieData["ReleaseDate"].ToString() : string.Empty;
                movies.Add(movie);
            }
            return movies;
        }
        public static Movie GetMovieById(string Id)
        {
            ISession session = SessionManager.GetSession();
            Movie movie = new Movie();


            if (session == null)
                return null;

            var movieData = session.Execute("select * from \"Movie\" where \"MovieId\" = '" + Id + "'").FirstOrDefault();

            movie.MovieId = movieData["MovieId"] != null ? movieData["MovieId"].ToString() : string.Empty;
            movie.Title = movieData["Title"] != null ? movieData["Title"].ToString() : string.Empty;
            movie.Genre = movieData["Genre"] != null ? movieData["Genre"].ToString() : string.Empty;
            movie.RunTime = movieData["RunTime"] != null ? movieData["RunTime"].ToString() : string.Empty;
            movie.ImageUrl = movieData["ImageUrl"] != null ? movieData["ImageUrl"].ToString() : string.Empty;
            movie.Starring = movieData["Starring"] != null ? movieData["Starring"].ToString() : string.Empty;
            movie.Description = movieData["Description"] != null ? movieData["Description"].ToString() : string.Empty;
            movie.ReleaseDate = movieData["ReleaseDate"] != null ? movieData["ReleaseDate"].ToString() : string.Empty;


            return movie;
        }
        public static List<Movie> GetLastMovies(int n)
        {

            ISession session = SessionManager.GetSession();
            List<Movie> movies = new List<Movie>();


            if (session == null)
                return null;

            var moviesData = session.Execute("select * from \"Movie\"").Take(n);

            foreach (var movieData in moviesData)
            {
                Movie movie = new Movie();
                movie.MovieId = movieData["MovieId"] != null ? movieData["MovieId"].ToString() : string.Empty;
                movie.Title = movieData["Title"] != null ? movieData["Title"].ToString() : string.Empty;
                movie.Genre = movieData["Genre"] != null ? movieData["Genre"].ToString() : string.Empty;
                movie.RunTime = movieData["RunTime"] != null ? movieData["RunTime"].ToString() : string.Empty;
                movie.ImageUrl = movieData["ImageUrl"] != null ? movieData["ImageUrl"].ToString() : string.Empty;
                movie.Starring = movieData["Starring"] != null ? movieData["Starring"].ToString() : string.Empty;
                movie.Description = movieData["Description"] != null ? movieData["Description"].ToString() : string.Empty;
                movie.ReleaseDate = movieData["ReleaseDate"] != null ? movieData["ReleaseDate"].ToString() : string.Empty;
                movies.Add(movie);
            }

            return movies;
        }
        public static void AddMovie(Movie movie)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            movie.MovieId = Guid.NewGuid().ToString();

            RowSet movieData = session.Execute("insert into \"Movie\" (\"MovieId\",\"Title\", \"Genre\", \"RunTime\", \"ImageUrl\", \"Starring\", \"Description\",\"ReleaseDate\")  values ('" + movie.MovieId + "', '" + movie.Title + "', '" + movie.Genre + "', '" + movie.RunTime + "', '" + movie.ImageUrl + "', '" + movie.Starring + "','" + movie.Description + "','" + movie.ReleaseDate + "')");

        }
        public static void DeleteMovie(string movieID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet movieData = session.Execute("delete from \"Movie\" where \"MovieId\" = '" + movieID + "'");

        }
        public static void EditMovie(Movie movie)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet movieData = session.Execute("update \"Movie\" set \"Title\" = '" + movie.Title + "', \"RunTime\" = '" + movie.RunTime + "',\"Genre\" = '" + movie.Genre + "',  \"ReleaseDate\" = '" + movie.ReleaseDate + "', \"Description\" = '" + movie.Description + "', \"Starring\" = '" + movie.Starring + "', \"ImageUrl\" = '" + movie.ImageUrl + "'  where \"MovieId\" = '" + movie.MovieId + "'");
        }
    }
}
