using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Dtos;
using Test2.models;

namespace Test2.repo;

public class WashingMachineRepo : IWashingMachineRepo
{
    private readonly AppDbContext _context;

    public WashingMachineRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddWashingMachineAsync(AddWashingMachineRequest request)
    {
        var machineInput = request.WashingMachine;

        if (machineInput.MaxWeight < 8)
            throw new Exception("Max weight must be at least 8 kg");

        if (await _context.WashingMachines.AnyAsync(w => w.SerialNumber == machineInput.Serial))
            throw new Exception("A washing machine with this serial number already exists");

        var washingMachine = new WashingMachine
        {
            MaxWeight = machineInput.MaxWeight,
            SerialNumber = machineInput.Serial
        };

        _context.WashingMachines.Add(washingMachine);
        await _context.SaveChangesAsync(); 

        foreach (var programInput in request.AvailablePrograms)
        {
            if (programInput.Price > 25)
                throw new Exception($"Program '{programInput.ProgramName}' exceeds the max price -> 25");

            var program = await _context.Set<WashProgram>()
                .FirstOrDefaultAsync(p => p.Name == programInput.ProgramName);


            if (program is null)
                throw new Exception($"Program '{programInput.ProgramName}' cannot be found");

            _context.AvailablePrograms.Add(new AvailableProgram
            {
                WashingMachineId = washingMachine.WashingMachineId,
                ProgramId = program.ProgramId,
                Price = programInput.Price
            });
        }

        await _context.SaveChangesAsync();
    }
}