using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.repo;
using Test2.services;

namespace Test2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddControllers();
        builder.Services.AddScoped<IWashingMachineRepo, WashingMachineRepo>();
        builder.Services.AddScoped<IWashingMachineService, WashingMachineService>();

        builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        
        builder.Services.AddAuthorization();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}