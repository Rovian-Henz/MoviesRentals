using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}
		
		public Movie Save(Movie movie)
		{
			_movieRentalDb.Movies.Add(movie);
			_movieRentalDb.SaveChanges();
			return movie;
		}

		public IReadOnlyList<Movie> GetMovies(int page = 1, int pageSize = 50)
		{
			return [.. _movieRentalDb.Movies
				.AsNoTracking()
				.OrderBy(m => m.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)];
        }
    }
}
