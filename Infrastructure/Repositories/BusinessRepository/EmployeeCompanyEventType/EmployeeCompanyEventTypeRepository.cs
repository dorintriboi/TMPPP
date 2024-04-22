using Domain.Entities.EmployeeCompanyEventType;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.EmployeeCompanyEventType.Interface;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.EmployeeCompanyEventType;

public class EmployeeCompanyEventTypeRepository(ApplicationDbContext context) :
    FullAuditGenericRepository<EmployeeCompanyEventTypeEntity>(context),
    IEmployeeCompanyEventTypeRepository;