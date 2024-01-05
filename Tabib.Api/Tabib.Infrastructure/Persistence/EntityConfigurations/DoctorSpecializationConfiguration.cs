using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tabib.Domain.Entities;

namespace Tabib.Infrastructure.Persistence.EntityConfigurations
{
    internal class DoctorSpecializationConfiguration : IEntityTypeConfiguration<DoctorSpecialization>
    {
        public void Configure(EntityTypeBuilder<DoctorSpecialization> builder)
        {
            builder.ToTable(nameof(DoctorSpecialization));
            builder.HasKey(ds => ds.Id);

            builder.HasOne(ds => ds.Doctor)
                .WithMany(d => d.Specializations)
                .HasForeignKey(ds => ds.DoctorId);
            builder.HasOne(ds => ds.Specialization)
                .WithMany(s => s.DoctorSpecializations)
                .HasForeignKey(ds => ds.SpecializationId);
        }
    }
}
