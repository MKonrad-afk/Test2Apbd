using Test2.Dtos;
using Test2.repo;

namespace Test2.services;

public class CustomerService : ICustomerService
{
    private ICustomerRepo _repo;

    public CustomerService(ICustomerRepo repo)
    {
        _repo = repo;
    }

    public Task<CustomerDto> GetCustomerPurchasesAsync(int customerId)
    {
        return _repo.GetCustomerPurchasesAsync(customerId);
    }

}
