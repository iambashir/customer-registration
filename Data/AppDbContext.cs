namespace customer_registration.Data;

using customer_registration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<CustomerInfo> CustomerInfos => Set<CustomerInfo>();
}

