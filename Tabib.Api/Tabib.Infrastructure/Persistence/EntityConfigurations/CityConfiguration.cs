using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabib.Domain.Entities;

namespace Tabib.Infrastructure.Persistence.EntityConfigurations
{
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Locations)
                .WithOne(l => l.City)
                .HasForeignKey(l => l.CityId);

            builder.Property(c => c.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
