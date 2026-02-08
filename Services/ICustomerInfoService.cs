
using customer_registration.DTOs;
using customer_registration.Entities;

namespace customer_registration.Services;

public interface ICustomerInfoService
{
    Task<List<CustomerInfo>> GetAllAsync();
    Task<CustomerInfo?> GetByIdAsync(long id);
    Task<CustomerInfo> CreateAsync(CustomerInfoDto dto);
    Task UpdateAsync(long id, CustomerInfoDto dto);
    Task DeleteAsync(long id);

    Task<long> GetCustomerCountAsync();

}

