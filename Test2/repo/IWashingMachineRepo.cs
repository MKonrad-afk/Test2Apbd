using Test2.Dtos;

namespace Test2.repo;

public interface IWashingMachineRepo
{
    Task AddWashingMachineAsync(AddWashingMachineRequest request);
}