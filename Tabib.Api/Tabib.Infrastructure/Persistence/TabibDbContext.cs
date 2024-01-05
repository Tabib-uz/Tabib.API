using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Tabib.Domain.Entities;

namespace Tabib.Infrastructure.Persistence;

public class TabibDbContext : DbContext
{
    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Specialization> Specializations { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }

    public TabibDbContext(DbContextOptions<TabibDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
