
using customer_registration.DTOs;
using customer_registration.Entities;
using customer_registration.Repositories;

namespace customer_registration.Services;
public class CustomerInfoServiceImpl : CustomerInfoService
{
    private readonly CustomerInfoRepository _repository;

    public CustomerInfoServiceImpl(CustomerInfoRepository repository)
    {
        _repository = repository;
    }

    public Task<List<CustomerInfo>> GetAllAsync()
        => _repository.GetAllAsync();

    public Task<CustomerInfo?> GetByIdAsync(long id)
        => _repository.GetByIdAsync(id);

    public async Task<CustomerInfo> CreateAsync(CustomerInfoDto dto)
    {
        var customer = new CustomerInfo
        {
            FullName = dto.FullName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            BirthDate = dto.BirthDate,
            MeritalStatus = dto.MeritalStatus,
            Gender = dto.Gender,
            City = dto.City,
            ZipCode = dto.ZipCode,
            Address = dto.Address
        };

        return await _repository.SaveAsync(customer);
    }

    public async Task UpdateAsync(long id, CustomerInfoDto dto)
    {
        var customer = await _repository.GetByIdAsync(id)
                       ?? throw new Exception("Customer not found");

        customer.FullName = dto.FullName;
        customer.PhoneNumber = dto.PhoneNumber;
        customer.Email = dto.Email;
        customer.BirthDate = dto.BirthDate;
        customer.MeritalStatus = dto.MeritalStatus;
        customer.Gender = dto.Gender;
        customer.City = dto.City;
        customer.ZipCode = dto.ZipCode;
        customer.Address = dto.Address;

        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(long id)
    {
        var customer = await _repository.GetByIdAsync(id)
                       ?? throw new Exception("Customer not found");

        await _repository.DeleteAsync(customer);
    }


    // 🔹 NEW METHOD for Dashboard
    public async Task<long> GetCustomerCountAsync()
    {
        return await _repository.CountAsync();
    }

}

