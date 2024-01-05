using Tabib.Domain.Common;

namespace Tabib.Domain.Entities;

public class Specialization : EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
}
