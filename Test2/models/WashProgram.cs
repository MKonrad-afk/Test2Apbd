using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.models;

[Table("PROGRAM")]
public class WashProgram
{
    [Key]
    public int ProgramId { get; set; }
    public string Name { get; set; }
    public int DurationMinutes { get; set; }
    public ICollection<AvailableProgram> AvailablePrograms { get; set; }
}