namespace customer_registration.Repositories;

using customer_registration.Data;
using customer_registration.Entities;
using Microsoft.EntityFrameworkCore;


public class CustomerInfoRepository
{
    private readonly AppDbContext _context;

    public CustomerInfoRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<CustomerInfo>> GetAllAsync() =>
        _context.CustomerInfos.AsNoTracking().ToListAsync();

    public Task<CustomerInfo?> GetByIdAsync(long id) =>
        _context.CustomerInfos.FindAsync(id).AsTask();

    public async Task<CustomerInfo> SaveAsync(CustomerInfo customer)
    {
        _context.CustomerInfos.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task UpdateAsync(CustomerInfo customer)
    {
        _context.CustomerInfos.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(CustomerInfo customer)
    {
        _context.CustomerInfos.Remove(customer);
        await _context.SaveChangesAsync();
    }

    //For Dashboard
    public async Task<long> CountAsync()
    {
        return await _context.CustomerInfos.LongCountAsync();
    }


}

