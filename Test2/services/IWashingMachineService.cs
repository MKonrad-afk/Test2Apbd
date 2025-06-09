using Test2.Dtos;

namespace Test2.services;

public interface IWashingMachineService
{
    Task AddWashingMachineAsync(AddWashingMachineRequest request);
}