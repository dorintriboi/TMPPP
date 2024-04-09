using Domain.Entities.Institution;
using Domain.Entities.Institution.Enum;

namespace Core.Services.Institution.Common;

public class InstitutionDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public InstitutionType Type { get; set; }
    public string District { get; set; }
    public string Locality { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? Director { get; set; }
    public static InstitutionDto From(InstitutionEntity entity)
    {
        return new InstitutionDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Type = entity.Type,
            District = entity.District,
            Locality = entity.Locality,
            Address = entity.Address,
            Phone = entity.Phone,
            Email = entity.Email,
            Director = entity.Director
        };
    }
}