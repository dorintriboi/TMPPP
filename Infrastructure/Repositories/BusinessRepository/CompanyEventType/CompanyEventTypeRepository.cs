using Domain.Entities.CompanyEventType;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.CompanyEventType.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.CompanyEventType;

public class CompanyEventTypeRepository(ApplicationDbContext context) :
    FullAuditGenericRepository<CompanyEventTypeEntity>(context),
    ICompanyEventTypeRepository;