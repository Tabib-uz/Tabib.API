using Tabib.Domain.Common;
using Tabib.Domain.Enums;

namespace Tabib.Domain.Entities;

public class Doctor : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Clinic { get; set; }
    public string Experience { get; set; }
    public string Education { get; set; }
    public Gender Gender { get; set; }

    public virtual ICollection<DoctorSpecialization> Specializations { get; set; }
}
