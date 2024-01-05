using Tabib.Domain.Common;

namespace Tabib.Domain.Entities;

public class DoctorSpecialization : EntityBase
{
    public decimal PricePerVisit { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int SpecializationId { get; set; }
    public Specialization Specialization { get; set; }
}
