using MauiBookGiveaway.Domain.Data;

namespace MauiBookGiveaway.Domain.Services;

public interface IDataService {
    Task<IEnumerable<Customer>> GetCustomersAsync();
}