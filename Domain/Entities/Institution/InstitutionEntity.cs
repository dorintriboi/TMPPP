using Domain.Core.Domain.Entities;
using Domain.Entities.Event;
using Domain.Entities.Institution.Enum;

namespace Domain.Entities.Institution;

public class InstitutionEntity : FullAuditEntity
{
    public string Name { get; set; }
    public InstitutionType Type { get; set; }
    public string District { get; set; }
    public string Locality { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? Director { get; set; }
    public virtual ICollection<EventEntity> Events { get; set; }
}