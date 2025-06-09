using Test2.Dtos;
using Test2.repo;

namespace Test2.services;

public class WashingMachineService : IWashingMachineService
{
    private readonly IWashingMachineRepo repo;

    public WashingMachineService(IWashingMachineRepo repo)
    {
        this.repo = repo;
    }

    public Task AddWashingMachineAsync(AddWashingMachineRequest request)
    {
        return repo.AddWashingMachineAsync(request);
    }

}

