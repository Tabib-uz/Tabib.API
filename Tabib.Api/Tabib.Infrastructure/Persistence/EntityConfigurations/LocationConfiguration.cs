using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabib.Domain.Entities;

namespace Tabib.Infrastructure.Persistence.EntityConfigurations
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable(nameof(Location));
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.City)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CityId);

            builder.Property(l => l.StreetName)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
