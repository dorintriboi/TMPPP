using Domain.Entities.CompanyEvent;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.CompanyEvent.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.CompanyEvent;

public class CompanyEventRepository(ApplicationDbContext context) :
    FullAuditGenericRepository<CompanyEventEntity>(context),
    ICompanyEventRepository;