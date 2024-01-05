using Tabib.Domain.Common;

namespace Tabib.Domain.Entities;

public class City : EntityBase
{
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Location> Locations { get; set; }
}
