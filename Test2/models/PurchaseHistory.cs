using System.ComponentModel.DataAnnotations;

namespace Test2.models;

public class PurchaseHistory
{
    [Key]
    public int AvailableProgramId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int? Rating { get; set; }
    public Customer Customer { get; set; }
    public AvailableProgram AvailableProgram { get; set; }
}