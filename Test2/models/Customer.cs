namespace Test2.models;
using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<PurchaseHistory> PurchaseHistories { get; set; }
}