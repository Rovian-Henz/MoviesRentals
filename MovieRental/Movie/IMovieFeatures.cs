namespace MovieRental.Movie;

public interface IMovieFeatures
{
	Movie Save(Movie movie);
    IReadOnlyList<Movie> GetMovies(int page = 1, int pageSize = 50);
}