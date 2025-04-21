using IonLineMonitoringApp.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Line> Lines { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<LineProduct> LineProducts { get; set; }
    public DbSet<ShiftData> ShiftDatas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShiftData>().HasData(
            new ShiftData
            {
                ShiftDataId = 1,
                LineId = 1,
                ProductId = 1,
                Shift = "A",
                Date = new DateTime(2025, 4, 19),
                LineSpeed = 120,
                TotalProduction = 500,
                TotalEnergy = 250
            },
            new ShiftData
            {
                ShiftDataId = 2,
                LineId = 2,
                ProductId = 2,
                Shift = "B",
                Date = new DateTime(2025, 4, 20),
                LineSpeed = 100,
                TotalProduction = 400,
                TotalEnergy = 200
            },
            new ShiftData
            {
                ShiftDataId = 3,
                LineId = 3,
                ProductId = 3,
                Shift = "C",
                Date = new DateTime(2025, 4, 21),
                LineSpeed = 110,
                TotalProduction = 450,
                TotalEnergy = 230
            }
        );
    }
}
