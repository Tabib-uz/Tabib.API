using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabib.Domain.Entities;

namespace Tabib.Infrastructure.Persistence.EntityConfigurations
{
    internal class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable(nameof(Specialization));
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.DoctorSpecializations)
                .WithOne(ds => ds.Specialization)
                .HasForeignKey(ds => ds.SpecializationId);

            builder.Property(s => s.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
