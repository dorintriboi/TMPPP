using Domain.Entities.Employee;
using Infrastructure.Data;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;

namespace Infrastructure.Repositories.BusinessRepository.Employee;

public class EmployeeRepository(ApplicationDbContext context) : FullAuditGenericRepository<EmployeeEntity>(context),
    IEmployeeRepository;