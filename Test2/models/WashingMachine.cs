using System.ComponentModel.DataAnnotations;

namespace Test2.models;

public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    public decimal MaxWeight { get; set; }
    public string SerialNumber { get; set; }
    public ICollection<AvailableProgram> AvailablePrograms { get; set; }
}