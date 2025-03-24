using MauiBookGiveaway.Domain.Data;
using MauiBookGiveaway.Domain.Services;

namespace MauiBookGiveaway.Infrastructure.Services;

public class DataService : IDataService
{
    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        List<Customer> customers = new List<Customer>();
        for (int i = 0; i < 100; i++)
        {
            customers.Add(new Customer() { FirstName = $"FirstName{i}", LastName = $"LastName{i}" });
        }
        return customers;
    }
}