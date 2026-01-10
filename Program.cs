using customer_registration.Data;
using customer_registration.Repositories;
using customer_registration.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Database
// =====================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =====================
// Dependency Injection
// =====================
builder.Services.AddScoped<CustomerInfoRepository>();
builder.Services.AddScoped<CustomerInfoService, CustomerInfoServiceImpl>();

// =====================
// CORS (Angular 4200)
// =====================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// =====================
// Controllers & Swagger
// =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =====================
// Explicit URL / Port
// =====================
app.Urls.Add("http://localhost:5000");

// =====================
// Middleware Order (IMPORTANT)
// =====================
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngular");   // ✅ MUST be before MapControllers

app.UseAuthorization();

app.MapControllers();

app.Run();
