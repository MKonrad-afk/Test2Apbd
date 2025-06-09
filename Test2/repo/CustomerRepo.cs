
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Dtos;

namespace Test2.repo;

public class CustomerRepo : ICustomerRepo
{
    private readonly AppDbContext _context;
    
    public CustomerRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto> GetCustomerPurchasesAsync(int customerId)
    {
        var customer = await _context.Customers
            .Where(c => c.CustomerId == customerId)
            .Select(c => new CustomerDto
            {
                FirstName = c.FirstName,
                LastName =c.LastName,
                PhoneNumber = c.PhoneNumber,
                Purchases = c.PurchaseHistories.Select(ph => new PurchaseDto
                {
                    Date = ph.PurchaseDate,
                    Rating = ph.Rating,
                    Price = ph.AvailableProgram.Price,
                    WashingMachine = new WashingMachineDto
                    {
                        Serial = ph.AvailableProgram.WashingMachine.SerialNumber,
                        MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight
                    },
                    Program = new ProgramDto
                    {
                        Name = ph.AvailableProgram.WashProgram.Name,
                        Duration = ph.AvailableProgram.WashProgram.DurationMinutes
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();

        return customer;
    }
}