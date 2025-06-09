using Test2.Dtos;
namespace Test2.services;

public interface ICustomerService
{
    Task<CustomerDto> GetCustomerPurchasesAsync(int id);
}