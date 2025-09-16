namespace MovieRental.Customer;

public interface ICustomerFeatures
{
    Task<Customer> SaveAsync(Customer customer, CancellationToken ct = default);
    IEnumerable<Customer> GetCustomers(string? customerName);
}
