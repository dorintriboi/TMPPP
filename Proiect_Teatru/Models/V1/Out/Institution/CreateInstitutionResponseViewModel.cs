using Core.Services.Institution.Common;
using Domain.Entities.Institution.Enum;
using Proiect_Teatru.Models.Interfaces.Out;

namespace Proiect_Teatru.Models.V1.Out.Institution;

public class CreateInstitutionResponseViewModel: IResponse<CreateInstitutionResponseViewModel,InstitutionDto>
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

    public static IResponse<CreateInstitutionResponseViewModel, InstitutionDto> Convert(InstitutionDto dto)
    {
        if (dto is null) return null;
        
        return new CreateInstitutionResponseViewModel()
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
            District = dto.District,
            Locality = dto.Locality,
            Address = dto.Address,
            Phone = dto.Phone,
            Email = dto.Email,
            Director = dto.Director
        };
    }
}