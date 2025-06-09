using Microsoft.EntityFrameworkCore;
using Test2.models;

namespace Test2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<WashProgram> Programs { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WashProgram>().ToTable("PROGRAM");
        modelBuilder.Entity<AvailableProgram>()
            .HasOne(ap => ap.WashProgram)
            .WithMany(wp => wp.AvailablePrograms)
            .HasForeignKey(ap => ap.ProgramId);

        modelBuilder.Entity<PurchaseHistory>()
            .HasKey(ph => new { ph.CustomerId, ph.AvailableProgramId });
        
        modelBuilder.Entity<WashProgram>().HasData(
            new WashProgram { ProgramId = 1, Name = "firstWash", DurationMinutes = 30 },
            new WashProgram { ProgramId = 2, Name = "Eco Wash", DurationMinutes = 60 },
            new WashProgram { ProgramId = 3, Name = "Cotton Cycle", DurationMinutes = 60 },
            new WashProgram { ProgramId = 4, Name = "Synthetic", DurationMinutes = 60 },
            new WashProgram { ProgramId = 5, Name = "Quick Wash", DurationMinutes = 15 }
        );

        modelBuilder.Entity<WashingMachine>().HasData(
            new WashingMachine { WashingMachineId = 1, MaxWeight = 8, SerialNumber = "WM2012/S431/12" },
            new WashingMachine { WashingMachineId = 2, MaxWeight = 10, SerialNumber = "WM2012/S931/12" }
        );

        modelBuilder.Entity<AvailableProgram>().HasData(
            new AvailableProgram { AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 15 },
            new AvailableProgram { AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 2, Price = 20 },
            new AvailableProgram { AvailableProgramId = 3, WashingMachineId = 2, ProgramId = 1, Price = 18 },
            new AvailableProgram { AvailableProgramId = 4, WashingMachineId = 2, ProgramId = 3, Price = 13 },
            new AvailableProgram { AvailableProgramId = 5, WashingMachineId = 2, ProgramId = 4, Price = 12 }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "Al", LastName = "Smith", PhoneNumber = "123456789" },
            new Customer { CustomerId = 2, FirstName = "Bob", LastName = "Johnson", PhoneNumber = "987654322" }
        );

        modelBuilder.Entity<PurchaseHistory>().HasData(
            new PurchaseHistory
            {
                CustomerId = 1,
                AvailableProgramId = 1,
                PurchaseDate = new DateTime(2024, 1, 10),
                Rating = 5
            },
            new PurchaseHistory
            {
                CustomerId = 2,
                AvailableProgramId = 2,
                PurchaseDate = new DateTime(2024, 2, 15),
                Rating = 4
            }
        );
    }
}