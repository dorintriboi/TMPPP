using Domain.Entities.Institution;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Institution;

public class InstitutionRepository
    (ApplicationDbContext context) : FullAuditGenericRepository<InstitutionEntity>(context), IInstitutionRepository;