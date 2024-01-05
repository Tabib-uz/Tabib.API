using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabib.Domain.Entities;

namespace Tabib.Infrastructure.Persistence.EntityConfigurations
{
    internal class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable(nameof(Doctor));
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.Specializations)
                .WithOne(ds => ds.Doctor)
                .HasForeignKey(ds => ds.DoctorId);

            builder.Property(d => d.FirstName)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(d => d.LastName)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(d => d.Experience)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(d => d.Clinic)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(d => d.Education)
                .HasMaxLength(255)
                .IsRequired(false);

        }
    }
}
