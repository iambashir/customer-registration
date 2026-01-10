
using customer_registration.Data;
using customer_registration.Repositories;
using customer_registration.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CustomerInfoRepository>();
builder.Services.AddScoped<CustomerInfoService, CustomerInfoServiceImpl>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Set explicit URL/Port
app.Urls.Add("http://localhost:5000");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
