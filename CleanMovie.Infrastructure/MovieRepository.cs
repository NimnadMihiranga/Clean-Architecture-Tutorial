using CleanMovie.Application;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie() {Id =1 , Name = "Passion of Christ", Cost = 2},
            new Movie() {Id =2 , Name = "Home Alone 1", Cost = 4 }
        };
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _movieDbContext.Movies.Add(movie);
            _movieDbContext.SaveChanges();
            return movie;
        }

        List<Movie> IMovieRepository.GetAllMovies()
        {
            return _movieDbContext.Movies.ToList();
            
        }
    }
}
