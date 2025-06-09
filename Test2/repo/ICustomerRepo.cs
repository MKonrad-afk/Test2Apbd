using Test2.Dtos;
namespace Test2.repo;

public interface ICustomerRepo
{
    Task<CustomerDto> GetCustomerPurchasesAsync(int customerId);
}

