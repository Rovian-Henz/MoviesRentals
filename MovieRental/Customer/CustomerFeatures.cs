using MovieRental.Data;

namespace MovieRental.Customer;

public class CustomerFeatures : ICustomerFeatures
{
    private readonly MovieRentalDbContext _movieRentalDb;
    public CustomerFeatures(MovieRentalDbContext movieRentalDb)
    {
        _movieRentalDb = movieRentalDb;
    }

    public async Task<Customer> SaveAsync(Customer customer, CancellationToken ct = default)
    {
        await _movieRentalDb.Customers.AddAsync(customer, ct);
        await _movieRentalDb.SaveChangesAsync(ct);
        return customer;
    }

    public IEnumerable<Customer> GetCustomers(string? customerName)
    {
        if (string.IsNullOrEmpty(customerName))
            return _movieRentalDb.Customers;

        return _movieRentalDb.Customers.Where(x => x.Name == customerName);
    }

}
