namespace Test2.models;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }
    public int WashingMachineId { get; set; }
    public int ProgramId { get; set; }
    public decimal Price { get; set; }
    public WashingMachine WashingMachine { get; set; }
    public WashProgram WashProgram { get; set; }
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; }
}
