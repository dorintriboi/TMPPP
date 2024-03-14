using Core.Services.Institution.Commands.CreateInstitution.DTOs;
using Core.Services.Institution.Common;
using Domain.Entities.Institution;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using MediatR;

namespace Core.Services.Institution.Commands.CreateInstitution;

public class CreateInstitutionHandler
    (IApplicationUnitOfWork repository) : IRequestHandler<CreateInstitutionCommand, InstitutionDto>
{
    public async Task<InstitutionDto> Handle(CreateInstitutionCommand request, CancellationToken cancellationToken)
    {
        var institutionEntity = InstitutionEntity.Create(request.Name, request.Type, request.District, request.Locality,
            request.Address, request.Phone, request.Email, request.Director);

        await repository.InstitutionRepository.InsertAsync(institutionEntity);
        await repository.SaveAsync();

        return InstitutionDto.From(institutionEntity);
    }
}