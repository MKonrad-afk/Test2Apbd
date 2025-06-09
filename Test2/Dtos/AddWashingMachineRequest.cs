namespace Test2.Dtos;

public class AddWashingMachineRequest
{
    public WashingMachineDto WashingMachine { get; set; }
    public List<AvailableProgramInput> AvailablePrograms { get; set; }
}