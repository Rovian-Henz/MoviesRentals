using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		public async Task<Rental> SaveAsync(Rental rental, CancellationToken ct = default)
		{
			await _movieRentalDb.Rentals.AddAsync(rental, ct);
			await _movieRentalDb.SaveChangesAsync(ct);
			return rental;
		}

		public IEnumerable<Rental> GetRentalsByCustomerName(string? customerName)
		{
			if(string.IsNullOrEmpty(customerName))
				throw new ArgumentException("Customer name cannot be null or empty", nameof(customerName));

			return [.. _movieRentalDb.Rentals
				.AsNoTracking()
				.Where(r => r.CustomerName == customerName)
				.OrderBy(r => r.MovieId)];            
		}        
    }
}
