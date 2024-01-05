using Tabib.Domain.Common;

namespace Tabib.Domain.Entities;

public class Location : EntityBase
{
    public string StreetName { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}
