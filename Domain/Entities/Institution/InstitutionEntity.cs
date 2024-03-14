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

    public static InstitutionEntity Create(string name, InstitutionType type, string distrinct, string locality,
        string address, string phone, string email, string? director)
    {
        return new InstitutionEntity
        {
            Name = name,
            Type = type,
            District = distrinct,
            Locality = locality,
            Address = address,
            Phone = phone,
            Email = email,
            Director = director
        };
    }
}