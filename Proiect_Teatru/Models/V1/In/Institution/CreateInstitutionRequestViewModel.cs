using Core.Services.Institution.Commands.CreateInstitution.DTOs;
using Domain.Entities.Institution.Enum;
using Proiect_Teatru.Models.Interfaces.In;

namespace Proiect_Teatru.Models.V1.In.Institution;

public class CreateInstitutionRequestViewModel : IRequest<CreateInstitutionCommand>
{
    public string Name { get; set; }
    public InstitutionType Type { get; set; }
    public string District { get; set; }
    public string Locality { get; set; }
    public string? Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string? Director { get; set; }

    public CreateInstitutionCommand Convert()
    {
        return new CreateInstitutionCommand()
        {
            Name = Name,
            Type = Type,
            District = District,
            Locality = Locality,
            Address = Address,
            Phone = Phone,
            Email = Email,
            Director = Director
        };
    }
}