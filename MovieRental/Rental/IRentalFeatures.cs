namespace MovieRental.Rental;

public interface IRentalFeatures
{
    Task<Rental> SaveAsync(Rental rental, CancellationToken ct = default);
	IEnumerable<Rental> GetRentalsByCustomerName(string? customerName);
}